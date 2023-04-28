using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class FormLogin : Form
    {

        public FormLogin()
        {
            InitializeComponent();
        }

        #region ログインボタンクリックイベントハンドラ

        private void loginButton_Click(object sender, EventArgs e)
        {
            //入力チェック呼び出し
            if (!this.valueCheck())
            {
                return;     //falseが帰ってきたら処理を終了
            }

            if (!this.loginCheck())     //DB接続ログインチェック
            {
                return;     //falseが帰ってきたら処理を終了
            }

            this.loginInsert();    //インサート処理呼び出し

            using (FormLoginHis f1 = new FormLoginHis())
            {
                f1.IdText = userTextBox.Text; //IdTextプロパティに値を代入して一覧画面に値を渡します。
                f1.ShowDialog();
            }
        }

        #endregion

        #region テキスト入力チェック処理

        private bool valueCheck()　//ここからテキストに値があるか調べる入力チェックの処理↓
        {
            if (userTextBox.Text == "" & passwordTextBox.Text == "") //IDがNULLかつパスワードがNULLの時
            {
                errorMessege("ユーザーIDとパスワードを入力してください");
                userTextBox.BackColor = Color.Red;  //背景色を赤にする
                passwordTextBox.BackColor = Color.Red;  //背景色を赤にする
                userTextBox.Focus();
                return false;
            }

            if (userTextBox.Text == "") //IDがNULLの時
            {
                errorMessege("ユーザーIDを入力してください");
                userTextBox.BackColor = Color.Red;
                userTextBox.Focus();
                return false;
            }

            if (passwordTextBox.Text == "") //パスワードがNULLの時
            {
                errorMessege("パスワードを入力してください");
                passwordTextBox.BackColor = Color.Red;
                passwordTextBox.Focus();
                return false;
            }

            return true; //trueを返して次の処理に移動させる
        }

        #endregion

        #region ログイン情報入力チェック処理

        private bool loginCheck() //ここからDB接続して値が正しいかのログインチェック↓
        {           
            string sql = "SELECT user_id, password FROM ADMIN.M_USER  WHERE user_id = :user_id AND password = :password";
            List<OracleParameter> sqlParameters = new List<OracleParameter>
            {
                new OracleParameter(":user_id", OracleDbType.Char, userTextBox.Text, ParameterDirection.Input),
                new OracleParameter(":password", OracleDbType.Varchar2, passwordTextBox.Text, ParameterDirection.Input)
            };

            DataAccess daLog = new DataAccess();　//インスタンス化
            DataTable dt = daLog.getDataTable(sql, sqlParameters);
               
            if (dt.Rows.Count == 0) //データテーブルに読み込む行がない場合
            {
                errorMessege("ユーザーIDまたはパスワードが一致しません");
                userTextBox.BackColor = Color.Red;  //背景色を赤にする
                passwordTextBox.BackColor = Color.Red;  //背景色を赤にする
                userTextBox.Focus();   // ユーザーIDにカーソルを置く                                
                return false;
            }               
            
            //OKの処理
            MessageBox.Show("ログインしました");
            return true; //trueを返して次の処理に移動させる                      
        }

        #endregion

        #region ログイン後インサート処理

        private void loginInsert()　  //ここからログインしたユーザーをインサートする処理↓
        {
            string insertSql = "INSERT INTO ADMIN.T_LOGIN_USER(login_date, login_user_id, login_pc_name, login_pc_ip)" +
                               " VALUES(:login_date, :login_user_id, :login_pc_name, :login_pc_ip )";   //insert文
 
            string ipv4 = ipv4Address(); //IPアドレス取得

            using (OracleConnection cn = new OracleConnection(ConstStr.connectstring))
            {
                using (OracleCommand insertCmd = new OracleCommand(insertSql, cn))
                {
                    insertCmd.BindByName = true; //パラメータが名前別にバインドされる場合はtrueを設定しないといけない
                    //ここからバインドするためのパラメータ
                    insertCmd.Parameters.Add(new OracleParameter(":login_date", OracleDbType.Date, DateTime.Now, ParameterDirection.Input));
                    insertCmd.Parameters.Add(new OracleParameter(":login_user_id", OracleDbType.Char, userTextBox.Text, ParameterDirection.Input));
                    insertCmd.Parameters.Add(new OracleParameter(":login_pc_name", OracleDbType.NVarchar2, Dns.GetHostName(), ParameterDirection.Input));
                    insertCmd.Parameters.Add(new OracleParameter(":login_pc_ip", OracleDbType.NVarchar2, ipv4, ParameterDirection.Input));

                    try
                    {
                        cn.Open();
                        bool trnFlg = false;  //トランザクション判定フラグ

                        using (OracleTransaction trn = cn.BeginTransaction()) //トランザクション開始
                        {
                            try
                            {
                                insertCmd.ExecuteNonQuery();  // テーブルにインサートするSQLの実行
                                trn.Commit(); // トランザクションコミット
                                trnFlg = true;
                                MessageBox.Show("ログイン情報を保存しました");

                            }
                            catch
                            {
                                if (cn.State == ConnectionState.Open & !trnFlg) //DB開いていてtrnFlgがfalseの場合はロールバックする
                                {
                                    trn.Rollback();  //Openであればトランザクションをロールバック
                                }
                                throw;
                            }
                        }
                    }
                    finally
                    {
                        if (cn.State == ConnectionState.Open) //DB開いていていたら閉じる処理
                        {
                            cn.Close();
                        }
                    }
                }
            }
        }

        #endregion

        #region ロストフォーカスの処理

        private void userTextBox_Leave(object sender, EventArgs e)
        {
            if (userTextBox.Text != "") //カーソルが離れた時テキストボックスが空じゃないか？
            {
                userTextBox.Text = userTextBox.Text.PadLeft(5, '0');
            }
        }

        #endregion

        #region テキストチェンジの処理
        private void userTextBox_TextChanged(object sender, EventArgs e)
        {
            userTextBox.BackColor = SystemColors.Window; //背景色を初期化      
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            passwordTextBox.BackColor = SystemColors.Window; //背景色を初期化  
        }

        #endregion

        #region 終了の処理

        private void endButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region クリアの処理

        private void resetButton_Click(object sender, EventArgs e)
        {
            userTextBox.Clear();
            passwordTextBox.Clear();
            userTextBox.BackColor = SystemColors.Window; //背景色を初期化
            passwordTextBox.BackColor = SystemColors.Window;　//背景色を初期化
            userTextBox.Focus();
        }

        #endregion

        #region エラーメッセージ表示処理

        private void errorMessege(String messege)
        {
            MessageBox.Show(messege, "エラー",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
        }

        #endregion

        #region ipv4アドレス取得処理

        private String ipv4Address()
        {
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress a in ips)    //一覧からIPv4アドレスのみを取得する
            {
                if (a.AddressFamily.Equals(AddressFamily.InterNetwork))　//IPv4を対象とする
                {
                    return a.ToString();
                }
            }
            return string.Empty;
        }

        #endregion


    }

}

