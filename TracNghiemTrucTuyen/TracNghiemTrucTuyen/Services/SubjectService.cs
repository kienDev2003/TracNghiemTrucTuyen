using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TracNghiemTrucTuyen.Repositories;

namespace TracNghiemTrucTuyen.Services
{
	public class SubjectService
	{
		private readonly SubjectRepository _subjectRepository;
		public SubjectService()
		{
			_subjectRepository = new SubjectRepository();
		}
		public List<Models.Response.SubjectOfTaughtResponse> GetListSubjectOfTaught(Models.Response.AccountResponse account)
		{
			List<Models.Response.SubjectOfTaughtResponse> subjectOfTaughtResponses = new List<Models.Response.SubjectOfTaughtResponse>();

			DataTable data = _subjectRepository.GetSubjectOfTaught(account.AccountID);

			if (data.Rows.Count <= 0) return null;

			foreach(DataRow row in data.Rows)
			{
				subjectOfTaughtResponses.Add(new Models.Response.SubjectOfTaughtResponse
				{
					SubjectID = row[0].ToString(),
					SubjectName = row[1].ToString(),
				});
			}
			return subjectOfTaughtResponses;
		}

        public Models.Response.SubjectResponse GetSubjectByID(string subjectID)
        {
			Models.Response.SubjectResponse subject = new Models.Response.SubjectResponse();

            DataTable data = _subjectRepository.GetBySubjectID(subjectID);

            if (data.Rows.Count <= 0) return null;

            foreach (DataRow row in data.Rows)
            {
				subject.SubjectID = row[0].ToString();
				subject.SubjectName = row[1].ToString();
				subject.Credits = Convert.ToInt32(row[2]);
				subject.DepartmentID = Convert.ToInt32(row[3]);
            }
            return subject;
        }
    }
}