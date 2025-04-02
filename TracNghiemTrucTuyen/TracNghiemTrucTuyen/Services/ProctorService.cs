using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TracNghiemTrucTuyen.Repositories;

namespace TracNghiemTrucTuyen.Services
{
	public class ProctorService
	{
		private readonly ProctorRepository _proctorRepository;
		public ProctorService()
		{
			_proctorRepository = new ProctorRepository();
		}
		public List<Models.Response.ProctorResponse> GetAll()
		{
			List<Models.Response.ProctorResponse> proctorResponses = new List<Models.Response.ProctorResponse>();

			DataTable data = _proctorRepository.GetAll();

			if (data.Rows.Count <= 0) return null;

			foreach(DataRow row in data.Rows)
			{
				proctorResponses.Add(new Models.Response.ProctorResponse
				{
					SubjectName = row[0].ToString(),
					TeacherProctorName= row[1].ToString(),
					TeachingName = row[2].ToString(),
					ExamDate = Convert.ToDateTime(row[3])
				});
			}
			return proctorResponses;
		}
	}
}