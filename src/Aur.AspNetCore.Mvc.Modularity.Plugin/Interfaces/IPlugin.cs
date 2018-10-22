using Aur.AspNetCore.Mvc.Modularity.Plugin.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aur.AspNetCore.Mvc.Modularity.Plugin.Models
{
    public interface IPlugin
    {
        string Name { get; }
        ViewsTypeResouces ViewsTypeResouces { get; }
        ControllerTypeResouces ControllerTypeResouces { get; }
    }
}
