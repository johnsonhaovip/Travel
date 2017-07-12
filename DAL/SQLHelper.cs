using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Travel.DAL
{
   public class SQLHelper
    {
      // public static string str = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
       public static string str = "Data Source=JOHNSON;Initial Catalog=travel;Integrated Security=True";

       /// <summary>
       /// 执行增删改操作，返回受影响的行数
       /// </summary>
       /// <param name="sql"></param>
       /// <param name="cmdType"></param>
       /// <param name="p"></param>
       /// <returns></returns>
       public static int ExecuteNonQuery(string sql, CommandType Type, SqlParameter[] p)
       {
           int n;
           using (SqlConnection cn = new SqlConnection(str))
           {
               try
               {
                   cn.Open();
                   SqlCommand cmd = new SqlCommand(sql, cn);
                   cmd.CommandType = Type;
                   if (p != null)
                       cmd.Parameters.AddRange(p);
                   n = cmd.ExecuteNonQuery();

               }
               catch (Exception ex)
               {
                   cn.Close();
                   throw ex;
               }
           }
           return n;
       }

       /// <summary>
       /// 执行查询操作，返回dateReadr方法

       /// </summary>
       /// <param name="sql"></param>
       /// <param name="cmdType"></param>
       /// <param name="p"></param>
       /// <returns></returns>
       public static SqlDataReader ExecuteReader(string sql, CommandType Type, SqlParameter[] p)
       {
           SqlDataReader dr;
           SqlConnection cn = new SqlConnection(str);
           try
           {
               cn.Open();
               SqlCommand cmd = new SqlCommand(sql, cn);
               cmd.CommandType = Type;
               if (p != null)
                   cmd.Parameters.AddRange(p);
               dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

           }
           catch (Exception e)
           {
               throw e;
           }

           return dr;
       }
       /// <summary>
       /// 执行查询操作，返回dateset结果集
       /// </summary>
       /// <param name="sql"></param>
       /// <param name="cmdType"></param>
       /// <param name="p"></param>
       /// <returns></returns>
       public static DataSet ExecuteDataSet(string sql, CommandType Type, SqlParameter[] p)
       {
           DataSet ds = new DataSet();
           using (SqlConnection cn = new SqlConnection(str))
           {
               try
               {
                   cn.Open();
                   SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                   da.SelectCommand.CommandType = Type;
                   if (p != null)
                       da.SelectCommand.Parameters.AddRange(p);
                   da.Fill(ds);
               }
               catch (Exception e)
               {
                   throw e;
               }
           }
           return ds;
       }

       /// <summary>
       /// 执行数据库的查询操作返回首行首列的object对象
       /// </summary>
       /// <param name="sql"></param>
       /// <param name="cmdType"></param>
       /// <param name="p"></param>
       /// <returns></returns>
       public static object ExecuteScalar(string sql, CommandType Type, SqlParameter[] p)
       {
           object i;
           using (SqlConnection cn = new SqlConnection(str))
           {
               try
               {
                   cn.Open();
                   SqlCommand cmd = new SqlCommand(sql, cn);
                   cmd.CommandType = Type;
                   if (p != null)
                       cmd.Parameters.AddRange(p);
                   i = cmd.ExecuteScalar();
               }
               catch (Exception e)
               {
                   throw e;
               }
           }
           return i;
       }

    }
}
