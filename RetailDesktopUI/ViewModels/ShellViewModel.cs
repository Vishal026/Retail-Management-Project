using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailDesktopUI.ViewModels
{
    class ShellViewModel : Conductor<object>
    {
        private LoginViewModel _LoginVM;
        public ShellViewModel(LoginViewModel LoginVM)
        {
            _LoginVM = LoginVM;
            ActivateItem(_LoginVM);
        }
    }
}
