using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TracNghiemTrucTuyen.Models.Response;
using TracNghiemTrucTuyen.Services;

namespace TracNghiemTrucTuyen.Views.home
{
    public partial class Layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Account"] == null) Response.Redirect("~/Views/login/");

            LoadUserFeature(Session["Account"] as Models.Response.AccountResponse);

        }
        protected void btn_change_password_ServerClick(object sender, EventArgs e)
        {

        }
        protected void btn_logout_ServerClick(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/Views/login/");
        }

        private void LoadUserFeature(Models.Response.AccountResponse accountResponse)
        {
            if (accountResponse.AccountType == "SV")
            {
                UserService userService = new UserService();
                Models.Response.StudentResponse student = userService.GetUserInforByAccount(accountResponse) as Models.Response.StudentResponse;

                string html = $"<li class=\"mt-2\">" +
                            $"<a class=\"text-green-500\" href=\"#\">Ca thi sắp thi</a>" +
                       $"</li>" +
                       $"<li class=\"mt-2\">" +
                            $"<a class=\"text-green-500\" href=\"#\">Ca thi đã thi</a>" +
                       $"</li>";

                txt_tai_khoan.InnerText = student.StudentID;
                txt_ho_ten.InnerText = student.FullName;

                LiteralControl literalControl = new LiteralControl(html);
                userFeature.Controls.Add(literalControl);
            }
            else if (accountResponse.AccountType == "GV")
            {
                UserService userService = new UserService();
                Models.Response.TeacherResponse teacher = userService.GetUserInforByAccount(accountResponse) as Models.Response.TeacherResponse;

                if (teacher.IsLeader)
                {
                    string html = $"<li class=\"mt-2\">" +
                                    $"<a class=\"text-green-500\" href=\"{ResolveUrl("~/Views/home/")}\">Trang chủ</a>" +
                               $"</li>" +
                               $"<li class=\"mt-2\">" +
                                    $"<a class=\"text-green-500\" href=\"{ResolveUrl("~/Views/home/subject/")}\">Môn học giảng dạy</a>" +
                               $"</li>" +
                               $"<li class=\"mt-2\">" +
                                    $"<a class=\"text-green-500\" href=\"#\">Môn học coi thi</a>" +
                               $"</li>" +
                               $"<li class=\"mt-2\">" +
                                    $"<a class=\"text-green-500\" href=\"{ResolveUrl("~/Views/home/subject/")}\">Đề thi</a>" +
                               $"</li>" +
                               $"<li class=\"mt-2\">" +
                                    $"<a class=\"text-green-500\" href=\"{ResolveUrl("~/Views/home/subject/")}\">Ngân hàng câu hỏi</a>" +
                               $"</li>" +
                               $"<li class=\"mt-2\">" +
                                    $"<a class=\"text-green-500\" href=\"\">Phân công giảng dạy</a>" +
                               $"</li>" +
                               $"<li class=\"mt-2\">" +
                                    $"<a class=\"text-green-500\" href=\"#\">Phân công coi thi</a>" +
                               $"</li>" +
                               $"<li class=\"mt-2\">" +
                                    $"<a class=\"text-green-500\" href=\"#\">Duyệt đề thi</a>" +
                               $"</li>";

                    LiteralControl literalControl = new LiteralControl(html);
                    userFeature.Controls.Add(literalControl);
                }
                else
                {
                    string html = $"<li class=\"mt-2\">" +
                                    $"<a class=\"text-green-500\" href=\"{ResolveUrl("~/Views/home/")}\">Trang chủ</a>" +
                               $"</li>" +
                               $"<li class=\"mt-2\">" +
                                    $"<a class=\"text-green-500\" href=\"{ResolveUrl("~/Views/home/subject/")}\">Môn học giảng dạy</a>" +
                               $"</li>" +
                               $"<li class=\"mt-2\">" +
                                    $"<a class=\"text-green-500\" href=\"#\">Môn học coi thi</a>" +
                               $"</li>" +
                               $"<li class=\"mt-2\">" +
                                    $"<a class=\"text-green-500\" href=\"{ResolveUrl("~/Views/home/subject/")}\">Đề thi</a>" +
                               $"</li>" +
                               $"<li class=\"mt-2\">" +
                                    $"<a class=\"text-green-500\" href=\"{ResolveUrl("~/Views/home/subject/")}\">Ngân hàng câu hỏi</a>" +
                               $"</li>";

                    LiteralControl literalControl = new LiteralControl(html);
                    userFeature.Controls.Add(literalControl);
                }

                txt_tai_khoan.InnerText = teacher.TeacherID;
                txt_ho_ten.InnerText = teacher.FullName;
            }
            else
            {
                string html = $"<li class=\"mt-2\">" +
                                    $"<a class=\"text-green-500\" href=\"#\">Danh sách giáo viên</a>" +
                               $"</li>" +
                               $"<li class=\"mt-2\">" +
                                    $"<a class=\"text-green-500\" href=\"#\">Danh sách sinh viên</a>" +
                               $"</li>" +
                               $"<li class=\"mt-2\">" +
                                    $"<a class=\"text-green-500\" href=\"#\">Danh sách khoa</a>" +
                               $"</li>" +
                               $"<li class=\"mt-2\">" +
                                    $"<a class=\"text-green-500\" href=\"#\">Danh sách bộ môn</a>" +
                               $"</li>" +
                               $"<li class=\"mt-2\">" +
                                    $"<a class=\"text-green-500\" href=\"#\">Danh sách chuyên ngành</a>" +
                               $"</li>";

                LiteralControl literalControl = new LiteralControl(html);
                userFeature.Controls.Add(literalControl);
            }
        }
    }
}