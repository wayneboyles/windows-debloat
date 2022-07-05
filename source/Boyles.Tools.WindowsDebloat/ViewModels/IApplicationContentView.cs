using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boyles.Tools.WindowsDebloat.ViewModels
{
    internal interface IApplicationContentView
    {
        string Name { get; }

        ApplicationNavigationGroup Group { get; }

        bool IsLoading { get; set; }

        void Init();
    }
}
