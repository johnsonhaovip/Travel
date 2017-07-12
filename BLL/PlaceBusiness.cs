using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Model;

namespace Travel.BLL
{
   public class PlaceBusiness
    {
       /// <summary>
       /// 添加目的地
       /// </summary>
       /// <param name="place"></param>
       /// <returns></returns>
       public static bool AddPlace(Tab_place place)
       {
           return Travel.DAL.PlaceAccess.AddPlace(place);
       }

       public static bool ChangePlaceClickNumber(int u_id)
       {
           return Travel.DAL.PlaceAccess.ChangePlaceClickNumber(u_id);
       }
    }
}
