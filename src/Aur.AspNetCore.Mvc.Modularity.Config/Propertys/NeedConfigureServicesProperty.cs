using Aur.AspNetCore.Mvc.Modularity.Config.Enums;
using Aur.AspNetCore.Mvc.Modularity.Config.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aur.AspNetCore.Mvc.Modularity.Config.Propertys
{
    public class NeedConfigureServicesProperty : IPropertysBase
    {
        #region Interface implementation

        public PropertyType Type => PropertyType.NeedConfigureServices;
        public string Name => Type.ToString();
        private bool _applied { get; set; }
        public bool applied => _applied;
        private Exception _Error { get; set; }
        public Exception Error => _Error;

        #endregion

        private Func<IServiceCollection, bool> _ConfigureServices;

        public NeedConfigureServicesProperty(Func<IServiceCollection, bool> ConfigureServices)
        {
            _ConfigureServices = ConfigureServices;
            _Error = null;
        }

        public void ConfigureProperty(IServiceCollection services)
        {
            try
            {
                _ConfigureServices(services);
            }
            catch (Exception e) { _Error = e; }
            finally { _applied = true; }
        }

        public bool haveException => _Error != null;
    }
}
