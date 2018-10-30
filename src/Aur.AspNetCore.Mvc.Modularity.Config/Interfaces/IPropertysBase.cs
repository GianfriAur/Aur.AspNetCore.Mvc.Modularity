using System;
using System.Collections.Generic;
using System.Text;
using Aur.AspNetCore.Mvc.Modularity.Config.Enums;


namespace Aur.AspNetCore.Mvc.Modularity.Config.Interfaces
{
    public interface IPropertysBase
    {
        PropertyType Type { get; }
        string Name { get; }

        bool applied { get; }

        Exception Error{ get; }
    }
}
