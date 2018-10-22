using System;
using System.Collections.Generic;
using System.Text;
using Aur.AspNetCore.Mvc.Modularity.Config.Enums;
using Aur.AspNetCore.Mvc.Modularity.Config.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Aur.AspNetCore.Mvc.Modularity.Config.Propertys
{
    public class NeedConfigureProperty : IPropertysBase<PropertyType>
    {
        #region Interface implementation

        public PropertyType Type => PropertyType.NeedConfigure;
        public string Name => Type.ToString();
        private bool _applied { get; set; }
        public bool applied => _applied;
        private Exception _Error { get; set; }
        public Exception Error => _Error;

        #endregion

        private Func<IApplicationBuilder, IHostingEnvironment, bool> _ConfigureProperty;

        public NeedConfigureProperty(Func<IApplicationBuilder, IHostingEnvironment,bool> ConfigureProperty)
        {
            _ConfigureProperty = ConfigureProperty;
            _Error = null;
        }
        public void ConfigureProperty(IApplicationBuilder app, IHostingEnvironment env)
        {
            try
            {
                _ConfigureProperty(app, env);
            }
            catch (Exception e){ _Error = e; }
            finally { _applied = true; }
        }

        public bool haveException => _Error != null;
    }
}
