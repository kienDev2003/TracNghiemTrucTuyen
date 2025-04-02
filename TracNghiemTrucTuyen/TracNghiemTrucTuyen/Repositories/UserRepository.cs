using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TracNghiemTrucTuyen.Database;

namespace TracNghiemTrucTuyen.Repositories
{
	public class UserRepository
	{
		private readonly CreateConnection _createConnection;
		public UserRepository()
		{
			_createConnection = new CreateConnection();
		}
		public DataTable GetUserInforByAccountID(int accountID)
		{
			string procName = "GetUserInfor";
			
			using(SqlConnection conn = _createConnection.Create())
			{
				conn.Open();

				using(SqlCommand cmd = new SqlCommand(procName, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@accountID", accountID);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
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