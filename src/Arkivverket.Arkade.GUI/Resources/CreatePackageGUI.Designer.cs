﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Arkivverket.Arkade.GUI.Languages {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class CreatePackageGUI {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CreatePackageGUI() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Arkivverket.Arkade.GUI.Resources.CreatePackageGUI", typeof(CreatePackageGUI).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create package.
        /// </summary>
        public static string CreatePackageButtonText {
            get {
                return ResourceManager.GetString("CreatePackageButtonText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IP and metadata created at .
        /// </summary>
        public static string IPandMetadataSuccessfullyCreatedStatusMessage {
            get {
                return ResourceManager.GetString("IPandMetadataSuccessfullyCreatedStatusMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to AIP.
        /// </summary>
        public static string PackageTypeAIP {
            get {
                return ResourceManager.GetString("PackageTypeAIP", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SIP.
        /// </summary>
        public static string PackageTypeSIP {
            get {
                return ResourceManager.GetString("PackageTypeSIP", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Choose package type.
        /// </summary>
        public static string SelectTypeLabel {
            get {
                return ResourceManager.GetString("SelectTypeLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter metadata and create package.
        /// </summary>
        public static string WindowTitle {
            get {
                return ResourceManager.GetString("WindowTitle", resourceCulture);
            }
        }
    }
}
