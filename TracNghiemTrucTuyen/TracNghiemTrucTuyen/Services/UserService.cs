using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TracNghiemTrucTuyen.Repositories;

namespace TracNghiemTrucTuyen.Services
{
	public class UserService
	{
		private readonly UserRepository _userRepository;
		public UserService()
		{
			_userRepository = new UserRepository();
		}
		public object GetUserInforByAccount(Models.Response.AccountResponse account)
		{
			DataTable data = _userRepository.GetUserInforByAccountID(account.AccountID);

			if (data.Rows.Count <= 0) return null;

			if(account.AccountType == "GV")
			{
				Models.Response.TeacherResponse teacher = new Models.Response.TeacherResponse();
				foreach(DataRow row in data.Rows)
				{
					teacher.Email = row[1].ToString();
					teacher.DepartmentName = row[2].ToString();
					teacher.FacultyName = row[3].ToString();
					teacher.TeacherID = row[4].ToString();
					teacher.FullName = row[5].ToString();
					teacher.DateOfBirth = Convert.ToDateTime(row[6]);
					teacher.IsLeader = Convert.ToBoolean(row[8]);
				}
				return teacher;
			}
			else if(account.AccountType == "SV")
			{
                Models.Response.StudentResponse student = new Models.Response.StudentResponse();
                foreach (DataRow row in data.Rows)
                {
                    student.Email = row[1].ToString();
                    student.MajorName = row[2].ToString();
                    student.FacultyName = row[3].ToString();
                    student.StudentID = row[4].ToString();
                    student.FullName = row[5].ToString();
                    student.DateOfBrith = Convert.ToDateTime(row[6]);
                    student.ClassName = row[8].ToString();
                }
                return student;
            }
			return null;
		}
	}
}