<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="TracNghiemTrucTuyen.Views.home.subject.assessments.exams.edit" %>

<!DOCTYPE html>
<html lang="vi">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Form Tạo Câu Hỏi</title>
    <script src="https://cdn.tailwindcss.com"></script>
</head>

<body class="bg-gray-100 flex min-h-screen">
    <!--bên trái -->
    <div class="w-1/4 p-6 bg-white shadow-md fixed h-screen">
        <h2 class="text-xl font-bold text-gray-900 mb-4">Thông tin bài thi</h2>
        <div class="mb-4">
            <label class="block text-lg font-medium text-gray-700">Tên đề thi</label>
            <input type="text" id="exam-name" class="w-full px-3 py-2 border rounded-md focus:ring focus:ring-blue-300">
        </div>
        <div class="mb-4">
            <label class="block text-lg font-medium text-gray-700">Thời gian làm bài (phút)</label>
            <input type="number" id="exam-time"
                class="w-full px-3 py-2 border rounded-md focus:ring focus:ring-blue-300" min="1">
        </div>
        <div class="mb-4">
            <label id="number-question" class="block text-lg font-medium text-gray-700">Số câu hỏi: 0</label>
        </div>
        <div class="mb-4">
            <button type="button" class="w-full bg-green-600 text-white py-2 rounded-md hover:bg-green-700"
                onclick="getQuestionsData()">
                Tạo đề thi</button>
        </div>
    </div>

    <!--bên phải -->
    <div class="w-3/4 ml-auto p-6">
        <h1 class="text-2xl font-bold text-gray-900 mb-4">Tạo Câu Hỏi</h1>
        <div id="question-container" class="space-y-6"></div>

        <div class="mt-4 border-t pt-4 text-center">
            <button type="button" id="add-question" class="text-green-600 hover:text-green-800">
                ➕ Thêm câu hỏi
            </button>
        </div>
    </div>

    <script>
        let numberQuestion = 0;

        function handleReadOnlyMode() {
            const urlParams = new URLSearchParams(window.location.search);
            const readOnly = urlParams.get('readonly') === 'true';

            if (readOnly) {
                document.querySelectorAll('input, textarea, select').forEach(element => {
                    element.setAttribute('disabled', 'disabled');
                    element.classList.add('bg-gray-100', 'cursor-not-allowed');
                });

                document.querySelectorAll('button').forEach(button => {
                    if (!button.classList.contains('back-button') && !button.classList.contains('return-button')) {
                        button.style.display = 'none';
                    }
                });

                const header = document.querySelector('h1');
                const readOnlyBanner = document.createElement('div');
                readOnlyBanner.classList.add('bg-yellow-100', 'border-l-4', 'border-yellow-500', 'text-yellow-700', 'p-4', 'mb-4');
                readOnlyBanner.innerHTML = '<p class="font-bold">Chế độ xem</p><p>Bạn đang ở chế độ chỉ xem, không thể chỉnh sửa nội dung.</p>';
                header.parentNode.insertBefore(readOnlyBanner, header);
            }
        }

        function createQuestionForm() {
            let questionId = Date.now();
            let newQuestion = document.createElement('div');
            newQuestion.classList.add('bg-white', 'p-6', 'rounded-lg', 'shadow-lg', 'border-t-8', 'border-green-700', 'question-form', 'relative');
            newQuestion.innerHTML = `
        <form>
    <div class="mb-4">
        <label class="block text-lg font-medium text-gray-700">Nội dung câu hỏi</label>
        <div class="flex items-center gap-2">
            <input type="text" class="w-full px-3 py-2 border rounded-md focus:ring focus:ring-blue-300 question-content" placeholder="Nhập nội dung câu hỏi">
            <input type="file" class="hidden image-input" accept="image/*">
            <button type="button" class="p-2 border rounded hover:bg-gray-200 image-button">📷</button>
        </div>
        <img class="hidden max-w-full rounded-lg question-image" style="width: 400px; height: 300px; object-fit: contain;">
    </div>
    <div class="mb-4">
        <label class="block text-lg font-medium text-gray-700">Kiểu câu hỏi</label>
        <select class="question-type w-full px-3 py-2 border rounded-md focus:ring focus:ring-blue-300">
            <option value="multiple">Multiple Choice</option>
            <option value="single">One Choice</option>
            <option value="essay">Essay</option>
        </select>
    </div>
    <div class="answer-section">
        <div class="answer-list space-y-2"></div>
        <button type="button" class="add-answer mt-2 flex items-center gap-1 text-blue-600 hover:text-blue-800">
            ➕ Thêm đáp án
        </button>
    </div>
    <textarea class="hidden w-full mt-2 p-2 border rounded-md focus:ring focus:ring-blue-300 essay-answer" placeholder="Nhập câu trả lời..."></textarea>
    <div class="mt-4 text-right">
        <button type="button" class="delete-question text-red-600 hover:text-red-800">
            🗑 Xóa câu hỏi
        </button>
    </div>
</form>
    `;
            return newQuestion;
        }

        document.getElementById('add-question').addEventListener('click', function () {
            let questionContainer = document.getElementById('question-container');
            questionContainer.appendChild(createQuestionForm());

            ++numberQuestion;
            document.getElementById("number-question").innerText = "Số câu hỏi: " + numberQuestion;
        });

        document.addEventListener('click', function (event) {
            if (event.target.classList.contains('add-answer')) {
                let questionForm = event.target.closest('.question-form');
                let answerList = questionForm.querySelector('.answer-list');
                let questionType = questionForm.querySelector('.question-type').value;

                if (questionType === 'essay') return;

                let inputType = questionType === 'single' ? 'radio' : 'checkbox';
                let nameAttr = `answer-${questionForm.dataset.id}`;
                let newAnswer = document.createElement('div');
                newAnswer.classList.add('flex', 'items-center', 'gap-2', 'mt-2');
                newAnswer.innerHTML = `
            <input type="text" class="w-full px-3 py-2 border rounded-md focus:ring focus:ring-blue-300" placeholder="Nhập đáp án">
            <input type="${inputType}" class="w-5 h-5 answer-check" name="${nameAttr}">
            <button type="button" class="delete-answer text-red-600 hover:text-red-800">🗑</button>
        `;
                answerList.appendChild(newAnswer);
            }

            if (event.target.classList.contains('delete-question')) {
                --numberQuestion;
                document.getElementById("number-question").innerText = "Số câu hỏi: " + numberQuestion;
                event.target.closest('.question-form').remove();
            }

            if (event.target.classList.contains('delete-answer')) {
                event.target.closest('.flex').remove();
            }

            if (event.target.classList.contains('image-button')) {
                event.target.previousElementSibling.click();
            }
        });

        document.addEventListener('change', function (event) {
            if (event.target.classList.contains('image-input')) {
                let file = event.target.files[0];
                if (file) {
                    let reader = new FileReader();
                    reader.onload = function (e) {
                        let image = event.target.closest('.question-form').querySelector('.question-image');
                        image.src = e.target.result;
                        image.classList.remove('hidden');
                    };
                    reader.readAsDataURL(file);
                }
            }

            if (event.target.classList.contains('question-type')) {
                let questionForm = event.target.closest('.question-form');
                let answerSection = questionForm.querySelector('.answer-section');
                let essayAnswer = questionForm.querySelector('.essay-answer');
                let answerList = questionForm.querySelector('.answer-list');

                if (event.target.value === 'essay') {
                    answerSection.classList.add('hidden');
                    essayAnswer.classList.remove('hidden');
                } else {
                    answerSection.classList.remove('hidden');
                    essayAnswer.classList.add('hidden');
                }

                let inputType = event.target.value === 'single' ? 'radio' : 'checkbox';
                answerList.querySelectorAll('.answer-check').forEach(input => {
                    input.type = inputType;
                });
            }
        });

        function getQuestionsData() {
            const imagePromises = [];
            const questions = [];

            document.querySelectorAll('.question-form').forEach(function (questionElem, index) {
                const questionContent = questionElem.querySelector('.question-content').value;
                const questionType = questionElem.querySelector('.question-type').value;
                const imageInput = questionElem.querySelector('.image-input');
                const imageFile = imageInput.files[0];

                const question = {
                    content: questionContent,
                    image: "",
                    questionType: questionType,
                    answers: []
                };

                if (imageFile) {
                    const promise = new Promise((resolve) => {
                        const reader = new FileReader();
                        reader.onloadend = function (e) {
                            question.image = e.target.result;
                            resolve();
                        };
                        reader.readAsDataURL(imageFile);
                    });
                    imagePromises.push(promise);
                }

                if (questionType === 'essay') {
                    const essayAnswer = questionElem.querySelector('.essay-answer').value;
                    question.answers.push({
                        content: essayAnswer,
                        isTrue: true
                    });
                } else {
                    questionElem.querySelectorAll('.answer-list .flex').forEach(function (answerElem) {
                        const answerContent = answerElem.querySelector('input[type="text"]').value;
                        const isCorrect = answerElem.querySelector('input[type="checkbox"], input[type="radio"]').checked;

                        question.answers.push({
                            content: answerContent,
                            isTrue: isCorrect
                        });
                    });
                }

                questions.push(question);
            });

            Promise.all(imagePromises).then(() => {
                console.log(questions);
                saveExamData(questions);
            });
        }

        function saveExamData(questions) {
            const examName = document.getElementById("exam-name").value;
            const examDuration = document.getElementById("exam-time").value;
            const subjectID = urlParams.get('SubjectID');

            const examData = {
                Name: examName,
                Duration: examDuration,
                Questions: questions
            };

            fetch('./edit.aspx/AddTest', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ examData: examData })
            })
                .then(response => response.json())
                .then(data => {
                    if (data === 'ok') {
                        alert('Tạo đề thi thành công !');
                    }
                });
        }

        function renderExamFromData(examData) {
            document.getElementById('exam-name').value = examData.Name;
            document.getElementById('exam-time').value = examData.Duration;

            const questionContainer = document.getElementById('question-container');
            questionContainer.innerHTML = '';

            numberQuestion = examData.Questions.length;
            document.getElementById('number-question').innerText = `Số câu hỏi: ${numberQuestion}`;

            examData.Questions.forEach(question => {
                const questionElement = createQuestionElement(question);
                questionContainer.appendChild(questionElement);
            });
        }

        function createQuestionElement(questionData) {
            const questionElement = document.createElement('div');
            questionElement.classList.add('bg-white', 'p-6', 'rounded-lg', 'shadow-lg', 'border-t-8', 'border-green-700', 'question-form', 'relative');

            const questionForm = document.createElement('form');

            const questionContentDiv = document.createElement('div');
            questionContentDiv.classList.add('mb-4');
            questionContentDiv.innerHTML = `
        <label class="block text-lg font-medium text-gray-700">Nội dung câu hỏi</label>
        <div class="flex items-center gap-2">
            <input type="text" class="w-full px-3 py-2 border rounded-md focus:ring focus:ring-blue-300 question-content" 
                   placeholder="Nhập nội dung câu hỏi" value="${questionData.content || ''}">
            <input type="file" class="hidden image-input" accept="image/*">
            <button type="button" class="p-2 border rounded hover:bg-gray-200 image-button">📷</button>
        </div>
    `;

            const imageElement = document.createElement('img');
            imageElement.classList.add('max-w-full', 'rounded-lg', 'question-image');
            imageElement.style.cssText = 'width: 400px; height: 300px; object-fit: contain;';

            if (questionData.image && questionData.image !== '') {
                imageElement.src = questionData.image;
                imageElement.classList.remove('hidden');
            } else {
                imageElement.classList.add('hidden');
            }

            questionContentDiv.appendChild(imageElement);
            questionForm.appendChild(questionContentDiv);

            const questionTypeDiv = document.createElement('div');
            questionTypeDiv.classList.add('mb-4');
            questionTypeDiv.innerHTML = `
        <label class="block text-lg font-medium text-gray-700">Kiểu câu hỏi</label>
        <select class="question-type w-full px-3 py-2 border rounded-md focus:ring focus:ring-blue-300">
            <option value="multiple" ${questionData.questionType === 'multiple' ? 'selected' : ''}>Multiple Choice</option>
            <option value="single" ${questionData.questionType === 'single' ? 'selected' : ''}>One Choice</option>
            <option value="essay" ${questionData.questionType === 'essay' ? 'selected' : ''}>Essay</option>
        </select>
    `;
            questionForm.appendChild(questionTypeDiv);

            const answerSection = document.createElement('div');
            answerSection.classList.add('answer-section');

            const answerList = document.createElement('div');
            answerList.classList.add('answer-list', 'space-y-2');

            if (questionData.questionType === 'essay') {
                answerSection.classList.add('hidden');

                const essayTextarea = document.createElement('textarea');
                essayTextarea.classList.add('w-full', 'mt-2', 'p-2', 'border', 'rounded-md', 'focus:ring', 'focus:ring-blue-300', 'essay-answer');
                essayTextarea.placeholder = 'Nhập câu trả lời...';

                if (questionData.answers && questionData.answers.length > 0) {
                    essayTextarea.value = questionData.answers[0].content || '';
                }

                questionForm.appendChild(essayTextarea);
            } else {
                if (questionData.answers && questionData.answers.length > 0) {
                    const inputType = questionData.questionType === 'single' ? 'radio' : 'checkbox';
                    const nameAttr = `answer-${Date.now()}`;

                    questionData.answers.forEach(answer => {
                        const answerElement = document.createElement('div');
                        answerElement.classList.add('flex', 'items-center', 'gap-2', 'mt-2');
                        answerElement.innerHTML = `
                    <input type="text" class="w-full px-3 py-2 border rounded-md focus:ring focus:ring-blue-300" 
                           placeholder="Nhập đáp án" value="${answer.content || ''}">
                    <input type="${inputType}" class="w-5 h-5 answer-check" name="${nameAttr}" ${answer.isTrue ? 'checked' : ''}>
                    <button type="button" class="delete-answer text-red-600 hover:text-red-800">🗑</button>
                `;
                        answerList.appendChild(answerElement);
                    });
                }

                answerSection.appendChild(answerList);

                const addAnswerButton = document.createElement('button');
                addAnswerButton.type = 'button';
                addAnswerButton.classList.add('add-answer', 'mt-2', 'flex', 'items-center', 'gap-1', 'text-blue-600', 'hover:text-blue-800');
                addAnswerButton.innerHTML = '➕ Thêm đáp án';
                answerSection.appendChild(addAnswerButton);

                questionForm.appendChild(answerSection);
            }

            const deleteButtonDiv = document.createElement('div');
            deleteButtonDiv.classList.add('mt-4', 'text-right');
            deleteButtonDiv.innerHTML = `
        <button type="button" class="delete-question text-red-600 hover:text-red-800">
            🗑 Xóa câu hỏi
        </button>
    `;
            questionForm.appendChild(deleteButtonDiv);

            questionElement.appendChild(questionForm);

            return questionElement;
        }

        // Thêm sự kiện khi trang đã load
        document.addEventListener('DOMContentLoaded', function () {
            const urlParams = new URLSearchParams(window.location.search);
            const testID = urlParams.get('testid');
            if (testID) {
                console.log('ok');
                fetch('./edit.aspx/LoadContentTestByID', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({ test_id: testID })
                })
                    .then(response => response.json())
                    .then(data => {
                        console.log(data.d);
                        renderExamFromData(data.d);
                    });
            }

            handleReadOnlyMode();
        });
    </script>
</body>

</html>
