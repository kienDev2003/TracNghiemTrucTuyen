using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TracNghiemTrucTuyen.Database
{
	public class CreateConnection
	{
		private readonly string _strConn;
		public CreateConnection()
		{
			_strConn = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;
		}

		public SqlConnection Create()
		{
			return new SqlConnection(_strConn);
		}
	}
}