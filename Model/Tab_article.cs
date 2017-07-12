using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Model //ÐÞ¸ÄÃû×Ö¿Õ¼ä
{
	public class Tab_article
	{
		private int u_id;
		public int U_id
		{
			get { return u_id; }
			set { u_id = value; }
		}
	
		private string u_name;
		public string U_name
		{
			get { return u_name; }
			set { u_name = value; }
		}
	
		private string u_emaile;
		public string U_emaile
		{
			get { return u_emaile; }
			set { u_emaile = value; }
		}
	
		private string t_title;
		public string T_title
		{
			get { return t_title; }
			set { t_title = value; }
		}
	
		private string t_content;
		public string T_content
		{
			get { return t_content; }
			set { t_content = value; }
		}
	
		private string art_illustration;
		public string Art_illustration
		{
			get { return art_illustration; }
			set { art_illustration = value; }
		}

        private string d_emaile;
        public string D_emaile
        {
            get { return d_emaile; }
            set { d_emaile = value; }
        }

	
		private string d_name;
		public string D_name
		{
			get { return d_name; }
			set { d_name = value; }
		}
	
		private string art_discuss;
		public string Art_discuss
		{
			get { return art_discuss; }
			set { art_discuss = value; }
		}
	
		private int art_ClickNumber;
		public int Art_ClickNumber
		{
			get { return art_ClickNumber; }
			set { art_ClickNumber = value; }
		}

        private DateTime uploadTime;
        public DateTime UploadTime
        {
            get { return uploadTime; }
            set { uploadTime = value; }
        }

	}
}