using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
namespace LoginApp
{
    public class DataAccess
    {
       
        public DataTable getDataTable(string sql, List<OracleParameter> list)
        {          
            using (OracleConnection cn = new OracleConnection(ConstStr.connectstring))
            {
                try
                {
                    cn.Open(); //Oracleに接続する 
                    using (OracleCommand myCmd = new OracleCommand(sql, cn))
                    {
                        myCmd.BindByName = true;
                        foreach (OracleParameter parameter in list)
                        {
                            myCmd.Parameters.Add(parameter);
                        }

                        DataTable dt = new DataTable();                       
                        using (OracleDataAdapter adapter = new OracleDataAdapter(myCmd))
                        {
                            adapter.Fill(dt);  //取得してきたデータベースのデータを格納                          
                            return dt;
                        }                      
                    }                                                   
                }                
                finally 
                {                   
                    this.dbClose(cn);
                }
            }
        }

        public DataTable getComboBox(string sql)
        {
            using (OracleConnection cn = new OracleConnection(ConstStr.connectstring))
            {
                try
                {
                    cn.Open(); //Oracleに接続する 
                    using (OracleCommand myCmd = new OracleCommand(sql, cn))
                    {
                   
                        DataTable dt = new DataTable();
                        using (OracleDataAdapter adapter = new OracleDataAdapter(myCmd))
                        {
                            adapter.Fill(dt);  //取得してきたデータベースのデータを格納                          
                            return dt;
                        }
                    }
                }
                finally
                {
                    this.dbClose(cn);
                }
            }
        }


        #region DB開いていていたら閉じる処理

        private void dbClose(OracleConnection cn)
        {
            if (cn.State == ConnectionState.Open) //DB開いていていたら閉じる処理
            {
                cn.Close();
            }
        }

        #endregion

    }
}


