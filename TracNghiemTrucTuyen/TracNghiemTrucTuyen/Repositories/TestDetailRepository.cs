using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TracNghiemTrucTuyen.Database;

namespace TracNghiemTrucTuyen.Repositories
{
	public class TestDetailRepository
	{
		private readonly CreateConnection _createConnection;
		public TestDetailRepository()
		{
			_createConnection = new CreateConnection();
		}
		public DataTable GetTestDetails(int testID)
		{
            string procName = "GetQuestionByTestID";

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

        public void AddTestDetail(Models.Response.TestDetailResponse testDetail)
        {
            string procName = "AddTestDetail";

            using (SqlConnection conn = _createConnection.Create())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(procName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@questionID", testDetail.QuestionID);
                    cmd.Parameters.AddWithValue("@testID", testDetail.TestID);

                    cmd.ExecuteNonQuery();
                }
            }
        }
	}
}