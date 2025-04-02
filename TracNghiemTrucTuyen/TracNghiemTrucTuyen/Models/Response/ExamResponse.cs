using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TracNghiemTrucTuyen.Models.Response
{
	public class ExamResponse
	{
		public string SetterName { get; set; }
		public string ReviewerName { get; set; }
		public int TestID { get; set; }
		public string TestName { get; set; }
		public int Duration { get; set; }
		public DateTime CreateDate { get; set; }
		public bool IsApproved { get; set; }
	}
}