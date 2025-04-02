using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TracNghiemTrucTuyen.Database;

namespace TracNghiemTrucTuyen.Repositories
{
	public class SubjectRepository
	{
		private readonly CreateConnection _createConnection;
		public SubjectRepository()
		{
			_createConnection = new CreateConnection();
		}
		public DataTable GetSubjectOfTaught(int accountID)
		{
			string procName = "ListOfSubjectsTaught";

			using(SqlConnection conn = _createConnection.Create())
			{
				conn.Open();

				using(SqlCommand cmd = new SqlCommand(procName, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@accountID", accountID);

					using(SqlDataAdapter adapter = new SqlDataAdapter(cmd))
					{
						DataTable data = new DataTable();
						adapter.Fill(data);
						return data;
					}
				}
			}
		}

		public DataTable GetBySubjectID(string subjectID)
		{
            string procName = "GetSubject";

            using (SqlConnection conn = _createConnection.Create())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(procName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@subjectID", subjectID);

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