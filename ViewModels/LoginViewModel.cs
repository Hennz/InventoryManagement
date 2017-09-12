using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Threading;
using InventoryManagement.Models;
using SoftArcs.WPFSmartLibrary.MVVMCommands;
using SoftArcs.WPFSmartLibrary.MVVMCore;

namespace InventoryManagement.ViewModels
{
	public class LoginViewModel : ViewModelBase, IDataErrorInfo
	{
		#region Fields

		private List<User> allUser;
		private List<string> allUserNames;

		#endregion // Fields

		#region Constructors

		public LoginViewModel()
		{
			this.IsUserAvailable = false;
			this.IsPasswordWrong = false;

			if (ViewModelHelper.IsInDesignModeStatic == false)
			{
				this.initializeAllCommands();

				this.allUser = this.getListOfAllUser();
				this.allUserNames = (from user in this.allUser
											select user.Username.ToUpper()).ToList();
			}
		}

		#endregion // Constructors

		#region Properties and corresponding fields

		#region Members of the 'IDataErrorInfo' interface and "Error Validation"

		public string Error
		{
			get { throw new NotImplementedException(); }
		}

		public string this[string propertyName]
		{
			get
			{
				string result = null;

				if (propertyName.Equals( "UserName" ))
				{
					if (String.IsNullOrEmpty( this.UserName ))
					{
						result = "An Username is strictly required !";
					}
				}
				else if (propertyName.Equals( "Password" ))
				{
					if (String.IsNullOrEmpty( this.Password ))
					{
						result = "A Password is strictly required !";
					}
				}

				return result;
			}
		}

		#endregion Members of the 'IDataErrorInfo' interface and "Error Validation"

		public string UserName
		{
			get { return GetValue( () => UserName ); }
			set { SetValue( () => UserName, value ); }
		}

		public string Password
		{
			get { return GetValue( () => Password ); }
			set { SetValue( () => Password, value ); }
		}

		public bool IsUserAvailable
		{
			get { return GetValue( () => IsUserAvailable ); }
			set { SetValue( () => IsUserAvailable, value ); }
		}

		public bool IsPasswordWrong
		{
			get { return GetValue( () => IsPasswordWrong ); }
			set { SetValue( () => IsPasswordWrong, value ); }
		}

		#endregion // Properties and corresponding fields

		#region Private Methods

		private void initializeAllCommands()
		{
			this.LoginCommand = new ActionCommand( this.ExecuteLogin, this.CanExecuteLogin );
		}

		private List<User> getListOfAllUser()
		{
			//+ Here you would implement code, which will get the user list from a database,
			//+ a webservice or from somewhere else
			return new List<User>()
							{
								new User() { Username="bill", Password="pwd"},
								new User() { Username="steve", Password="password"},
								new User() { Username="larry", Password="userpwd"}
							};
		}

		#endregion

		#region Login Command Handler

		public ICommand LoginCommand { get; private set; }

		private void ExecuteLogin(object commandParameter)
		{
			// This could be redundant, because both properties can't be empty regarding to the checks in the CanExecute-method
			// But for security reasons both properties are also checked here again
			if (this.UserName != String.Empty && this.Password != String.Empty)
			{
				var userPassword = (from user in this.allUser
										  where user.Username.ToUpper().Equals( this.UserName.ToUpper() )
										  select user.Password).First();

				if (userPassword.Equals( this.Password ))
				{
					Window window = (commandParameter as Window);

					if (window != null)
					{
						//!-------------------------------------------------
						//!------   Just for demonstration purposes   ------
						//!-------------------------------------------------
						MessageBox.Show( "Username and password correct" );

						if (ComponentDispatcher.IsThreadModal)
						{
							window.DialogResult = true;
							window.Close();
						}
					}
				}
				else
				{
					// Switch the "Wrong Password"-Flag to true for 1.5 seconds
					DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds( 1500 ) };
					timer.Tick += (os, ea) =>
													{
														this.IsPasswordWrong = false;
														timer.Stop();
													};

					this.IsPasswordWrong = true;

					timer.Start();
				}
			}
		}

		private bool CanExecuteLogin(object commandParameter)
		{
			if (this.allUserNames != null && this.UserName != null)
			{
				if (this.allUserNames.Contains( this.UserName.ToUpper() ))
				{
					this.IsUserAvailable = true;

					if (!string.IsNullOrEmpty( this.Password ))
					{
						return true;
					}
				}
				else
				{
					this.IsUserAvailable = false;

					return false;
				}
			}

			return false;
		}

		#endregion // Login Command Handler
	}
}
