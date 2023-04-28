using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;


namespace LoginApp
{
    public partial class FormLoginHis : Form
    {

        #region ユーザーID初期表示プロパティ

        public string IdText
        {
            set
            {
                idTextBox.Text = value;
                nameTextBox.Enabled = false;
                loginUserBox.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        #endregion

        public FormLoginHis()
        {
            InitializeComponent();
        }

        #region 検索ボタンクリックイベントハンドラ

        private void seachButton_Click(object sender, EventArgs e)
        {
            //①正確な値が入っているかチェック
            if (!this.valueCheck()) return;

            StringBuilder sb = new StringBuilder();
            List<OracleParameter> prms = new List<OracleParameter>();
            //②検索するためのSQL文とパラメータを取得
            this.joinSql(sb, prms);

            //③データテーブルを画面に表示
            this.viewOutput(sb.ToString(), prms);

        }

        #endregion

        #region //正確な値が入っているかチェック

        private bool valueCheck()　//正確な値を入力しているかチェック
        {
            if (loginStart.Text != "" & !DateTime.TryParse(loginStart.Text, out DateTime dte1)) //開始日が日付型か？
            {
                errorMessege("正しい日付を入力してください");
                loginStart.BackColor = Color.Red;  //背景色を赤にする
                loginStart.Focus();
                return false;
            }

            if (loginEnd.Text != "" & !DateTime.TryParse(loginEnd.Text, out DateTime dte2))　//終了日が日付型か？
            {
                errorMessege("正しい日付を入力してください");
                loginEnd.BackColor = Color.Red;  //背景色を赤にする
                loginEnd.Focus();
                return false;
            }

            
            return true;
        }

        #endregion
        
        #region //SQL文を連結する

        private void joinSql(StringBuilder sb, List<OracleParameter> prms)　//SQL連結
        {      
            sb.AppendLine("SELECT MU.user_id                           ");
            sb.AppendLine("      ,MU.last_name || first_name user_name ");
            sb.AppendLine("      ,MU.delflg                            ");
            sb.AppendLine("      ,TL.login_date                        ");
            sb.AppendLine("      ,TL.login_pc_name                     ");
            sb.AppendLine("      ,TL.login_pc_ip                       ");
            sb.AppendLine("  FROM ADMIN.M_USER MU                      ");
            sb.AppendLine("  LEFT JOIN ADMIN.T_LOGIN_USER TL           ");
            sb.AppendLine("    ON (MU.user_id = TL.login_user_id)      ");

            List<String> sqlList = new List<String>();　//SQL文字連結用リスト

            //ここからSQLを連結する
            if (idRadioButton.Checked == true & idTextBox.Text != "") //IDが入力されている
            {
                prms.Add(new OracleParameter(":user_id", OracleDbType.Char, idTextBox.Text + "%", ParameterDirection.Input));
                sqlList.Add(" MU.user_id LIKE :user_id");   //前方一致
            }

            if (nameRadioButton.Checked & nameTextBox.Text != "") //NAMEが入力されている
            {
                prms.Add(new OracleParameter(":user_name", OracleDbType.NVarchar2, "%" + nameTextBox.Text + "%", ParameterDirection.Input));
                sqlList.Add(" MU.last_name || first_name LIKE :user_name"); //部分一致
            }

            if (loginUserRadioButton.Checked & loginUserBox.Text != "") //ログインユーザーが入力されている
            {
                prms.Add(new OracleParameter(":login_user_name", OracleDbType.NVarchar2,  loginUserBox.Text, ParameterDirection.Input));
                sqlList.Add(" MU.last_name || first_name = :login_user_name"); //部分一致
            }

            if (loginStart.Text != "") //開始日が入力されている
            {
                DateTime dtStart = DateTime.Parse(loginStart.Text);
                prms.Add(new OracleParameter(":login_date1", OracleDbType.Date, dtStart, ParameterDirection.Input));
                sqlList.Add(" TL.login_date >= :login_date1");
            }

            if (loginEnd.Text != "") //終了日が入力されている
            {
                DateTime dtEnd = DateTime.Parse(loginEnd.Text);
                prms.Add(new OracleParameter(":login_date2", OracleDbType.Date, dtEnd, ParameterDirection.Input));
                sqlList.Add(" TL.login_date <= :login_date2 +(1-1/24/60/60)");
            }

            if (deleteFlg.Checked) //削除フラグチェックされているか
            {
                prms.Add(new OracleParameter(":delflg", OracleDbType.Int64, 0, ParameterDirection.Input));
                sqlList.Add(" MU.DELFLG = :delflg");
            }

            if (sqlList.Count != 0)　//WHERE句にする条件リストがあるか
            {
                sb.Append(" WHERE");
                sb.AppendLine(string.Join(" AND", sqlList));
            }

            sb.Append(" ORDER BY TL.login_date DESC"); //条件関係なく最後に必ず連結するSQL文                                                     　
        }

        #endregion

        #region データテーブルをデーグリッドビューに表示

        private void viewOutput(string sql, List<OracleParameter> sqlParams)　//表示する
        {
            DataAccess daHis = new DataAccess(); //インスタンス化            
            DataTable dt = daHis.getDataTable(sql, sqlParams); //getDataTableメソッドでデータテーブル作成

            if (loginDataView.DataSource == null) //最初の一回だけバインドさせる処理
            {
                bindData(dt);　//バインド
            }

            loginDataView.DataSource = dt;   //データグリッドビューに表示 
        }

        #endregion

        #region データバインド

        public void bindData(DataTable dt)　
        {         
            loginDataView.Columns["user_id"].DataPropertyName = dt.Columns["user_id"].ToString();
            loginDataView.Columns["user_name"].DataPropertyName = dt.Columns["user_name"].ToString();
            loginDataView.Columns["delflg"].DataPropertyName = dt.Columns["delflg"].ToString();
            loginDataView.Columns["login_date"].DataPropertyName = dt.Columns["login_date"].ToString();
            loginDataView.Columns["login_pc_name"].DataPropertyName = dt.Columns["login_pc_name"].ToString();
            loginDataView.Columns["login_pc_ip"].DataPropertyName = dt.Columns["login_pc_ip"].ToString();           
        }

        #endregion

        #region ロストフォーカスの処理

        private void idTextBox_Leave(object sender, EventArgs e)
        {
            if (idTextBox.Text != "") //カーソルが離れた時テキストボックスが空じゃないか？
            {
                string after = idTextBox.Text.PadLeft(5, '0');
                idTextBox.Text = after;
            }
        }

        #endregion

        #region エラーメッセージ表示

        private void errorMessege(String messege)
        {
            MessageBox.Show(messege, "エラー",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
        }

        #endregion

        #region 8桁入力されていたらスラッシュを入れる処理
        private void loginStrEnd_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length == 8)
            {
                ((TextBox)sender).Text = tryParseData(((TextBox)sender).Text);
            }

        }

        private string tryParseData(string loginDay)
        {
            DateTime date;
            CultureInfo ci = CultureInfo.CurrentCulture;
            DateTimeStyles dts = DateTimeStyles.None;
            string format = "yyyyMMdd";
            if (!DateTime.TryParseExact(loginDay, format, ci, dts, out date))
            {
                return loginDay;
            }
            return date.ToString("yyyy/MM/dd");
        }

        #endregion

        #region //テキストチェンジの処理
     
        private void loginStrEnd_TextChanged(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = SystemColors.Window; //背景色を初期化  
        }

        #endregion


        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == idRadioButton.Checked)
            {
                idTextBox.Enabled = true;
                nameTextBox.Enabled = false;
                loginUserBox.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            if (((RadioButton)sender).Checked == nameRadioButton.Checked)
            {
                idTextBox.Enabled = false;
                nameTextBox.Enabled = true;
                loginUserBox.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            if (((RadioButton)sender).Checked == loginUserRadioButton.Checked)
            {
                idTextBox.Enabled = false;
                nameTextBox.Enabled = false;
                loginUserBox.DropDownStyle = ComboBoxStyle.DropDown;
            }
        }

        private void loginUserBox_Click(object sender, EventArgs e)
        {
            StringBuilder sb1 = new StringBuilder();
            sb1.AppendLine("SELECT DISTINCT MU.last_name || first_name user_name ");
            sb1.AppendLine("  FROM ADMIN.M_USER MU                               ");
            sb1.AppendLine("  LEFT JOIN ADMIN.T_LOGIN_USER TL                    ");
            sb1.AppendLine("    ON (MU.user_id = TL.login_user_id)               ");
            DataAccess da2 = new DataAccess();
            DataTable dtC = da2.getComboBox(sb1.ToString());
            loginUserBox.DisplayMember = "user_name";
            loginUserBox.ValueMember = "user_name";
            loginUserBox.DataSource = dtC;
        }

    }
}
