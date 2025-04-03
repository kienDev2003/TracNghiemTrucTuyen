using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TracNghiemTrucTuyen.Models.Request
{
	public class ExamRequest
	{
        public string SetterID { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string SubjectID { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Models.Request.QuestionRequest> Questions { get; set; }
    }
}