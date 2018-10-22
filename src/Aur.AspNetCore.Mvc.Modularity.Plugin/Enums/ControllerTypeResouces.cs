using System;
using System.Collections.Generic;
using System.Text;

namespace Aur.AspNetCore.Mvc.Modularity.Plugin.Enums
{
    /// <summary>
    /// determine how to access the plugin controllers
    /// </summary>
    public enum ControllerTypeResouces
    {
        /// <summary>
        /// Load controlles from Assemby file, path default: {absopute path of progect}/{plugin folder}/**/*.dll
        /// </summary>
        Assembly,
        /// <summary>
        /// not load a controller.
        /// </summary>
        None
    }
}
