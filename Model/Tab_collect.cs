using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Model //ÐÞ¸ÄÃû×Ö¿Õ¼ä
{
	public class Tab_collect
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
	
		private string u_collect;
		public string U_collect
		{
			get { return u_collect; }
			set { u_collect = value; }
		}
	
		private string t_content;
		public string T_content
		{
			get { return t_content; }
			set { t_content = value; }
		}

        private DateTime uploadTime;
        public DateTime UploadTime
        {
            get { return uploadTime; }
            set { uploadTime = value; }
        }

	}
}