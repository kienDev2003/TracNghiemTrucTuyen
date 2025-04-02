<%@ Page Title="" Language="C#" MasterPageFile="~/Views/home/LayoutMaster/Layout.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TracNghiemTrucTuyen.Views.home.subject.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <div class="flex-1 p-5">
        <!-- Header -->
        <div class="bg-white rounded-lg p-5 mb-5 shadow-md">
            <h2 class="text-primary text-xl font-bold">Danh sách môn học giảng dạy</h2>
        </div>

        <!-- cards -->
        <div id="subject_list" runat="server" class="flex flex-wrap gap-4 max-w-6xl mx-auto">
        </div>
    </div>
</asp:Content>
