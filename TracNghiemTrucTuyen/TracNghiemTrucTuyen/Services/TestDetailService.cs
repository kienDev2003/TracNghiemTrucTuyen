using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TracNghiemTrucTuyen.Repositories;

namespace TracNghiemTrucTuyen.Services
{
	public class TestDetailService
	{
		private readonly TestDetailRepository _testDetailRepository;
		public TestDetailService()
		{
			_testDetailRepository = new TestDetailRepository();
		}
		public List<Models.Response.TestDetailResponse> GetTestDetails(int testID)
		{
			List<Models.Response.TestDetailResponse> questions = new List<Models.Response.TestDetailResponse>();

			DataTable data = _testDetailRepository.GetTestDetails(testID);

			if (data.Rows.Count <= 0) return null;

			foreach(DataRow row in data.Rows)
			{
				questions.Add(new Models.Response.TestDetailResponse
				{
					QuestionID = Convert.ToInt32(row[0]),
					TestID = Convert.ToInt32(row[1])
				});

			}

			return questions;

        }

		public void AddTestDetail(Models.Response.TestDetailResponse testDetail)
		{
			_testDetailRepository.AddTestDetail(testDetail);
		}
	}
}