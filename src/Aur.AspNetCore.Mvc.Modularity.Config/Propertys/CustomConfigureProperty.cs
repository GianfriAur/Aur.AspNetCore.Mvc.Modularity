using Aur.AspNetCore.Mvc.Modularity.Config.Enums;
using Aur.AspNetCore.Mvc.Modularity.Config.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aur.AspNetCore.Mvc.Modularity.Config.Propertys
{
    class CustomConfigureProperty : IPropertysBase<PropertyType>
    {
        #region Interface implementation

        public PropertyType Type => PropertyType.CustomConfigure;
        private string _name { get; set; }
        public string Name => _name;
        private bool _applied { get; set; }
        public bool applied => _applied;
        private Exception _Error { get; set; }
        public Exception Error => _Error;

        #endregion

        private Action _CustomConfigure;

        public CustomConfigureProperty(Action CustomConfigure,string CustomName)
        {
            _CustomConfigure = CustomConfigure;
            _name = CustomName;
            _Error = null;
        }
        public CustomConfigureProperty(Action CustomConfigure) : this( CustomConfigure, PropertyType.CustomConfigure.ToString()){}

        public void Exec()
        {
            try
            {
                _CustomConfigure();
            }
            catch (Exception e) { _Error = e; }
            finally { _applied = true; }
        }

    }
}
