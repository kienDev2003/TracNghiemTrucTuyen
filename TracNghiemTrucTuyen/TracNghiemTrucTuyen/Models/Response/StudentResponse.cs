using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TracNghiemTrucTuyen.Models.Response
{
	public class StudentResponse
	{
		public string Email { get; set; }
		public string MajorName { get; set; }
		public string FacultyName { get; set; }
		public string StudentID { get; set; }
		public string FullName { get; set; }
		public DateTime DateOfBrith { get; set; }
		public string ClassName { get; set; }
	}
}