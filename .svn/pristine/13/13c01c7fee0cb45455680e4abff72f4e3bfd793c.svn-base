using Microsoft.SqlServer.Server;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Text;
using System.Windows.Forms;

namespace login
{
    class MainApp
    {
        /// <summary>
        /// アプリケーションのメインエントリポイント
        /// </summary>
        public static void Main()
        {
            using (LoginForm login = new LoginForm())
            {
                try
                {                   
                    login.ShowDialog();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show(ex.Message, "エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                
            }
        }
    }
}
