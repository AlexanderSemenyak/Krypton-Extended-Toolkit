﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Krypton.Toolkit.Suite.Extended.Settings.Settings.Palette_Explorer.General {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.5.0.0")]
    internal sealed partial class ColourIntensitySettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static ColourIntensitySettings defaultInstance = ((ColourIntensitySettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new ColourIntensitySettings())));
        
        public static ColourIntensitySettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.5")]
        public float DarkestColourIntensity {
            get {
                return ((float)(this["DarkestColourIntensity"]));
            }
            set {
                this["DarkestColourIntensity"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.25")]
        public float MediumColourIntensity {
            get {
                return ((float)(this["MediumColourIntensity"]));
            }
            set {
                this["MediumColourIntensity"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.25")]
        public float LightColourIntensity {
            get {
                return ((float)(this["LightColourIntensity"]));
            }
            set {
                this["LightColourIntensity"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.5")]
        public float LightestColourIntensity {
            get {
                return ((float)(this["LightestColourIntensity"]));
            }
            set {
                this["LightestColourIntensity"] = value;
            }
        }
    }
}
