﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SafetyBarriers.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.7.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string BarrierAxisElemIds {
            get {
                return ((string)(this["BarrierAxisElemIds"]));
            }
            set {
                this["BarrierAxisElemIds"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string BoundCurve1 {
            get {
                return ((string)(this["BoundCurve1"]));
            }
            set {
                this["BoundCurve1"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string BoundCurve2 {
            get {
                return ((string)(this["BoundCurve2"]));
            }
            set {
                this["BoundCurve2"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int PostIndex {
            get {
                return ((int)(this["PostIndex"]));
            }
            set {
                this["PostIndex"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2.5")]
        public double PostStep {
            get {
                return ((double)(this["PostStep"]));
            }
            set {
                this["PostStep"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool IsIncludeStartPost {
            get {
                return ((bool)(this["IsIncludeStartPost"]));
            }
            set {
                this["IsIncludeStartPost"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool IsIncludeFinishPost {
            get {
                return ((bool)(this["IsIncludeFinishPost"]));
            }
            set {
                this["IsIncludeFinishPost"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public double BeamLength {
            get {
                return ((double)(this["BeamLength"]));
            }
            set {
                this["BeamLength"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool IsReverseBeams {
            get {
                return ((bool)(this["IsReverseBeams"]));
            }
            set {
                this["IsReverseBeams"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Начало")]
        public string SelectedAlignmentSafityBarrier {
            get {
                return ((string)(this["SelectedAlignmentSafityBarrier"]));
            }
            set {
                this["SelectedAlignmentSafityBarrier"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool IsRotateOn180 {
            get {
                return ((bool)(this["IsRotateOn180"]));
            }
            set {
                this["IsRotateOn180"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection BeamCollection {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["BeamCollection"]));
            }
            set {
                this["BeamCollection"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool IsRotatePosts {
            get {
                return ((bool)(this["IsRotatePosts"]));
            }
            set {
                this["IsRotatePosts"] = value;
            }
        }
    }
}
