using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace login
{
    public partial class LoginHisView : Form
    {
        public LoginHisView()
        {
            InitializeComponent();
            firstDate.LostFocus += new EventHandler(dateTextbox_lostFocus);
            lastDate.LostFocus += new EventHandler(dateTextbox_lostFocus);
        }

        /// <summary>
        /// ログイン一覧画面読み込み
        /// </summary>
        /// <param name="sender">イベントコントロール</param>
        /// <param name="e">イベント引数</param>
        private void LoginHisView_Load(object sender, EventArgs e)
        {
            //テキストボックス内初期化、comboboxリスト入力
            resetTextCombo();

            //dgvとDataTableのカラムのバインド
            dgvColumnDate.DataPropertyName = "login_date";
            dgvColumnId.DataPropertyName = "login_user_id";
            dgvColumnName.DataPropertyName = "full_name";
            dgvColumnDelflg.DataPropertyName = "delflg";
            dgvColumnPcName.DataPropertyName = "login_pc_name";
            dgvColumnIp.DataPropertyName = "login_pc_ip";

            loginHis.ReadOnly = true;
            loginHis.Columns["dgvColumnDate"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";           
        }

        #region 検索ボタンイベント

        /// <summary>
        /// 検索ボタンクリック
        /// </summary>
        /// <param name="sender">イベントコントロール</param>
        /// <param name="e">イベント引数</param>

        private void searchButton_Click(object sender, EventArgs e)
        {
            //日付入力形式のチェック
            if (this.dateTextCheck()) return;

            //検索のSQL文作成とパラメーターのセット
            String loginUserSql = "";
            OracleParameter[] paramInsert = new OracleParameter[0];
            GetSearchSql(ref loginUserSql, ref paramInsert);

            //DB内検索　select結果をDataTableへ
            DataAccess accessSearch = new DataAccess();
            DataTable searchDt = accessSearch.ExecuteSelect(loginUserSql, paramInsert);

            //検索結果をデータグリッドビューに表示
            loginHis.DataSource = searchDt;
        }

        //日付入力形式のチェック
        private bool dateTextCheck()
        {
            //firstDateが空欄でない
            if (!String.IsNullOrEmpty(firstDate.Text))
            {
                //日付に変更できない
                if (!(DateTime.TryParse(firstDate.Text, out DateTime _)))
                {
                    MessageBox.Show("年月日を正しく入力してください(0000/00/00)", "入力エラー",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    return true;
                }
            }

            //lastDateが空欄でない
            if (!(DateTime.TryParse(lastDate.Text, out DateTime _)))
            {
                //日付に変更できない
                if (!(String.IsNullOrEmpty(lastDate.Text)))
                {
                    MessageBox.Show("年月日を正しく入力してください(0000/00/00)", "入力エラー",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    return true;
                }
            }

            //日付に変更できる場合,空欄がある場合
            return false;
        }

        //検索する時のSQL文
        private void GetSearchSql(ref String loginUserSql, ref OracleParameter[] paramInsert)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendLine("select lgu.login_user_id                            ");
            sbSql.AppendLine("      ,mus.last_name || mus.first_name as full_name ");
            sbSql.AppendLine("      ,lgu.login_date                               ");
            sbSql.AppendLine("      ,lgu.login_pc_name                            ");
            sbSql.AppendLine("      ,lgu.login_pc_ip                              ");
            sbSql.AppendLine("      ,mus.delflg                                   ");
            sbSql.AppendLine(" from  admin.t_login_user lgu                       ");
            sbSql.AppendLine(" inner join admin.m_user  mus                       ");
            sbSql.AppendLine(" on   (lgu.login_user_id = mus.user_id)             ");

            var sqlList = new List<string>();
            var paramList = new List<OracleParameter>();

            //ユーザーIDのラジオボタンにチェックがついている
            if (radioUserId.Checked)
            {
                //ユーザーIDが入力されている
                if (!String.IsNullOrEmpty(inputUserId.Text))
                {
                    sqlList.Add("lgu.login_user_id like :userId ");
                    paramList.Add(new OracleParameter(":userId",
                                                      OracleDbType.Char,
                                                      inputUserId.Text + "%",
                                                      ParameterDirection.Input));
                }
            }

            //ユーザー名のラジオボタンにチェックがついている
            if (radioUserNm.Checked)
            {
                //ユーザー名が入力されている
                if (!String.IsNullOrEmpty(inputUserNm.Text))
                {
                    sqlList.Add("mus.last_name || mus.first_name like :userName ");
                    paramList.Add(new OracleParameter(":userName",
                                                      OracleDbType.NVarchar2,
                                                      "%" + inputUserNm.Text + "%",
                                                      ParameterDirection.Input));
                }
            }

            //ログインユーザー名にチェックがついている
            if (radioLoginUser.Checked)
            {
                sqlList.Add("lgu.login_user_id = :loginId ");
                paramList.Add(new OracleParameter(":loginId",
                                                   OracleDbType.Char,
                                                   comboLoginUser.SelectedValue,
                                                   ParameterDirection.Input));
            }


            //firstDate.Textが入力されている
            if (!String.IsNullOrEmpty(firstDate.Text))
            {
                sqlList.Add("lgu.login_date >= :firstDate ");
                paramList.Add(new OracleParameter(":firstDate",
                                                  OracleDbType.Date,
                                                  DateTime.Parse(firstDate.Text),
                                                  ParameterDirection.Input));

            }

            //lastDate.Textが入力されている
            if (!String.IsNullOrEmpty(lastDate.Text))
            {
                sqlList.Add("lgu.login_date <= :lastDate ");
                paramList.Add(new OracleParameter(":lastDate",
                                                  OracleDbType.Date,
                                                  DateTime.ParseExact(lastDate.Text + " 23:59:59", "yyyy/MM/dd HH:mm:ss", null),
                                                  ParameterDirection.Input));
            }

            //チェックボックスがついている
            if (delflgCheckBox.Checked)
            {
                //削除未のみ
                sqlList.Add("delflg = 0 ");
            }

            paramInsert = new OracleParameter[paramList.Count];
            //List内あれば以下SQL、Parameter追加する
            if (sqlList.Count > 0)
            {
                sbSql.AppendLine("where ");
                sbSql.AppendLine(String.Join("and ", sqlList));
                paramInsert = paramList.ToArray();
            }

            sbSql.AppendLine("order by lgu.login_date desc");
            loginUserSql = sbSql.ToString();
        }

        /// <summary>
        /// データグリッドビューの列：削除フラグの表示を変更
        /// </summary>
        /// <param name="sender">イベントコントロール</param>
        /// <param name="e">イベント引数</param>
        private void loginHisCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (loginHis.Columns[e.ColumnIndex].Name != dgvColumnDelflg.Name) return;

            if (int.Parse(e.Value.ToString()) == 0)
            {
                e.Value = userIndexView.enroll;
            }
            else
            {
                e.Value = userIndexView.leave;
            }
        }

        #endregion

        /// <summary>
        /// リセットボタンクリック
        /// </summary>
        /// <param name="sender">イベントコントロール</param>
        /// <param name="e">イベント引数</param>
        private void resetButton_Click(object sender, EventArgs e)
        {
            //テキストボックス内初期化、comboboxリスト更新
            resetTextCombo();

            //カラムヘッダーを残してDGVクリア
            DataTable dt = (DataTable)loginHis.DataSource;
            if (dt != null)
            {
                dt.Clear();
            }
        }

        /// <summary>
        /// ログイン日テキストボックスからカーソルを外した時
        /// </summary>
        /// <param name="sender">イベントコントロール</param>
        /// <param name="e">イベント情報</param>
        private void dateTextbox_lostFocus(object sender, EventArgs e)
        {
            TextBox tx = (TextBox)sender;

            if (tx.Text.Length == 8)
            {
                StringBuilder sb = new StringBuilder(tx.Text);
                sb.Insert(4, "/");
                sb.Insert(7, "/");
                String dateText = sb.ToString();

                if (DateTime.TryParse(dateText, out DateTime _))
                {
                    tx.Text = dateText;
                }
            }
        }

        /// <summary>
        /// テキストボックス内初期化、comboboxリスト入力
        /// </summary>
        private void resetTextCombo()
        {
            //ログインフォームで入力したユーザーIDを取得する
            inputUserId.Text = LoginInfo.loginUserId;

            inputUserNm.Clear();

            Common common = new Common();
            firstDate.Text = common.getDateNow().AddDays(-1).ToString("yyyy/MM/dd"); //昨日の日付取得
            lastDate.Text = common.getDateNow().ToString("yyyy/MM/dd");  //本日の日付取得

            radioUserId.Checked = true;
            inputUserNm.Enabled = false; //ユーザー名入力欄を無効にする
            comboLoginUser.Enabled = false; //ログインユーザーを選択できないようにする

            //conboboxにm_userの名前入れる
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select user_id,                              ");
            sb.AppendLine("       last_name || first_name as full_name, ");
            sb.AppendLine("       delflg                                ");
            sb.AppendLine("from   admin.m_user                          ");
            sb.AppendLine("order  by delflg asc, user_id asc        　　");
            String sql = sb.ToString();
            DataAccess accessSearch = new DataAccess();
            DataTable nameTable = accessSearch.ExecuteSelect(sql);

            comboLoginUser.DataSource = nameTable;
            comboLoginUser.DisplayMember = "full_name";
            comboLoginUser.ValueMember = "user_id";
            comboLoginUser.SelectedValue = LoginInfo.loginUserId;
        }

        /// <summary>
        /// ユーザーIDラジオボタンの付け外し
        /// </summary>
        /// <param name="sender">イベントコントロール</param>
        /// <param name="e">イベント引数</param>
        private void radioUserId_CheckedChanged(object sender, EventArgs e)
        {
            //ラジオボタンにチェックがついている場合のみ入力できる
            inputUserId.Enabled = radioUserId.Checked;
        }

        /// <summary>
        /// ユーザー名ラジオボタンのつけ外し
        /// </summary>
        /// <param name="sender">イベントコントロール</param>
        /// <param name="e">イベント情報</param>
        private void radioUserNm_CheckedChanged(object sender, EventArgs e)
        {
            //ラジオボタンにチェックがついている場合のみ入力できる
            inputUserNm.Enabled = radioUserNm.Checked;           
        }

        /// <summary>
        /// ログインユーザーラジオボタンのつけ外し
        /// </summary>
        /// <param name="sender">イベントコントロール</param>
        /// <param name="e">イベント情報</param>
        private void radioLoginUser_CheckedChanged(object sender, EventArgs e)
        {
            //ラジオボタンにチェックがついている場合のみ選択できる
            comboLoginUser.Enabled = radioLoginUser.Checked;
        }

        /// <summary>
        /// dgv クリックしたセルの情報をメッセージボックスに表示
        /// </summary>
        /// <param name="sender">イベントコントロール</param>
        /// <param name="e">イベント引数</param>
        private void loginHis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(loginHis["dgvColumnDate", e.RowIndex].Value.ToString());
            sb.AppendLine(loginHis["dgvColumnId", e.RowIndex].Value.ToString());
            sb.AppendLine(loginHis["dgvColumnName", e.RowIndex].Value.ToString());
            sb.AppendLine(loginHis["dgvColumnDelflg", e.RowIndex].Value.ToString());
            sb.AppendLine(loginHis["dgvColumnPcName", e.RowIndex].Value.ToString());
            sb.AppendLine(loginHis["dgvColumnIp", e.RowIndex].Value.ToString());
            String cellData = sb.ToString();
            MessageBox.Show(cellData, "ユーザー情報",
                       MessageBoxButtons.OK);
        }

        private void updateHisButton_Click(object sender, EventArgs e)
        {
            using(userIndexView index = new userIndexView())
            {
                index.ShowDialog();
            }
        }
    }
}
