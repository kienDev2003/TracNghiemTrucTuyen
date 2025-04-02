using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TracNghiemTrucTuyen.Models.Response;
using TracNghiemTrucTuyen.Services;

namespace TracNghiemTrucTuyen.Views.home.subject.assessments.exams
{
	public partial class edit : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Request.QueryString["testID"] != null)
			{
				//LoadContentTestByID(Convert.ToInt32(Request.QueryString["testID"]));
			}
		}

        [WebMethod]
        public static object LoadContentTestByID(int test_id)
        {
			Models.Response.ExamResponse exam = new Models.Response.ExamResponse();
			TestService testService = new TestService();
            TestDetailService testDetailService = new TestDetailService();
            QuestionService questionService = new QuestionService();
            AnswerService answerService = new AnswerService();

            exam = testService.GetTestByID(test_id);

			if (exam == null) return "";

			List<Models.Response.TestDetailResponse> testDetails = new List<Models.Response.TestDetailResponse>();
			testDetails = testDetailService.GetTestDetails(exam.TestID);

			var ExamData = new
			{
				Name = exam.TestName,
                Duration = exam.Duration,
                Questions = testDetails.Select(testDetail =>
				{
                    QuestionResponse question = questionService.GetQuestionByID(testDetail.QuestionID);
                    List<AnswerResponse> answers = answerService.GetAnswers(question.QuestionID);

                    return new
                    {
                        content = question._Content,
                        image = question.QuestionImage,
                        questionType = question.QuestionType,
                        answers = answers.Select(answer => new
                        {
                            content = answer._Content,
                            isTrue = answer.IsTrue
                        }).ToList()
                    };
                })
            };

            return ExamData;
        }
    }
}