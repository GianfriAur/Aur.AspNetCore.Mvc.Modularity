using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aur.AspNetCore.Mvc.Modularity;
using Aur.AspNetCore.Mvc.Modularity.Config.Propertys;
using Aur.AspNetCore.Mvc.Modularity.Plugin.Enums;
using Aur.AspNetCore.Mvc.Modularity.Plugin.Models;

namespace TEST.BasicPlugin.PluginTest1
{
    public class PluginTest1 : Aur.AspNetCore.Mvc.Modularity.Plugin.Models.BasicPlugin
    {
        public override string Name => "PluginTest1";

        public override ViewsTypeResouces ViewsTypeResouces => ViewsTypeResouces.Assembly;

        public override ControllerTypeResouces ControllerTypeResouces => ControllerTypeResouces.Assembly;

        public PluginTest1()
        {
            PropertyFactory.Add(new NeedConfigureProperty((app, env) =>
            {

            }));


            
        }
    }
}
