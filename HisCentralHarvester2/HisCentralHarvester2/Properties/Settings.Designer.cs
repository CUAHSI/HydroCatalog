﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HisCentralHarvester2.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://water.sdsc.edu/wateroneflow/NWIS/DailyValues.asmx")]
        public string HisCentralHarvester2_waterml_10_WaterOneFlow {
            get {
                return ((string)(this["HisCentralHarvester2_waterml_10_WaterOneFlow"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://watershed.uta.edu/dallas_tarrant_co_mpe_hourly/cuahsi_1_1.asmx")]
        public string HisCentralHarvester2_waterml_11_WaterOneFlow {
            get {
                return ((string)(this["HisCentralHarvester2_waterml_11_WaterOneFlow"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://icewater.usu.edu/littlebearriver/cuahsi_1_0.asmx")]
        public string HisCentralHarvester2_waterml_10_old_WaterOneFlow {
            get {
                return ((string)(this["HisCentralHarvester2_waterml_10_old_WaterOneFlow"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("../../../logfiles/")]
        public string outpath {
            get {
                return ((string)(this["outpath"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=kyle.ucsd.edu,1433;Initial Catalog=HISCentral_dev;User id=hiscentralU" +
            "ser;password=im2nopploki")]
        public string constring {
            get {
                return ((string)(this["constring"]));
            }
        }
    }
}