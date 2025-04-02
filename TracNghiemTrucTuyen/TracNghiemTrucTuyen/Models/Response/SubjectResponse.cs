using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TracNghiemTrucTuyen.Models.Response
{
	public class SubjectResponse
	{
		public string SubjectID { get; set; }
		public string SubjectName { get; set; }
		public int Credits { get; set; }
		public int DepartmentID { get;set; }
	}
}