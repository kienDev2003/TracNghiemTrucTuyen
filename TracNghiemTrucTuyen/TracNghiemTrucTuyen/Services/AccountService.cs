using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TracNghiemTrucTuyen.Repositories;

namespace TracNghiemTrucTuyen.Services
{
	public class AccountService
	{
		private readonly AccountRepository _accountRepository;
		public AccountService()
		{
			_accountRepository = new AccountRepository();
		}
		public Models.Response.AccountResponse Authen(Models.Request.LoginRequest loginRequest)
		{
			Models.Response.AccountResponse accountResponse = new Models.Response.AccountResponse();

			DataTable data = _accountRepository.Authen(loginRequest);

			if (data.Rows.Count <= 0) return null;

			foreach(DataRow row in data.Rows)
			{
				accountResponse.AccountID = Convert.ToInt32(row[0]);
				accountResponse.AccountType = row[1].ToString();
			}

			return accountResponse;
		}
	}
}