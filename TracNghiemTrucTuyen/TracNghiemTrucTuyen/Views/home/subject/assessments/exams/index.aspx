<%@ Page Title="" Language="C#" MasterPageFile="~/Views/home/LayoutMaster/Layout.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TracNghiemTrucTuyen.Views.home.subject.assessments.exams.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <div class="flex-1 p-5">
        <div class="bg-white rounded-lg p-5 mb-5 shadow-md">
            <h2 id="txt_subjectName" runat="server" class="text-primary text-xl font-bold"></h2>
        </div>
        <div class="flex justify-end">
            <input type="button" class="bg-green-500 text-white py-2 px-4 rounded" id="btn_create_exams" value="Tạo đề thi" runat="server" onserverclick="btn_create_exams_ServerClick" >
        </div>
        <div class="mt-5 bg-white p-4 shadow-md rounded-lg">
            <h2 class="text-xl font-bold mb-4">Danh sách đề thi</h2>
            <table class="w-full border-collapse border border-gray-300">
                <thead>
                    <tr class="bg-gray-200">
                        <th class="border border-gray-300 px-4 py-2">Tên đề thi</th>
                        <th class="border border-gray-300 px-4 py-2">Giáo viên duyệt</th>
                        <th class="border border-gray-300 px-4 py-2">Thời gian làm bài</th>
                        <th class="border border-gray-300 px-4 py-2">Ngày tạo đề</th>
                        <th class="border border-gray-300 px-4 py-2">Chức năng</th>
                    </tr>
                </thead>
                <tbody id="exams" runat="server">
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
