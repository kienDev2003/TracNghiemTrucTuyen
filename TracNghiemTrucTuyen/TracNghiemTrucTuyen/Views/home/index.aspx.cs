using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TracNghiemTrucTuyen.Views.home
{
	public partial class index : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if(Session["Account"] != null)
            {
                LoadCardContent(Session["Account"] as Models.Response.AccountResponse);
            }
		}

        private void LoadCardContent(Models.Response.AccountResponse account)
        {
            content_card.Controls.Clear();

            if (account.AccountType == "GV")
            {
                string html = $"<div class=\"flex flex-col lg:flex-row mt-4\">" +
                        $"<div class=\"bg-white p-4 rounded-lg shadow-md flex-1 lg:mr-4\">" +
                            $"<h2 class=\"text-blue-500 font-bold\">Môn học giảng dạy</h2>" +
                            $"<a class=\"text-blue-500 mt-2\" href=\"#\">Xem chi tiết</a>" +
                        $"</div>" +
                        $"<div class=\"bg-white p-4 rounded-lg shadow-md flex-1 mt-4 lg:mt-0\">" +
                            $"<h2 class=\"text-orange-500 font-bold\">Môn học coi thi</h2>" +
                            $"<a class=\"text-blue-500 mt-2\" href=\"#\">Xem chi tiết</a>" +
                        $"</div>" +
                   $"</div>" +
                        $"<div class=\"flex flex-col lg:flex-row mt-4\">" +
                            $"<div class=\"bg-white p-4 rounded-lg shadow-md flex-1 lg:mr-4\">" +
                            $"<h2 class=\"text-blue-500 font-bold\">Đề thi đã tạo</h2>" +
                            $"<a class=\"text-blue-500 mt-2\" href=\"#\">Xem chi tiết</a>" +
                        $"</div>" +
                        $"<div class=\"bg-white p-4 rounded-lg shadow-md flex-1 mt-4 lg:mt-0\">" +
                            $"<h2 class=\"text-orange-500 font-bold\">Ngân hàng câu hỏi</h2>" +
                            $"<a class=\"text-blue-500 mt-2\" href=\"#\">Xem chi tiết</a>" +
                        $"</div>" +
                   $"</div>";

                LiteralControl literalControl = new LiteralControl(html);
                content_card.Controls.Add(literalControl);
            }
            else if (account.AccountType == "SV")
            {
                string html = $"<div class=\"flex flex-col lg:flex-row mt-4\">" +
                            $"<div class=\"bg-white p-4 rounded-lg shadow-md flex-1 lg:mr-4\">" +
                                $"<h2 class=\"text-blue-500 font-bold\">Ca thi sắp thi</h2>" +
                                $"<a class=\"text-blue-500 mt-2\" href=\"#\">Xem chi tiết</a>" +
                            $"</div>" +
                            $"<div class=\"bg-white p-4 rounded-lg shadow-md flex-1 mt-4 lg:mt-0\">" +
                                $"<h2 class=\"text-orange-500 font-bold\">Ca thi đã thi</h2>" +
                                $"<a class=\"text-blue-500 mt-2\" href=\"#\">Xem chi tiết</a>" +
                            $"</div>" +
                       $"</div>";

                LiteralControl literalControl = new LiteralControl(html);
                content_card.Controls.Add(literalControl);
            }

        }
    }
}