﻿//*************************************************************************************************
// WARNING:
// *** AUTOMATICALLY GENERATED by ResourceClassGenerator from ..\Common\Resources.resx ***
// DO NOT MODIFY THIS FILE, IT WILL BE OVERWRITTEN BY THE BUILD SYSTEM
// This class contains strongly typed wrappers for resources in ..\Common\Resources.resx
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//*************************************************************************************************

namespace Microsoft.VisualStudio.TestTools.HostAdapters.VsIde {

using System;
using System.Resources;
using System.Diagnostics;
using System.Globalization;

/// <summary>
/// Strongly typed resource wrappers generated from ..\Common\Resources.resx.
/// </summary>
internal class Resources
{
    internal static readonly ResourceManager ResourceManager = new ResourceManager(typeof(Resources));

    /// <summary>
    /// Timed out getting VsIdeTestHostAddin from Visual Studio. Please make sure that the add-in is installed and started when VS starts (use Tools-&gt;AddinManager).
    /// </summary>
    public static string TimedOutGettingAddin
    {
        get
        {
            string temp = ResourceManager.GetString("TimedOutGettingAddin", CultureInfo.CurrentUICulture);
            return temp;
        }
    }

    /// <summary>
    /// Cannot find specified process.
    /// </summary>
    public static string CannotFindProcess
    {
        get
        {
            string temp = ResourceManager.GetString("CannotFindProcess", CultureInfo.CurrentUICulture);
            return temp;
        }
    }

    /// <summary>
    /// Incorrect value of Visual Studio version in .testrunconfig file: '{0}'. Latest version '{1}' will be used.
    /// </summary>
    public static string WrongVSVersionPassedToRunConfigControl(object param0, object param1)
    {
        string temp = ResourceManager.GetString("WrongVSVersionPassedToRunConfigControl", CultureInfo.CurrentUICulture);
        return string.Format(CultureInfo.CurrentCulture, temp, param0, param1);
    }

    /// <summary>
    /// Microsoft Visual Studio
    /// </summary>
    public static string MicrosoftVisualStudio
    {
        get
        {
            string temp = ResourceManager.GetString("MicrosoftVisualStudio", CultureInfo.CurrentUICulture);
            return temp;
        }
    }

    /// <summary>
    /// Cannot find installation of Visual Studio in '{0}' registry hive.
    /// </summary>
    public static string CannotFindVSInstallation(object param0)
    {
        string temp = ResourceManager.GetString("CannotFindVSInstallation", CultureInfo.CurrentUICulture);
        return string.Format(CultureInfo.CurrentCulture, temp, param0);
    }

    /// <summary>
    /// Warning: VS IDE Host Adapter failed to call ITestAdapter.Cleanup: {0}
    /// </summary>
    public static string FailedToCallTACleanup(object param0)
    {
        string temp = ResourceManager.GetString("FailedToCallTACleanup", CultureInfo.CurrentUICulture);
        return string.Format(CultureInfo.CurrentCulture, temp, param0);
    }

    /// <summary>
    /// Warning: VS IDE Host Adapter failed to detach debugger: {0}
    /// </summary>
    public static string FailedToDetachDebugger(object param0)
    {
        string temp = ResourceManager.GetString("FailedToDetachDebugger", CultureInfo.CurrentUICulture);
        return string.Format(CultureInfo.CurrentCulture, temp, param0);
    }

    /// <summary>
    /// Warning: VS IDE Host Adapter: error shutting down VS IDE: {0}
    /// </summary>
    public static string ErrorShuttingDownVS(object param0)
    {
        string temp = ResourceManager.GetString("ErrorShuttingDownVS", CultureInfo.CurrentUICulture);
        return string.Format(CultureInfo.CurrentCulture, temp, param0);
    }

    /// <summary>
    /// Visual Studio Registry Hive
    /// </summary>
    public static string VSRegistryHive
    {
        get
        {
            string temp = ResourceManager.GetString("VSRegistryHive", CultureInfo.CurrentUICulture);
            return temp;
        }
    }

    /// <summary>
    /// Failed to start Visual Studio process.
    /// </summary>
    public static string FailedToStartVSProcess
    {
        get
        {
            string temp = ResourceManager.GetString("FailedToStartVSProcess", CultureInfo.CurrentUICulture);
            return temp;
        }
    }

    /// <summary>
    /// Warning: timed out calling Dte.Quit: all the calls were rejected. Visual Studio process will be killed.
    /// </summary>
    public static string TimedOutWaitingDteQuit
    {
        get
        {
            string temp = ResourceManager.GetString("TimedOutWaitingDteQuit", CultureInfo.CurrentUICulture);
            return temp;
        }
    }

    /// <summary>
    /// Visual Studio process exited unexpectedly.
    /// </summary>
    public static string VSExitedUnexpectedly
    {
        get
        {
            string temp = ResourceManager.GetString("VSExitedUnexpectedly", CultureInfo.CurrentUICulture);
            return temp;
        }
    }

    /// <summary>
    /// Timed out getting VS.DTE from COM Running Object Table.
    /// </summary>
    public static string TimedOutGettingDteFromRot
    {
        get
        {
            string temp = ResourceManager.GetString("TimedOutGettingDteFromRot", CultureInfo.CurrentUICulture);
            return temp;
        }
    }

    /// <summary>
    /// Host Adapter that allows to run tests inside Visual Studio
    /// </summary>
    public static string HostAdapterDescription
    {
        get
        {
            string temp = ResourceManager.GetString("HostAdapterDescription", CultureInfo.CurrentUICulture);
            return temp;
        }
    }

    /// <summary>
    /// VS IDE Test Host Configuration Data
    /// </summary>
    public static string RunConfigDataDescription
    {
        get
        {
            string temp = ResourceManager.GetString("RunConfigDataDescription", CultureInfo.CurrentUICulture);
            return temp;
        }
    }

    /// <summary>
    /// Additional command line arguments
    /// </summary>
    public static string AdditionalCommandLine
    {
        get
        {
            string temp = ResourceManager.GetString("AdditionalCommandLine", CultureInfo.CurrentUICulture);
            return temp;
        }
    }

    /// <summary>
    /// Additional Test Data
    /// </summary>
    public static string AdditionalTestData
    {
        get
        {
            string temp = ResourceManager.GetString("AdditionalTestData", CultureInfo.CurrentUICulture);
            return temp;
        }
    }

    /// <summary>
    /// Failed to register the message filter.
    /// </summary>
    public static string FailedToRegisterMessageFilter
    {
        get
        {
            string temp = ResourceManager.GetString("FailedToRegisterMessageFilter", CultureInfo.CurrentUICulture);
            return temp;
        }
    }

    /// <summary>
    /// Timed out waiting for VS IDE to respond.
    /// </summary>
    public static string TimedOutCommunicatingToIde
    {
        get
        {
            string temp = ResourceManager.GetString("TimedOutCommunicatingToIde", CultureInfo.CurrentUICulture);
            return temp;
        }
    }
}

}   // namespace