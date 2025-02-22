using POSLib.Model;
using POSWPFSaleProject.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace POSWPFSaleProject.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public IObservable<User> users { get; set; }

        public LoginViewModel()
        {

        }

        private User selecteduser;

        public User Selecteduser
        {
            get { return selecteduser; }
            set
            {
                selecteduser = value;
                OnPropertyChanged();
            }
        }
      
    }
}
