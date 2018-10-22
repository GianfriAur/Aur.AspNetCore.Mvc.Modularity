using System;
using System.Collections.Generic;
using System.Text;

namespace Aur.AspNetCore.Mvc.Modularity.Plugin.Enums
{
    /// <summary>
    /// determine how to access the plugin views
    /// </summary>
    public enum ViewsTypeResouces
    {
        /// <summary>
        /// Load views from Assemby file, path default: {absopute path of progect}/{plugin folder}/**/*.Views.dll
        /// </summary>
        Assembly,
        /// <summary>
        /// Load views from embedded resouce, path dafault:{absopute path of progect}/{plugin folder}/**/*.dll
        /// </summary>
        Embedded,
        /// <summary>
        /// Load views from file sistem path dafault:{absopute path of progect}/{plugin folder}/**/Views/*.cshtml
        /// </summary>
        FileSystem,
        /// <summary>
        /// not load a views.
        /// </summary>
        None
    }
}
