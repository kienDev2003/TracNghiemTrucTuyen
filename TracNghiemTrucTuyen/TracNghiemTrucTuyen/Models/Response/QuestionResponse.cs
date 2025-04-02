using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TracNghiemTrucTuyen.Models.Response
{
	public class QuestionResponse
	{
		public int QuestionID { get; set; }
		public string _Content { get; set; }
		public string SubjectID { get; set; }
		public bool IsFromExam { get; set; }
		public string QuestionType { get; set; }
		public string QuestionImage { get; set; }
	}
}