using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TracNghiemTrucTuyen.Models.Response
{
	public class TeacherResponse
	{
		public string TeacherID { get; set; }
		public string FullName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Email { get; set; }
		public string DepartmentName { get; set; }
		public string FacultyName { get; set; }
		public bool IsLeader { get; set; }
	}
}