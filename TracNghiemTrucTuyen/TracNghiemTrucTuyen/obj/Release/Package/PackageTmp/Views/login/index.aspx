<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TracNghiemTrucTuyen.Views.login.index" %>

<html>
<head>
    <title>Hệ thống thi trắc nghiệm trực tuyến
    </title>
    <script src="https://cdn.tailwindcss.com">
    </script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" rel="stylesheet" />
    <style>
        footer {
            position: fixed;
            bottom: 0;
            width: 100%;
        }
    </style>
</head>
<body class="bg-gray-100">
    <form id="form1" runat="server">
        <header class="bg-green-600 text-white p-4">
            <div class="container mx-auto flex items-center justify-center">
                <i class="fas fa-home mr-2"></i>
                <h1 class="text-lg font-bold">HỆ THỐNG THI TRẮC NGHIỆM TRỰC TUYẾN
                </h1>
            </div>
        </header>
        <main class="container mx-auto mt-4 flex justify-center">
            <div class="w-full lg:w-2/3 p-2">
                <div class="bg-green-500 text-white p-2 rounded-t">
                    <h2 class="text-lg font-bold">DANH SÁCH MÔN HỌC SẮP THI
                    </h2>
                </div>
                <div class="bg-white p-4 rounded-b shadow">
                    <table class="min-w-full bg-white">
                        <thead>
                            <tr>
                                <th class="py-2 px-4 bg-green-500 text-white">Tên môn học
                                </th>
                                <th class="py-2 px-4 bg-green-500 text-white">Giáo viên giảng dạy
                                </th>
                                <th class="py-2 px-4 bg-green-500 text-white">Giáo viên coi thi
                                </th>
                                <th class="py-2 px-4 bg-green-500 text-white">Ngày thi
                                </th>
                            </tr>
                        </thead>
                        <tbody id="tbody_ListOfUpcomingSubjects" runat="server">
                            <tr>
                                <td class="border px-4 py-2">Mathematics
                                </td>
                                <td class="border px-4 py-2">Mr. John Doe
                                </td>
                                <td class="border px-4 py-2">Ms. Jane Smith
                                </td>
                                <td class="border px-4 py-2">01/03/2025
                                </td>
                            </tr>
                            <tr class="bg-gray-100">
                                <td class="border px-4 py-2">Physics
                                </td>
                                <td class="border px-4 py-2">Dr. Albert Einstein
                                </td>
                                <td class="border px-4 py-2">Mr. Isaac Newton
                                </td>
                                <td class="border px-4 py-2">05/03/2025
                                </td>
                            </tr>
                            <tr>
                                <td class="border px-4 py-2">Chemistry
                                </td>
                                <td class="border px-4 py-2">Dr. Marie Curie
                                </td>
                                <td class="border px-4 py-2">Mr. Dmitri Mendeleev
                                </td>
                                <td class="border px-4 py-2">10/03/2025
                                </td>
                            </tr>
                            <tr class="bg-gray-100">
                                <td class="border px-4 py-2">Biology
                                </td>
                                <td class="border px-4 py-2">Dr. Charles Darwin
                                </td>
                                <td class="border px-4 py-2">Ms. Rosalind Franklin
                                </td>
                                <td class="border px-4 py-2">15/03/2025
                                </td>
                            </tr>
                            <tr>
                                <td class="border px-4 py-2">History
                                </td>
                                <td class="border px-4 py-2">Prof. Yuval Noah Harari
                                </td>
                                <td class="border px-4 py-2">Dr. Howard Zinn
                                </td>
                                <td class="border px-4 py-2">20/03/2025
                                </td>
                            </tr>
                            <tr class="bg-gray-100">
                                <td class="border px-4 py-2">Geography
                                </td>
                                <td class="border px-4 py-2">Dr. Jared Diamond
                                </td>
                                <td class="border px-4 py-2">Prof. David Harvey
                                </td>
                                <td class="border px-4 py-2">25/03/2025
                                </td>
                            </tr>
                            <tr>
                                <td class="border px-4 py-2">Computer Science
                                </td>
                                <td class="border px-4 py-2">Dr. Alan Turing
                                </td>
                                <td class="border px-4 py-2">Prof. Donald Knuth
                                </td>
                                <td class="border px-4 py-2">30/03/2025
                                </td>
                            </tr>
                            <tr class="bg-gray-100">
                                <td class="border px-4 py-2">Literature
                                </td>
                                <td class="border px-4 py-2">Prof. J.R.R. Tolkien
                                </td>
                                <td class="border px-4 py-2">Dr. Jane Austen
                                </td>
                                <td class="border px-4 py-2">05/04/2025
                                </td>
                            </tr>
                            <tr>
                                <td class="border px-4 py-2">Art
                                </td>
                                <td class="border px-4 py-2">Prof. Leonardo da Vinci
                                </td>
                                <td class="border px-4 py-2">Dr. Pablo Picasso
                                </td>
                                <td class="border px-4 py-2">10/04/2025
                                </td>
                            </tr>
                            <tr class="bg-gray-100">
                                <td class="border px-4 py-2">Music
                                </td>
                                <td class="border px-4 py-2">Prof. Ludwig van Beethoven
                                </td>
                                <td class="border px-4 py-2">Dr. Wolfgang Amadeus Mozart
                                </td>
                                <td class="border px-4 py-2">15/04/2025
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="w-full lg:w-1/3 p-2">
                <div class="bg-green-500 text-white p-2 rounded-t">
                    <h2 class="text-lg font-bold">ĐĂNG NHẬP
                    </h2>
                </div>
                <div class="bg-white p-4 rounded-b shadow">
                    <div class="mb-4">
                        <label class="block text-gray-700 text-sm font-bold mb-2" for="username">
                            Tên đăng nhập
                        </label>
                        <input class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="txt_username" runat="server" placeholder="Tên đăng nhập" type="text" />
                    </div>
                    <div class="mb-4">
                        <label class="block text-gray-700 text-sm font-bold mb-2" for="password">
                            Mật khẩu
                        </label>
                        <div class="relative">
                            <input class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="txt_password" runat="server" placeholder="Mật khẩu" type="password" />
                            <i class="fas fa-eye absolute right-3 top-3 text-gray-500"></i>
                        </div>
                    </div>
                    <div class="mb-4">
                        <a class="text-green-600 hover:underline" href="#">Quên mật khẩu
                        </a>
                    </div>
                    <div class="mb-4">
                        <button class="bg-green-600 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline w-full" type="button" id="btn_login" runat="server" onserverclick="btn_login_ServerClick">
                            Đăng nhập
                        </button>
                    </div>
                </div>
            </div>
        </main>
        <footer class="bg-green-600 text-white p-4 mt-4">
            <div class="container mx-auto text-center">
                <p class="text-sm">
                    Copyright © 2020 HỌC VIỆN NÔNG NGHIỆP VIỆT NAM
                </p>
            </div>
        </footer>
        <script>
            document.addEventListener("DOMContentLoaded", function () {
                // Hiển thị/Ẩn mật khẩu
                const passwordInput = document.getElementById("password");
                const toggleIcon = document.querySelector(".fa-eye");

                toggleIcon.addEventListener("click", function () {
                    if (passwordInput.type === "password") {
                        passwordInput.type = "text";
                        toggleIcon.classList.replace("fa-eye", "fa-eye-slash"); // Đổi icon
                    } else {
                        passwordInput.type = "password";
                        toggleIcon.classList.replace("fa-eye-slash", "fa-eye"); // Đổi icon về ban đầu
                    }
                });

                // Cập nhật năm hiện tại vào footer
                const footerText = document.querySelector("footer p");
                const currentYear = new Date().getFullYear();
                footerText.innerHTML = `Copyright © ${currentYear} HỌC VIỆN NÔNG NGHIỆP VIỆT NAM`;
            });
        </script>
    </form>
</body>
</html>
