using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TracNghiemTrucTuyen.Models.Response;
using TracNghiemTrucTuyen.Services;

namespace TracNghiemTrucTuyen.Views.home.subject
{
	public partial class index : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["Account"] != null)
            {
                LoadSubjectOfTaught(Session["Account"] as Models.Response.AccountResponse);
            }
		}

        private void LoadSubjectOfTaught(AccountResponse account)
        {
			SubjectService subjectService = new SubjectService();
			List<Models.Response.SubjectOfTaughtResponse> subjectOfTaughtResponses = new List<SubjectOfTaughtResponse>();
            string html = "";

			subjectOfTaughtResponses = subjectService.GetListSubjectOfTaught(account);

			if (subjectOfTaughtResponses == null) return;

			foreach(var subjectOfTaught in subjectOfTaughtResponses)
			{
                string temp = $"<a href=\"./assessments/?subjectID={subjectOfTaught.SubjectID}\">" +
                                $"<div class=\"bg-white rounded-lg p-5 shadow-md h-full flex items-center\">" +
                                    $"<div class=\"w-16 h-16 mr-4 flex-shrink-0 flex items-center justify-center\">" +
                                        $"<img src=\"https://storage.googleapis.com/a1aa/image/AiEJ_7qeAVqqKlpsbZKghAufu_YazYioW6oz2wz6H-U.jpg\" class=\"max-w-full max-h-full\">" +
                                    $"</div>" +
                                    $"<h3 class=\"text-secondary text-base font-medium\">{subjectOfTaught.SubjectName}</h3>" +
                                $"</div>" +
                              $"</a>";
                html += temp;
            }

            subject_list.Controls.Clear();

            LiteralControl literalControl = new LiteralControl(html);
            subject_list.Controls.Add(literalControl);
        }
    }
}