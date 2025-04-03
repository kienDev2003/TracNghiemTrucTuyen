using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
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

        [WebMethod]
        public static object AddTest(Models.Request.ExamRequest examRequest)
        {
            Models.Response.AccountResponse account = HttpContext.Current.Session["Account"] as Models.Response.AccountResponse;
            string subjectID = HttpContext.Current.Request.QueryString["subjectid"];
            Models.Response.TeacherResponse teacher = new TeacherResponse();
            Models.Response.TestDetailResponse testDetail = new TestDetailResponse();

            UserService userService = new UserService();
            TestService testService = new TestService();
            QuestionService questionService = new QuestionService();
            AnswerService answerService = new AnswerService();
            TestDetailService testDetailService = new TestDetailService();

            try
            {
                teacher = userService.GetUserInforByAccount(account) as Models.Response.TeacherResponse;

                examRequest.SetterID = teacher.TeacherID;
                examRequest.CreateDate = DateTime.Now;
                examRequest.SubjectID = subjectID;

                int testID = testService.AddTestReturnID(examRequest);

                foreach (Models.Request.QuestionRequest question in examRequest.Questions)
                {
                    question.SubjectID = subjectID;
                    question.IsFromExam = true;

                    int questionID = questionService.AddQuestionReturnID(question);

                    testDetail.QuestionID = questionID;
                    testDetail.TestID = testID;

                    testDetailService.AddTestDetail(testDetail);

                    foreach (Models.Request.AnswerRequest answer in question.Answers)
                    {
                        answer.QuestionID = questionID;

                        answerService.AddAnswer(answer);
                    }
                }

                return new { status="ok",message=""};

            }
            catch (Exception ex)
            {
                return new { status = "error", message = ex.Message };
            }
            
        }
    }
}