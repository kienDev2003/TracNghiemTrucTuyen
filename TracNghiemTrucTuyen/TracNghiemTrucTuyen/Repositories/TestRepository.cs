using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TracNghiemTrucTuyen.Database;

namespace TracNghiemTrucTuyen.Repositories
{
	public class TestRepository
	{
		private readonly CreateConnection _createConnection;
		public TestRepository()
		{
			_createConnection = new CreateConnection();
		}
		public DataTable GetExams(int accountID, string subjectID)
		{
			string procName = "GetTest";

			using(SqlConnection conn = _createConnection.Create())
			{
				conn.Open();

				using(SqlCommand cmd = new SqlCommand(procName, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@accountID", accountID);
					cmd.Parameters.AddWithValue("@subjectID", subjectID);

					using(SqlDataAdapter adapter = new SqlDataAdapter(cmd))
					{
						DataTable data = new DataTable();
						adapter.Fill(data);
						return data;
					}
				}
			}
		}

		public DataTable GetTestByID(int testID)
		{
            string procName = "GetTestByID";

            using (SqlConnection conn = _createConnection.Create())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(procName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@testID", testID);

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