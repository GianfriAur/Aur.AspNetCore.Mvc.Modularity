using System;
using System.Collections.Generic;
using System.Text;

namespace Aur.AspNetCore.Mvc.Modularity.Config.Interfaces
{
    public interface IPropertysBase<T>
    {
        T Type { get; }
        string Name { get; }

        bool applied { get; }
        Exception Error{ get; }
    }
}
