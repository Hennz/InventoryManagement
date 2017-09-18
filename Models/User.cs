// ReSharper disable RedundantUsingDirective
using System;
// ReSharper restore RedundantUsingDirective

namespace InventoryManagement.Models
{
	public class User
	{
        public int UserId { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
        public int RoleId { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime PasswordChangedDate { get; set; }
        public string Email { get; set; }
        public int AccessFailedCount{ get; set; }
        public DateTime LastLoginTime { get; set; }
        public bool IsDisabled { get; set; }
        public string Address { get; set; }
    }
}
