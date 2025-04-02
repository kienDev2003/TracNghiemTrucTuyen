using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TracNghiemTrucTuyen.Database;

namespace TracNghiemTrucTuyen.Repositories
{
	public class ProctorRepository
	{
		private readonly CreateConnection _createConnection;
		public ProctorRepository()
		{
			_createConnection = new CreateConnection();
		}
		public DataTable GetAll()
		{
			string procName = "GetUpcomingSubject";
			using(SqlConnection conn = _createConnection.Create())
			{
				conn.Open();

				using(SqlCommand cmd = new SqlCommand(procName, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

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