using Aur.AspNetCore.Mvc.Modularity.Plugin.Models;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Runtime.Loader;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Hosting;

namespace Aur.AspNetCore.Mvc.Modularity.Plugin
{
    public class PluginFactory : List<IPlugin>
    {
        private String SourcePath;

        public Dictionary<string, IPlugin> PluginMap;

        public PluginFactory(String Path)
        {
            SourcePath = Path;
            PluginMap = new Dictionary<string, IPlugin>();
        }



        public void Load(IServiceCollection services)
        {
            if (Directory.Exists(SourcePath))
            {
                var aa = Directory.GetFiles(SourcePath, "*.dll").Where((x) => !x.Contains(".Views.dll"));
                foreach (string dlls in aa)
                {
                    Assembly a = Assembly.LoadFile(dlls);
                    TypeInfo c;
                    try
                    {
                        c = a.DefinedTypes.Where((b) => b.ImplementedInterfaces.Where(bb => bb == typeof(IPlugin)).Count() > 0).First();
                    }
                    catch (Exception e)
                    {
                        throw new Exception("PluginsManager: " + dlls + " not contains a definition for " + typeof(IPlugin).Name);
                    }
                    if (c != null)
                    {
                        IPlugin Plugin = (IPlugin)a.CreateInstance(c.FullName);
                        PluginMap.Add(dlls, Plugin);
                    }
                    else
                        throw new Exception("PluginsManager: " + dlls + " not contains a definition for " + typeof(IPlugin).Name);
                }
            }
            else
                throw new Exception("PluginsManager: no Plugins folder found");

            foreach (var Index in PluginMap)
            {
                switch (Index.Value.ViewsTypeResouces)
                {

                    case Enums.ViewsTypeResouces.Assembly:
                        string ViewAssembypath = Index.Key.Replace(".dll", ".Views.dll");
                        if (File.Exists(ViewAssembypath))
                        {
                            services.AddMvc().ConfigureApplicationPartManager(apm =>
                            {
                                foreach (var b in new CompiledRazorAssemblyApplicationPartFactory().GetApplicationParts(AssemblyLoadContext.Default.LoadFromAssemblyPath(ViewAssembypath)))
                                    apm.ApplicationParts.Add(b);
                            });
                        }
                        else
                            throw new Exception("PluginsManager: no Plugin View Assembly found: " + ViewAssembypath);
                        break;
                    case Enums.ViewsTypeResouces.Embedded:
                        var embeddedFileProvider = new EmbeddedFileProvider(AssemblyLoadContext.Default.LoadFromAssemblyPath(Index.Key));
                        services.Configure<RazorViewEngineOptions>(options => { options.FileProviders.Add(embeddedFileProvider); });
                        break;
                    case Enums.ViewsTypeResouces.FileSystem:
                        throw new NotImplementedException();
                        break;
                    case Enums.ViewsTypeResouces.None:
                        break;
                    default:
                        break;
                }
                switch (Index.Value.ControllerTypeResouces)
                {
                    case Enums.ControllerTypeResouces.Assembly:
                        services.AddMvc().ConfigureApplicationPartManager(apm => apm.ApplicationParts.Add(new AssemblyPart(AssemblyLoadContext.Default.LoadFromAssemblyPath(Index.Key))));
                        break;
                    case Enums.ControllerTypeResouces.None:
                        break;
                    default:
                        break;
                }
            }
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            foreach (IPlugin Plugin in PluginMap.Select((x) => x.Value).Where((x) => x.PropertyFactory.ContainsProperty(Config.Enums.PropertyType.NeedConfigure)))
                foreach (Config.Propertys.NeedConfigureProperty Property in Plugin.PropertyFactory.Where((x) => x.Type == Config.Enums.PropertyType.NeedConfigure))
                    Property.ConfigureProperty(app, env);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            foreach (IPlugin Plugin in PluginMap.Select((x) => x.Value).Where((x) => x.PropertyFactory.ContainsProperty(Config.Enums.PropertyType.NeedConfigureServices)))
                foreach (Config.Propertys.NeedConfigureServicesProperty Property in Plugin.PropertyFactory.Where((x) => x.Type == Config.Enums.PropertyType.NeedConfigureServices))
                    Property.ConfigureProperty(services);
        }
    }
}
