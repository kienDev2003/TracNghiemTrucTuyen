using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TracNghiemTrucTuyen.Services;

namespace TracNghiemTrucTuyen.Views.login
{
	public partial class index : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            LoadSubjectUpcoming();
        }

		protected void btn_login_ServerClick(object sender, EventArgs e)
		{
			string userName = txt_username.Value;
			string password = txt_password.Value;

			if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
			{
                string script = "alert('Tài khoản hoặc mật khẩu không được để trống !');";
                ClientScript.RegisterStartupScript(this.GetType(), "AlertScript", script, true);
				return;
            }

			Models.Request.LoginRequest loginRequest = new Models.Request.LoginRequest()
			{
				UserName = userName,
				Password = password
			};

			Authen(loginRequest);
		}

        private void Authen(Models.Request.LoginRequest loginRequest)
        {
			AccountService accountService = new AccountService();
			Models.Response.AccountResponse accountResponse = new Models.Response.AccountResponse();

			accountResponse = accountService.Authen(loginRequest);

			if(accountResponse == null)
			{
                string script = "alert('Tài khoản hoặc mật khẩu không đúng !');";
                ClientScript.RegisterStartupScript(this.GetType(), "AlertScript", script, true);
                return;
            }

			Session["Account"] = accountResponse;
			Response.Redirect("../home/");
        }

        private void LoadSubjectUpcoming()
        {
			ProctorService proctorService = new ProctorService();
			List<Models.Response.ProctorResponse> proctorResponses = new List<Models.Response.ProctorResponse>();
			string html = "";
			tbody_ListOfUpcomingSubjects.Controls.Clear();

			proctorResponses = proctorService.GetAll();

			if (proctorResponses == null) return;

			foreach(var proctorRespone in proctorResponses)
			{
                string temp = $"<tr>" +
                                $"<td class=\"border px-4 py-2\">{proctorRespone.SubjectName}</td>" +
                                $"<td class=\"border px-4 py-2\">{proctorRespone.TeacherProctorName}</td>" +
                                $"<td class=\"border px-4 py-2\">{proctorRespone.TeachingName}</td>" +
                                $"<td class=\"border px-4 py-2\">{Convert.ToDateTime(proctorRespone.ExamDate).ToString("dd/MM/yyyy")}</td>" +
                              $"</tr>";
                html += temp;
            }

			LiteralControl literal = new LiteralControl(html);

			tbody_ListOfUpcomingSubjects.Controls.Add(literal);
        }
    }
}