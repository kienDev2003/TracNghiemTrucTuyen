using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TracNghiemTrucTuyen.Repositories;

namespace TracNghiemTrucTuyen.Services
{
	public class QuestionService
	{
        private readonly QuestionRepository _questionRepository;
        public QuestionService()
        {
            _questionRepository = new QuestionRepository();
        }
        public Models.Response.QuestionResponse GetQuestionByID(int questionID)
        {
            Models.Response.QuestionResponse question = new Models.Response.QuestionResponse();

            DataTable data = _questionRepository.GetQuestionByID(questionID);

            if (data.Rows.Count <= 0) return null;

            foreach(DataRow row in data.Rows)
            {
                question.QuestionID = Convert.ToInt32(row[0]);
                question._Content = row[1].ToString();
                question.SubjectID = row[2].ToString();
                question.IsFromExam = Convert.ToBoolean(row[4]);
                question.QuestionType = row[5].ToString();
                question.QuestionImage = row[6].ToString();
            }

            return question;
        }
    }
}