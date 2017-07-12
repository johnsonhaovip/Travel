using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Model  //ĞŞ¸ÄÃû×Ö¿Õ¼ä
{
    public class Tab_travel
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

        private string t_depart;
        public string T_depart
        {
            get { return t_depart; }
            set { t_depart = value; }
        }

        private string t_destination;
        public string T_destination
        {
            get { return t_destination; }
            set { t_destination = value; }
        }

        private DateTime t_startTime;
        public DateTime T_startTime
        {
            get { return t_startTime; }
            set { t_startTime = value; }
        }
        private string t_title;
        public string T_title
        {
            get { return t_title; }
            set { t_title = value; }
        }


        private int t_sumTime;
        public int T_sumTime
        {
            get { return t_sumTime; }
            set { t_sumTime = value; }
        }


        private string t_day1;
        public string T_day1
        {
            get { return t_day1; }
            set { t_day1 = value; }
        }

        private string t_day2;
        public string T_day2
        {
            get { return t_day2; }
            set { t_day2 = value; }
        }

        private string t_day3;
        public string T_day3
        {
            get { return t_day3; }
            set { t_day3 = value; }
        }

        private string t_day4;
        public string T_day4
        {
            get { return t_day4; }
            set { t_day4 = value; }
        }

        private string t_day5;
        public string T_day5
        {
            get { return t_day5; }
            set { t_day5 = value; }
        }

        private DateTime uploadTime;
        public DateTime UploadTime
        {
            get { return uploadTime; }
            set { uploadTime = value; }
        }



    }
}