using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TracNghiemTrucTuyen.Models.Response
{
	public class ProctorResponse
	{
		public string SubjectName { get; set; }
		public string TeacherProctorName { get; set; }
		public string TeachingName { get; set; }
		public DateTime ExamDate { get; set; }
	}
}