//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParamReloader.GameHook {
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
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ParamReloader.GameHook.Resource", typeof(Resource).Assembly);
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
        ///   Looks up a localized string similar to 0:  48 b9 fe fe fe fe fe    movabs rcx,0xfefefefefefefefe
        ///7:  fe fe fe
        ///a:  48 8b 09                mov    rcx,QWORD PTR [rcx]
        ///d:  ba 01 00 00 00          mov    edx,0x1
        ///12: 48 83 ec 38             sub    rsp,0x38
        ///16: 49 be fe fe fe fe fe    movabs r14,0xfefefefefefefefe
        ///1d: fe fe fe
        ///20: 41 ff d6                call   r14
        ///23: 48 83 c4 38             add    rsp,0x38
        ///27: c3                      ret .
        /// </summary>
        internal static string BonfireWarp {
            get {
                return ResourceManager.GetString("BonfireWarp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 0:  ba fe fe fe fe          mov    edx,0xfefefefe
        ///5:  41 b9 fe fe fe fe       mov    r9d,0xfefefefe
        ///b:  41 b8 fe fe fe fe       mov    r8d,0xfefefefe
        ///11: 41 bc fe fe fe fe       mov    r12d,0xfefefefe
        ///17: 48 a1 fe fe fe fe fe    movabs rax,ds:0xfefefefefefefefe
        ///1e: fe fe fe
        ///21: c6 44 24 38 01          mov    BYTE PTR [rsp+0x38],0x1
        ///26: 40 88 7c 24 30          mov    BYTE PTR [rsp+0x30],dil
        ///2b: c6 44 24 28 01          mov    BYTE PTR [rsp+0x28],0x1
        ///30: 4c 8b 78 10             mov    r15,QWORD PTR [rax+0x10]
        /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string GetItem {
            get {
                return ResourceManager.GetString("GetItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 0:  48 ba 00 00 00 00 ff    movabs rdx,0xffffffff00000000
        ///7:  ff ff ff
        ///a:  48 b9 00 00 00 00 ff    movabs rcx,0xffffffff00000000
        ///11: ff ff ff
        ///14: 48 83 ec 38             sub    rsp,0x38
        ///18: 49 be 20 99 68 40 01    movabs r14,0x140689920
        ///1f: 00 00 00
        ///22: 41 ff d6                call   r14
        ///25: 48 83 c4 38             add    rsp,0x38
        ///29: c3                      ret .
        /// </summary>
        internal static string LevelUp {
            get {
                return ResourceManager.GetString("LevelUp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 0:  48 b9 98 b0 d1 41 01    movabs rcx,0x141d1b098
        ///7:  00 00 00
        ///a:  48 8b 09                mov    rcx,QWORD PTR [rcx]
        ///d:  48 83 c1 08             add    rcx,0x8
        ///11: 48 ba 00 00 00 00 00    movabs rdx,[$0x122]
        ///18: 00 00 00
        ///1b: 49 be 10 64 51 40 01    movabs r14,0x140516410
        ///22: 00 00 00
        ///25: 48 83 ec 28             sub    rsp,0x28
        ///29: 41 ff d6                call   r14
        ///2c: 48 83 c4 28             add    rsp,0x28
        ///30: 48 b9 98 b0 d1 41 01    movabs rcx,0x141d1b098
        ///37: 00 00 00
        ///3a: 48 8b 09          [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ParamReload {
            get {
                return ResourceManager.GetString("ParamReload", resourceCulture);
            }
        }
    }
}
