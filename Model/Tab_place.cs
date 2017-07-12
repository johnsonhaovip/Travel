using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Model //ÐÞ¸ÄÃû×Ö¿Õ¼ä
{
	public class Tab_place
	{
		private int u_id;
		public int U_id
		{
			get { return u_id; }
			set { u_id = value; }
		}
	
		private string s_place;
		public string S_place
		{
			get { return s_place; }
			set { s_place = value; }
		}
	
		private string s_picture;
		public string S_picture
		{
			get { return s_picture; }
			set { s_picture = value; }
		}
	
		private string s_introduce;
		public string S_introduce
		{
			get { return s_introduce; }
			set { s_introduce = value; }
		}
	
		private string s_type;
		public string S_type
		{
			get { return s_type; }
			set { s_type = value; }
		}
	
		private string u_emaile;
		public string U_emaile
		{
			get { return u_emaile; }
			set { u_emaile = value; }
		}

        private int s_ClickNumber;
        public int S_ClickNumber
        {
            get { return s_ClickNumber; }
            set { s_ClickNumber = value; }
        }

        private DateTime s_update;
        public DateTime S_update
        {
            get { return s_update; }
            set { s_update = value; }
        }


	}
}