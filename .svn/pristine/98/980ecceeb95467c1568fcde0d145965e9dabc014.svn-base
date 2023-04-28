using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        /// 
       

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormLogin());
            FormLogin formLogin = new FormLogin();
            try
            { 
                formLogin.ShowDialog();
            }

             catch (Exception ex)
            {        
               MessageBox.Show(ex.Message.ToString(), "エラー",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }

            finally
            {
                formLogin.Close();  
                formLogin.Dispose();
            }
            
        }
    }
}

