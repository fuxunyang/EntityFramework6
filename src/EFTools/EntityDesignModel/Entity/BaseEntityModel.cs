// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.Data.Entity.Design.Model.Entity
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Xml.Linq;

    internal abstract class BaseEntityModel : EFRuntimeModelRoot
    {
        internal static readonly string ElementName = "Schema";
        internal static readonly string AttributeAlias = "Alias";
        internal static readonly string AttributeNamespace = "Namespace";

        protected List<BaseEntityContainer> _entityContainers = new List<BaseEntityContainer>();
        private readonly List<EntityType> _entityTypes = new List<EntityType>();
        private readonly List<Association> _associations = new List<Association>();

        private DefaultableValue<string> _aliasAttr;
        private DefaultableValue<string> _namespaceAttr;

        protected BaseEntityModel(EFArtifact parent, XElement element)
            : base(parent, element)
        {
        }

        #region properties

        internal override string EFTypeName
        {
            get { return ElementName; }
        }

        /// <summary>
        ///     Returns the string value of the Alias attribute
        /// </summary>
        internal DefaultableValue<string> Alias
        {
            get
            {
                if (_aliasAttr == null)
                {
                    // we can safely create these here since we are the top node and don't need to be parsed first
                    _aliasAttr = new AliasDefaultableValue(this);
                }
                return _aliasAttr;
            }
        }

        private class AliasDefaultableValue : DefaultableValue<string>
        {
            internal AliasDefaultableValue(EFElement parent)
                : base(parent, AttributeAlias)
            {
            }

            internal override string AttributeName
            {
                get { return AttributeAlias; }
            }

            public override string DefaultValue
            {
                get { return Resources.Default_Alias; }
            }
        }

        /// <summary>
        ///     Returns the string value of the Namespace attribute
        /// </summary>
        internal DefaultableValue<string> Namespace
        {
            get
            {
                if (_namespaceAttr == null)
                {
                    // we can safely create these here since we are the top node and don't need to be parsed first
                    _namespaceAttr = new NamespaceDefaultableValue(this);
                }
                return _namespaceAttr;
            }
        }

        private class NamespaceDefaultableValue : DefaultableValue<string>
        {
            internal NamespaceDefaultableValue(EFElement parent)
                : base(parent, AttributeNamespace)
            {
            }

            internal override string AttributeName
            {
                get { return AttributeNamespace; }
            }

            public override string DefaultValue
            {
                get { return string.Empty; }
            }
        }

        /// <summary>
        ///     Returns true if this model is based on a CSDL file, false if an SSDL file
        /// </summary>
        public abstract bool IsCSDL { get; }

        // virtual for mocking
        public virtual string NamespaceValue
        {
            get { return Namespace.Value; }
        }

        internal IEnumerable<BaseEntityContainer> EntityContainers()
        {
            return _entityContainers;
        }

        internal int EntityContainerCount
        {
            get { return _entityContainers.Count; }
        }

        internal IEnumerable<EntityType> EntityTypes()
        {
            return _entityTypes;
        }

        internal int EntityTypeCount
        {
            get { return _entityTypes.Count; }
        }

        internal void AddEntityType(EntityType entity)
        {
            _entityTypes.Add(entity);
        }

        internal IEnumerable<Association> Associations()
        {
            return _associations;
        }

        internal int AssociationCount
        {
            get { return _associations.Count; }
        }

        internal void AddAssociation(Association association)
        {
            _associations.Add(association);
        }

        #endregion

        #region overrides

        // we unfortunately get a warning from the compiler when we use the "base" keyword in "iterator" types generated by using the
        // "yield return" keyword.  By adding this method, I was able to get around this.  Unfortunately, I wasn't able to figure out
        // a way to implement this once and have derived classes share the implementation (since the "base" keyword is resolved at 
        // compile-time and not at runtime.
        private IEnumerable<EFObject> BaseChildren
        {
            get { return base.Children; }
        }

        internal override IEnumerable<EFObject> Children
        {
            get
            {
                foreach (var efobj in BaseChildren)
                {
                    yield return efobj;
                }

                foreach (var ec in EntityContainers())
                {
                    yield return ec;
                }

                foreach (var et in EntityTypes())
                {
                    yield return et;
                }

                foreach (var assoc in Associations())
                {
                    yield return assoc;
                }

                yield return Alias;
                yield return Namespace;
            }
        }

        protected override void OnChildDeleted(EFContainer efContainer)
        {
            var child1 = efContainer as BaseEntityContainer;
            if (child1 != null)
            {
                _entityContainers.Remove(child1);
                return;
            }

            var child2 = efContainer as EntityType;
            if (child2 != null)
            {
                _entityTypes.Remove(child2);
                return;
            }

            var child3 = efContainer as Association;
            if (child3 != null)
            {
                _associations.Remove(child3);
                return;
            }

            base.OnChildDeleted(efContainer);
        }

#if DEBUG
        internal override ICollection<string> MyAttributeNames()
        {
            var s = base.MyAttributeNames();
            s.Add(AttributeAlias);
            s.Add(AttributeNamespace);
            return s;
        }
#endif

#if DEBUG
        internal override ICollection<string> MyChildElementNames()
        {
            var s = base.MyChildElementNames();
            s.Add(BaseEntityContainer.ElementName);
            s.Add(EntityType.ElementName);
            s.Add(Association.ElementName);
            return s;
        }
#endif

        protected override void PreParse()
        {
            Debug.Assert(State != EFElementState.Parsed, "this object should not already be in the parsed state");

            // don't clear this collection here; the derived classes do it
            //ClearEFObjectCollection(_entityContainers);
            ClearEFObjectCollection(_associations);
            ClearEFObjectCollection(_entityTypes);

            ClearEFObject(_aliasAttr);
            _aliasAttr = null;
            ClearEFObject(_namespaceAttr);
            _namespaceAttr = null;

            base.PreParse();
        }

        internal override bool ParseSingleElement(ICollection<XName> unprocessedElements, XElement elem)
        {
            // EntityContainer elements are treated differently depending
            // whether we are in an SSDL EntityModel or a CSDL EntityModel
            // so do not include here

            if (elem.Name.LocalName == EntityType.ElementName)
            {
                EntityType et = null;
                if (IsCSDL)
                {
                    et = new ConceptualEntityType(this as ConceptualEntityModel, elem);
                }
                else
                {
                    et = new StorageEntityType(this as StorageEntityModel, elem);
                }
                _entityTypes.Add(et);
                et.Parse(unprocessedElements);
            }
            else if (elem.Name.LocalName == Association.ElementName)
            {
                var assoc = new Association(this, elem);
                _associations.Add(assoc);
                assoc.Parse(unprocessedElements);
            }
            else
            {
                return base.ParseSingleElement(unprocessedElements, elem);
            }
            return true;
        }

        protected override void DoNormalize()
        {
            NormalizedName = new Symbol(Namespace.Value);
            base.DoNormalize();
        }

        #endregion

        // virtual to allow mocking
        internal virtual BaseEntityContainer FirstEntityContainer
        {
            get
            {
                Debug.Assert(_entityContainers.Count <= 1, "Multiple containers not supported");

                return _entityContainers.FirstOrDefault();
            }
        }

        public BaseEntityContainer EntityContainer
        {
            get { return FirstEntityContainer; }
        }

        internal override void GetXLinqInsertPosition(EFElement child, out XNode insertAt, out bool insertBefore)
        {
            AnnotatableElement.GetInsertPointForAnnotatableElements(this, out insertAt, out insertBefore);
        }

        public override IValueProperty<string> Name
        {
            get { return Alias; }
        }

        public string AliasValue
        {
            get { return Alias.Value; }
        }
    }
}