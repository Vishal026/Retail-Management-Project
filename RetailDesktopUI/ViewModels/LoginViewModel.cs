using Caliburn.Micro;
using RetailDesktopUI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailDesktopUI.ViewModels
{
    class LoginViewModel :Screen
    {
		private string  _username;
		private string  _password;

		private IAPIHelper _apicall;
		public LoginViewModel(IAPIHelper apicall)
		{
			_apicall = apicall;
		}
		public  string Username
		{
			get { return _username; }

			set {
				_username = value;
				NotifyOfPropertyChange(()=>Username);
				NotifyOfPropertyChange(() => CanLogin);

			}
		}


		public  string Password
		{
			get { return _password; }
			set {
				_password = value;
				NotifyOfPropertyChange(()=>Password);
				NotifyOfPropertyChange(()=>CanLogin);
			}
		}

		public bool CanLogin
		{
			get
			{
				bool output = false;

				if(Username?.Length>0 && Password?.Length>0)
				{
					return output=true;
				}
				return output;

			}
		}


		//public bool CanLogIn(string username, string password)
		//{
		//	bool output = false;

		//	if (Username?.Length > 0 && Password?.Length > 0)
		//	{
		//		output = true;

		//	}
		//	return output;
		//}

		// caliburn.micro wires up the login by seein Canlogin i Notify
		//passing (string username, string password) to a login button helps us to debug weather these values are coming or not 
		// no need to send the parameter we are already cathing the values in the paramer

		public async Task Login()  
		{
			try
			{
				var result = await _apicall.Authenticate(Username, Password);
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
			}
		}

	}
}
