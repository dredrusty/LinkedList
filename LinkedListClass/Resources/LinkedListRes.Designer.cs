﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VV.DataStructure.LinkedList.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class LinkedListRes {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LinkedListRes() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("VV.DataStructure.LinkedList.Resources.LinkedListRes", typeof(LinkedListRes).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Collection is null..
        /// </summary>
        internal static string ArgumentNullExceptionText {
            get {
                return ResourceManager.GetString("ArgumentNullExceptionText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You are trying to clear empty LinkedList..
        /// </summary>
        internal static string ArgumentOutOfRangeExceptionClearMethodText {
            get {
                return ResourceManager.GetString("ArgumentOutOfRangeExceptionClearMethodText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Copying is not possible. Check arrayIndex or receiving part of the array..
        /// </summary>
        internal static string ArgumentOutOfRangeExceptionCopyToMethodText {
            get {
                return ResourceManager.GetString("ArgumentOutOfRangeExceptionCopyToMethodText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You are trying to get non-existent element..
        /// </summary>
        internal static string ArgumentOutOfRangeExceptionText {
            get {
                return ResourceManager.GetString("ArgumentOutOfRangeExceptionText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You are not able to change this LinkedList..
        /// </summary>
        internal static string InvalidOperationExceptionText {
            get {
                return ResourceManager.GetString("InvalidOperationExceptionText", resourceCulture);
            }
        }
    }
}
