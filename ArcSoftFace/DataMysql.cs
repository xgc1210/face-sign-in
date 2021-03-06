﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace ArcSoftFace
{
    class DataMysql
    {
        string conStr;
        MySqlConnection con = new MySqlConnection("server=你的ip;port=3306;user=用户名;password=密码;database=数据库名");

        //连接数据库
        public void dataCon()
        {
            //conStr = "server=你的ip;port=3306;user=用户名;password=密码;database=数据库名;";
            conStr = "server=你的ip;port=3306;user=用户名;password=密码;database=数据库名;";
            MySqlConnection con = new MySqlConnection(conStr);
        }

        //查询数据库
        public DataSet getDataSet(string sql)
        {
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
        public bool sqlExec(string sql)
        {
            try
            {
                con.Open();
            }
            catch
            {
                MessageBox.Show("数据库未连接！");
            }
            try
            {
                MySqlCommand oledbCom = new MySqlCommand(sql, con);
                oledbCom.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public DataSet Select()
        {
            try
            {
                if (con != null)
                {
                    con.Open();
                }


                string cmdStr = "Select * from t_family";
                MySqlCommand sqlCmd = new MySqlCommand(cmdStr, con);
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCmd);

                DataSet ds = new DataSet();
                sda.Fill(ds, "t_family");
                return ds;
            }
            catch (Exception exception)
            {
                throw new Exception("SelectMethod:" + exception.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
