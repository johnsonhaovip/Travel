using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Model  //ÐÞ¸ÄÃû×Ö¿Õ¼ä
{
	public class Tab_administrators
	{
		private int a_id;
		public int A_id
		{
			get { return a_id; }
			set { a_id = value; }
		}
	
		private string a_emaile;
		public string A_emaile
		{
			get { return a_emaile; }
			set { a_emaile = value; }
		}
	
		private string a_password;
		public string A_password
		{
			get { return a_password; }
			set { a_password = value; }
		}
	}
}