using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Aur.AspNetCore.Mvc.Modularity.Config;
using Aur.AspNetCore.Mvc.Modularity.Plugin.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Aur.AspNetCore.Mvc.Modularity.Config.Propertys;

namespace Aur.AspNetCore.Mvc.Modularity.Plugin.Models
{
    public abstract class BasicPlugin : IPlugin
    {
        public abstract string Name { get; }

        public abstract ViewsTypeResouces ViewsTypeResouces { get; }

        public abstract ControllerTypeResouces ControllerTypeResouces { get; }

        private PropertyFactory _PropertyFactory { get; set; }

        public PropertyFactory PropertyFactory { get { if (_PropertyFactory == null) _PropertyFactory = new PropertyFactory(); return _PropertyFactory; } }

    }
}

