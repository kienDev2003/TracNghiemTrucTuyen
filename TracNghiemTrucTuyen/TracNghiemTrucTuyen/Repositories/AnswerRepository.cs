using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TracNghiemTrucTuyen.Database;

namespace TracNghiemTrucTuyen.Repositories
{
	public class AnswerRepository
	{
        private readonly CreateConnection _createConnection;
        public AnswerRepository()
        {
            _createConnection = new CreateConnection();
        }
        public DataTable GetAnswerByQuestionID(int questionID)
        {
            string procName = "GetAnswerByQuestionID";

            using (SqlConnection conn = _createConnection.Create())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(procName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@questionID", questionID);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        return data;
                    }
                }
            }
        }

        public void AddAnswer(Models.Request.AnswerRequest answer)
        {
            string procName = "AddAnswer";

            using (SqlConnection conn = _createConnection.Create())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(procName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@_Content", answer._Content);
                    cmd.Parameters.AddWithValue("@isTrue", answer.IsTrue);
                    cmd.Parameters.AddWithValue("@questionID", answer.QuestionID);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}