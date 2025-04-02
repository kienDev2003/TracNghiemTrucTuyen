<%@ Page Title="" Language="C#" MasterPageFile="~/Views/home/LayoutMaster/Layout.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TracNghiemTrucTuyen.Views.home.subject.assessments.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <div class="flex-1 p-5">
        <div id="assessments" runat="server" class="flex flex-wrap lg:flex-nowrap gap-4 max-w-6xl mx-auto">
            <div class="w-full lg:w-1/4 bg-white rounded-lg shadow-md p-6 text-center hover:shadow-lg transition-shadow duration-300 flex flex-col items-center">
                <a id="exam-link" href="./exams/?subjectID=TH03005">
                    <img src="https://storage.googleapis.com/a1aa/image/AiEJ_7qeAVqqKlpsbZKghAufu_YazYioW6oz2wz6H-U.jpg" alt="Schedule" class="w-16 h-16 mb-4">
                    <h3 class="text-gray-800 font-medium mb-2">Đề Thi</h3>
                </a>
            </div>
            <div class="w-full lg:w-1/4 bg-white rounded-lg shadow-md p-6 text-center hover:shadow-lg transition-shadow duration-300 flex flex-col items-center">
                <a id="question-link" href="./exams/?subjectID=TH03005">
                    <img src="https://storage.googleapis.com/a1aa/image/AiEJ_7qeAVqqKlpsbZKghAufu_YazYioW6oz2wz6H-U.jpg" alt="Schedule" class="w-16 h-16 mb-4">
                    <h3 class="text-gray-800 font-medium mb-2">Câu hỏi</h3>
                </a>
            </div>
        </div>
    </div>

    <script>
        const urlParams = new URLSearchParams(window.location.search);
        const subjectID = urlParams.get('subjectID');

        if (subjectID) {
            const examLink = document.getElementById('exam-link');
            const questionLink = document.getElementById("question-link")

            examLink.href = `./exams/?subjectID=${subjectID}`;
            questionLink.href = `./question/?subjectID=${subjectID}`;
        }
    </script>
</asp:Content>
