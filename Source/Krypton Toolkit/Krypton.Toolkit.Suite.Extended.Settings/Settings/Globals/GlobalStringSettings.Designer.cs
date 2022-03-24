﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Krypton.Toolkit.Suite.Extended.Settings.Settings.Globals {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.0.1.0")]
    internal sealed partial class GlobalStringSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static GlobalStringSettings defaultInstance = ((GlobalStringSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new GlobalStringSettings())));
        
        public static GlobalStringSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string BasePaletteMode {
            get {
                return ((string)(this["BasePaletteMode"]));
            }
            set {
                this["BasePaletteMode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("This will become informative...")]
        public string FeedbackText {
            get {
                return ((string)(this["FeedbackText"]));
            }
            set {
                this["FeedbackText"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string PaletteExportPath {
            get {
                return ((string)(this["PaletteExportPath"]));
            }
            set {
                this["PaletteExportPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string HashReadableFileTypesFilterList {
            get {
                return ((string)(this["HashReadableFileTypesFilterList"]));
            }
            set {
                this["HashReadableFileTypesFilterList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string HashFileTypeExtensionList {
            get {
                return ((string)(this["HashFileTypeExtensionList"]));
            }
            set {
                this["HashFileTypeExtensionList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>MD5 Files</string>
  <string>RIPEMD-160 Files</string>
  <string>SHA-1 Files</string>
  <string>SHA-256 Files</string>
  <string>SHA-384 Files</string>
  <string>SHA-512 Files</string>
  <string>All Files</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection HashReadableFileTypesFilterListCollection {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["HashReadableFileTypesFilterListCollection"]));
            }
            set {
                this["HashReadableFileTypesFilterListCollection"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>.md5</string>
  <string>.ripemd160</string>
  <string>.sha1</string>
  <string>.sha256</string>
  <string>.sha384</string>
  <string>.sha512</string>
  <string>*.*</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection HashFileTypeExtensionListCollection {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["HashFileTypeExtensionListCollection"]));
            }
            set {
                this["HashFileTypeExtensionListCollection"] = value;
            }
        }
    }
}
