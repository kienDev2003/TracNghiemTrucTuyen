using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TracNghiemTrucTuyen.Database;

namespace TracNghiemTrucTuyen.Repositories
{
	public class QuestionRepository
	{
        private readonly CreateConnection _createConnection;
        public QuestionRepository()
        {
            _createConnection = new CreateConnection();
        }
        public DataTable GetQuestionByID(int questionID)
        {
            string procName = "GetQuestionByQuestionID";

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

        public int AddQuestionReturnID(Models.Request.QuestionRequest question)
        {
            string procName = "AddQuestion";

            using (SqlConnection conn = _createConnection.Create())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(procName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@_Content", question._Content);
                    cmd.Parameters.AddWithValue("@subjectID", question.SubjectID);
                    cmd.Parameters.AddWithValue("@isFromExam", question.IsFromExam);
                    cmd.Parameters.AddWithValue("@questionType", question.QuestionType);
                    cmd.Parameters.AddWithValue("@questionImage", question.Image);


                    SqlParameter outputIdParam = new SqlParameter("@questionID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputIdParam);

                    cmd.ExecuteNonQuery();

                    return Convert.ToInt32(outputIdParam.Value);
                }
            }
        }
    }
}