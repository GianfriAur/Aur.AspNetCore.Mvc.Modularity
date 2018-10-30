using Aur.AspNetCore.Mvc.Modularity.Config.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Aur.AspNetCore.Mvc.Modularity.Config
{
    public class PropertyFactory : List<IPropertysBase>
    {
        
        public bool ContainsProperty(Enums.PropertyType type)
        {
            return this.Where((Property) => Property.Type == type).Count() > 0;
        }

        public new PropertyFactory Add(IPropertysBase Property)
        {
            base.Add(Property); return this;
        }

    }
}
