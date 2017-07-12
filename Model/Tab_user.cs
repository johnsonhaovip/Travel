using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Model //ÐÞ¸ÄÃû×Ö¿Õ¼ä
{
	public class Tab_user
	{
		private int u_id;
		public int U_id
		{
			get { return u_id; }
			set { u_id = value; }
		}
	
		private string u_emaile;
		public string U_emaile
		{
			get { return u_emaile; }
			set { u_emaile = value; }
		}
	
		private string u_name;
		public string U_name
		{
			get { return u_name; }
			set { u_name = value; }
		}
	
		private string u_password;
		public string U_password
		{
			get { return u_password; }
			set { u_password = value; }
		}
	
		private string u_head;
		public string U_head
		{
			get { return u_head; }
			set { u_head = value; }
		}
	
		private string u_message;
		public string U_message
		{
			get { return u_message; }
			set { u_message = value; }
		}
	
		private string u_collect;
		public string U_collect
		{
			get { return u_collect; }
			set { u_collect = value; }
		}

        private DateTime lastLoginTime;
        public DateTime LastLoginTime
		{
			get { return lastLoginTime; }
			set { lastLoginTime = value; }
		}
	
		private string u_discuss;
		public string U_discuss
		{
			get { return u_discuss; }
			set { u_discuss = value; }
		}
	}
}