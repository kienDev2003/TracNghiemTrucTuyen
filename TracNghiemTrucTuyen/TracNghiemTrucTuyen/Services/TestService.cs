using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Web;
using TracNghiemTrucTuyen.Repositories;

namespace TracNghiemTrucTuyen.Services
{
    public class TestService
    {
        private readonly TestRepository _testRepository;
        public TestService()
        {
            _testRepository = new TestRepository();
        }
        public List<Models.Response.ExamResponse> GetExams(Models.Response.AccountResponse account, string subjectID)
        {
            List<Models.Response.ExamResponse> examResponses = new List<Models.Response.ExamResponse>();

            DataTable data = _testRepository.GetExams(account.AccountID, subjectID);

            if (data.Rows.Count <= 0) return null;

            foreach (DataRow row in data.Rows)
            {
                examResponses.Add(new Models.Response.ExamResponse
                {
                    SetterName = row[0].ToString(),
                    ReviewerName = row[1].ToString(),
                    TestID = Convert.ToInt32(row[2]),
                    TestName = row[3].ToString(),
                    Duration = Convert.ToInt32(row[4]),
                    CreateDate = Convert.ToDateTime(row[5]),
                    IsApproved = Convert.ToBoolean(row[6])
                });
            }

            return examResponses;
        }

        public Models.Response.ExamResponse GetTestByID(int testID)
        {
            Models.Response.ExamResponse test = new Models.Response.ExamResponse();

            DataTable data = _testRepository.GetTestByID(testID);

            if (data.Rows.Count <= 0) return null;

            foreach (DataRow row in data.Rows)
            {
                test.TestID = Convert.ToInt32(row[0]);
                test.TestName = row[1].ToString();
                test.Duration = Convert.ToInt32(row[2]);
            }

            return test;
        }
    }
}