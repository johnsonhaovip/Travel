using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Model //ÐÞ¸ÄÃû×Ö¿Õ¼ä
{
	public class Tab_discuss
	{
		private int u_id;
		public int U_id
		{
			get { return u_id; }
			set { u_id = value; }
		}
	
		private string u_discuss;
		public string U_discuss
		{
			get { return u_discuss; }
			set { u_discuss = value; }
		}
	
		private string u_emaileA;
		public string U_emaileA
		{
			get { return u_emaileA; }
			set { u_emaileA = value; }
		}
	
		private string u_emaileB;
		public string U_emaileB
		{
			get { return u_emaileB; }
			set { u_emaileB = value; }
		}
        private DateTime uploadTime;
        public DateTime UploadTime
        {
            get { return uploadTime; }
            set { uploadTime = value; }
        }

	}
}