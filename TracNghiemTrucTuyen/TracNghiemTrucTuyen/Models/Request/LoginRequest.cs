using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TracNghiemTrucTuyen.Models.Request
{
	public class LoginRequest
	{
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}