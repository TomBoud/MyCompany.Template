﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyCompany.Template.RevitAddin.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.4.0.0")]
    public sealed partial class AppStore : global::System.Configuration.ApplicationSettingsBase {
        
        private static AppStore defaultInstance = ((AppStore)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new AppStore())));
        
        public static AppStore Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("https://apps.exchange.autodesk.com/")]
        public string BaseUrl {
            get {
                return ((string)(this["BaseUrl"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("webservices/checkentitlement")]
        public string EndPoint {
            get {
                return ((string)(this["EndPoint"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("D8EF9571-6E04-4BAE-8ABA-B847117E6541")]
        public string AppId {
            get {
                return ((string)(this["AppId"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("07/09/2023 16:03:00")]
        public global::System.DateTime GraceDateTime {
            get {
                return ((global::System.DateTime)(this["GraceDateTime"]));
            }
            set {
                this["GraceDateTime"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("01:00:00")]
        public global::System.TimeSpan GraceTime {
            get {
                return ((global::System.TimeSpan)(this["GraceTime"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AuthRequired {
            get {
                return ((bool)(this["AuthRequired"]));
            }
        }
    }
}
