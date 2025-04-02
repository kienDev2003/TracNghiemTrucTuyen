using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TracNghiemTrucTuyen.Models.Response
{
	public class AnswerResponse
	{
		public int AnswerID { get; set; }
		public int QuestionID { get; set; }
		public bool IsTrue { get; set; }
		public string _Content { get; set; }

	}
}