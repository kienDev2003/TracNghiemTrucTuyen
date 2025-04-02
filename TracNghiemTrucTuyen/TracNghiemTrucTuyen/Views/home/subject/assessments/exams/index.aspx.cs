using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TracNghiemTrucTuyen.Models.Response;
using TracNghiemTrucTuyen.Services;

namespace TracNghiemTrucTuyen.Views.home.subject.assessments.exams
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["subjectID"] != null && Session["Account"] != null)
            {
                LoadExamsByAccount(Request.QueryString["subjectID"], Session["Account"] as Models.Response.AccountResponse);
                GetSubjectInfo(Request.QueryString["subjectID"]);
            }
        }

        private void GetSubjectInfo(string subjectID)
        {
            SubjectService subjectService = new SubjectService();
            Models.Response.SubjectResponse subject = new SubjectResponse();

            subject = subjectService.GetSubjectByID(subjectID);

            if (subject == null) return;

            txt_subjectName.InnerText = $"Đề thi môn: {subject.SubjectName}";
        }

        private void LoadExamsByAccount(string subjectID, AccountResponse accountResponse)
        {
            TestService testService = new TestService();
            List<Models.Response.ExamResponse> examResponses = new List<ExamResponse>();
            string html = "";

            examResponses = testService.GetExams(accountResponse, subjectID);

            if (examResponses == null) return;

            foreach(var exam in examResponses)
            {
                string temp = $"<tr class=\"text-center\">" +
                                    $"<td class=\"border border-gray-300 px-4 py-2\">{exam.TestName}</td>" +
                                    $"<td class=\"border border-gray-300 px-4 py-2\">{(exam.IsApproved ? exam.ReviewerName : "Chưa duyệt")}</td>" +
                                    $"<td class=\"border border-gray-300 px-4 py-2\">{exam.Duration}</td>" +
                                    $"<td class=\"border border-gray-300 px-4 py-2\">{exam.CreateDate.ToString("dd/MM/yyyy")}</td>" +
                                    $"<td class=\"border border-gray-300 px-4 py-2\">" +
                                        $"<a href=\"./edit.aspx?testid={exam.TestID}&readonly=true\" class=\"bg-blue-500 text-white px-2 py-1 rounded\">Xem</a>" +
                                        $"<a href=\"./edit.aspx?testid={exam.TestID}&edit=true\" class=\"bg-blue-500 text-white px-2 py-1 rounded\">Sửa</a>" +
                                        $"<input type=\"button\" onclick=\"DeleteTest({exam.TestID})\" class=\"bg-red-500 text-white px-2 py-1 rounded\" value=\"Xóa\">" +
                                    $"</td>" +
                              $"</tr>";

                html += temp;
            }

            exams.Controls.Clear();

            LiteralControl literalControl = new LiteralControl(html);
            exams.Controls.Add(literalControl);
        }

        protected void btn_create_exams_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect($"./edit.aspx?subjectID={Request.QueryString["subjectID"]}");
        }
    }
}