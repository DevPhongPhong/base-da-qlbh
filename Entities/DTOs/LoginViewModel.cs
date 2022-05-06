using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTOs
{
    public class LoginViewModel
    {
		[Required]
		[DisplayName("Tên đăng nhập")]
		public string Username { get; set; }
		[Required]
		[DisplayName("Mật khẩu")]
		public string Password { get; set; }
		[DisplayName("Ghi nhớ đăng nhập")]
		public bool RememberMe { get; set; }
	}
}
