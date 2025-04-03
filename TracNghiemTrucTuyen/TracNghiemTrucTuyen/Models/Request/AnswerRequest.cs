using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TracNghiemTrucTuyen.Models.Request
{
	public class AnswerRequest
	{
        public string _Content { get; set; }
        public int QuestionID { get; set; }
        public bool IsTrue { get; set; }
    }
}