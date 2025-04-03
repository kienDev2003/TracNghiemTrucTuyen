using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TracNghiemTrucTuyen.Repositories;

namespace TracNghiemTrucTuyen.Services
{
    public class AnswerService
    {
        private readonly AnswerRepository _answerRepository;
        public AnswerService()
        {
            _answerRepository = new AnswerRepository();
        }
        public List<Models.Response.AnswerResponse> GetAnswers(int questionID)
        {
            List<Models.Response.AnswerResponse> answers = new List<Models.Response.AnswerResponse>();

            DataTable data = _answerRepository.GetAnswerByQuestionID(questionID);

            if (data.Rows.Count <= 0) return null;

            foreach (DataRow row in data.Rows)
            {
                answers.Add(new Models.Response.AnswerResponse
                {
                    AnswerID = Convert.ToInt32(row[0]),
                    QuestionID = Convert.ToInt32(row[1]),
                    IsTrue = Convert.ToBoolean(row[2]),
                    _Content = row[3].ToString(),
                });
            }

            return answers;
        }

        public void AddAnswer(Models.Request.AnswerRequest answer)
        {
            _answerRepository.AddAnswer(answer);
        }
    }
}