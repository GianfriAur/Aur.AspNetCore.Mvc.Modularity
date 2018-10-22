using Aur.AspNetCore.Mvc.Modularity.Config.Enums;
using Aur.AspNetCore.Mvc.Modularity.Config.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aur.AspNetCore.Mvc.Modularity.Config.Propertys
{
    class CostumProperty<T> : IPropertysBase<PropertyType>
    {
        #region Interface implementation

        public PropertyType Type => PropertyType.CostumProperty;
        private string _name { get; set; }
        public string Name => _name;
        private bool _applied { get; set; }
        public bool applied => _applied;
        private Exception _Error { get; set; }
        public Exception Error => _Error;
        public T Value { get; set; }

        #endregion

        private Action _CustomappliedTest;

        public CostumProperty(T value, Action appliedTest, string name)
        {
            _name = name;
            Value = value;
            _CustomappliedTest = appliedTest;
            _Error = null;
        }
        public CostumProperty(T value, string name) : this(value, null, name) { }
        public CostumProperty(T value, Action appliedTest) : this(value, appliedTest, PropertyType.CostumProperty.ToString()) { }
        public CostumProperty(T value) : this(value, null, PropertyType.CostumProperty.ToString()) { }

        public void appliedTest()
        {
            try
            {
                if (_CustomappliedTest != null)
                    _CustomappliedTest();
            }
            catch (Exception e) { _Error = e; }
            finally { _applied = true; }
        }

    }
}
