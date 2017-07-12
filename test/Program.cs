using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.BLL;
using Travel.DAL;
using Travel.Model;

namespace Travel.test
{
 public   class Program
    {
        static void Main(string[] args)
        {
            //List<Tab_user> list1 = new List<Tab_user>(BLL.UserBusiness.GetAllUsers());
            //for (int i = 0; i < list1.Count; i++)
            //{
            //    Console.WriteLine("{0}\t{1}\t{2}\t{3}", list1[i].U_emaile, list1[i].U_name, list1[i].U_password, list1[i].LastLoginTime);
            // 
               
            //}



            //List<Tab_article> list1 = new List<Tab_article>(BLL.ArticleBusiness.GetAllArticle());
            //for (int i = 0; i < list1.Count; i++)
            //{
            //    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", list1[i].U_name, list1[i].U_emaile, list1[i].Art_title, list1[i].Art_content,list1[i].D_name,list1[i].Art_discuss,list1[i].Art_ClickNumber);  

            //}



            List<Tab_travel> list1 = new List<Tab_travel>(BLL.TravelBusiness.GetAllTravel());
            for (int i = 0; i < list1.Count; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", list1[i].U_name, list1[i].U_emaile, list1[i].T_depart, list1[i].T_destination, list1[i].T_startTime, list1[i].T_sumTime);

            }


            //List<Tab_administrators> list1 = new List<Tab_administrators>(BLL.AdministratorBusiness.GetAllAdmin()) ;
            //for (int i = 0; i < list1.Count; i++)
            //{
            //    Console.WriteLine("{0}\t{1}\t{2}", list1[i].A_id, list1[i].A_emaile, list1[i].A_password);

            //}


        }
    }
}
