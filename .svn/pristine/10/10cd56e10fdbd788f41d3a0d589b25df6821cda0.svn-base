using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;
using System.Resources;
using System.Windows.Forms;


namespace login
{
    public class DataAccess
    {
        String str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        /// <summary>
        /// SELECT結果をDataTableへ
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteSelect(String sql)
        {
            return this.ExecuteSelect(sql, null);
        }

        public DataTable ExecuteSelect(String sql, OracleParameter[] paramList)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = new OracleConnection(this.str);
            try
            {
                conn.Open();

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    //parameter取得
                    if (paramList != null)
                    {
                        cmd.BindByName = true;
                        foreach (OracleParameter param in paramList)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }

                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return dt;

        }

        /// <summary>
        /// DB操作 insert,update,delete
        /// </summary>
        /// <param name="sql">実行するSQL</param>
        /// <param name="paramList">パラメーター</param>
        public void ExecuteUpdate(String sql, OracleParameter[] paramList)
        {
            String str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            OracleConnection conn = new OracleConnection(str);
            conn.Open();

            using (OracleCommand cmd = new OracleCommand(sql, conn))
            {
                //parameter取得
                if (paramList != null)
                {
                    cmd.BindByName = true;
                    foreach (OracleParameter param in paramList)
                    {
                        cmd.Parameters.Add(param);
                    }
                }

                //トランザクション開始
                OracleTransaction transaction = conn.BeginTransaction();
                try
                {
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    transaction.Dispose();
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

       
    }
}
