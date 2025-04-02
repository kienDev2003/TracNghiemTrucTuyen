using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TracNghiemTrucTuyen.Database;

namespace TracNghiemTrucTuyen.Repositories
{
	public class AccountRepository
	{
		private readonly CreateConnection _createConnection;
		public AccountRepository()
		{
			_createConnection = new CreateConnection();
		}
		public DataTable Authen(Models.Request.LoginRequest loginRequest)
		{
			string procName = "Authen";

			using(SqlConnection conn = _createConnection.Create())
			{
				conn.Open();

				using(SqlCommand cmd = new SqlCommand(procName, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@username", loginRequest.UserName);
					cmd.Parameters.AddWithValue("@password", loginRequest.Password);

					using(SqlDataAdapter adapter = new SqlDataAdapter(cmd))
					{
						DataTable data = new DataTable();
						adapter.Fill(data);
						return data;
					}
				}
			}
		}
	}
}