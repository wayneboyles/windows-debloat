using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boyles.Tools.WindowsDebloat.ViewModels
{
    public class ApplicationViewModel : ViewModel
    {
        private bool _isTitleBarVisible;

        public bool IsTitleBarVisible
        {
            get => _isTitleBarVisible;
            set => SetProperty(ref _isTitleBarVisible, value);
        }
    }
}
