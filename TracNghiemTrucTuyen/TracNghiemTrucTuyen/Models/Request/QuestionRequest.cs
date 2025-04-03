using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TracNghiemTrucTuyen.Models.Request
{
	public class QuestionRequest
	{
        public string _Content { get; set; }
        public string SubjectID { get; set; }
        public bool IsFromExam { get; set; }
        public string Image { get; set; }
        public string QuestionType { get; set; }
        public List<Models.Request.AnswerRequest> Answers { get; set; }
    }
}