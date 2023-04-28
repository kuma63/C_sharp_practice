using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace login
{
    public partial class userIndexView : Form
    {
        public const String enroll = "在籍";
        public const String leave = "離職";

        public userIndexView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ユーザー一覧画面読み込み
        /// </summary>
        /// <param name="sender">イベントコントロール</param>
        /// <param name="e">イベント情報</param>
        private void userIndexView_Load(object sender, EventArgs e)
        {
            //dgvとDataTableのカラムのバインド
            dgvColumnUserId.DataPropertyName = "user_id";
            dgvColumnLastNm.DataPropertyName = "last_name";
            dgvColumnFirstNm.DataPropertyName = "first_name";
            dgvColumnDelflg.DataPropertyName = "delflg";
            dgvColumnLastLoginDate.DataPropertyName = "last_login_date";
            dgvColumnModifiedDate.DataPropertyName = "modified_date";

            userIndex.Columns["dgvColumnLastLoginDate"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
            userIndex.Columns["dgvColumnModifiedDate"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss.fff";
            userIndex.ReadOnly = true;
        }

        /// <summary>
        /// 検索ボタンクリック
        /// </summary>
        /// <param name="sender">イベントコントロール</param>
        /// <param name="e">イベント情報</param>
        private void searchButton_Click(object sender, EventArgs e)
        {
            //検索SQLとパラメーターのセット
            String searchSql = "";
            OracleParameter[] param = new OracleParameter[0];
            getDgvSql(ref searchSql, ref param);

            //DBへ接続
            DataAccess access = new DataAccess();
            DataTable dt = access.ExecuteSelect(searchSql, param);

            //検索結果をデータグリッドビューに表示
            userIndex.DataSource = dt;
        }

        //検索SQL、パラメータのセット
        private void getDgvSql(ref String searchSql, ref OracleParameter[] param)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select mus.user_id,                                                              ");
            sb.AppendLine("       mus.last_name,                                                            ");
            sb.AppendLine("       mus.first_name,                                                           ");
            sb.AppendLine("       case mus.delflg when 0 then '" + enroll + "'                              ");
            sb.AppendLine("       else                                                                      ");
            sb.AppendLine("       '" + leave + "'                                                           ");
            sb.AppendLine("       end delflg,                                                               ");
            sb.AppendLine("       max(lgu.login_date) as last_login_date,                                   ");
            sb.AppendLine("       to_char(mus.modified_date, 'yyyy/mm/dd HH24:mi:ss.ff3') as modified_date  ");
            sb.AppendLine("from   admin.m_user mus                                                          ");
            sb.AppendLine("left   join admin.t_login_user lgu                                               ");
            sb.AppendLine("on     (mus.user_id = lgu.login_user_id)                                         ");

            var sqlList = new List<string>();
            var paramList = new List<OracleParameter>();

            //検索のテキストボックスに入力されている
            if(!String.IsNullOrEmpty(searchTextBox.Text))
            {
                sqlList.Add("user_id like :user_id ");
                paramList.Add(new OracleParameter(":user_id",
                                                   OracleDbType.Char,
                                                   searchTextBox.Text + "%",
                                                   ParameterDirection.Input));

                sqlList.Add("last_name like :user_name ");
                paramList.Add(new OracleParameter(":user_name",
                                                   OracleDbType.NVarchar2,
                                                   "%" + searchTextBox.Text + "%",
                                                   ParameterDirection.Input));

                sqlList.Add("first_name like :user_name ");
                paramList.Add(new OracleParameter(":user_name",
                                                   OracleDbType.NVarchar2,
                                                   "%" + searchTextBox.Text + "%",
                                                   ParameterDirection.Input));
            }

            param = new OracleParameter[paramList.Count];
            //List内あれば以下SQL、Parameter追加する
            if (sqlList.Count > 0)
            {
                sb.AppendLine("where ");
                sb.AppendLine(String.Join("or ", sqlList));
                param = paramList.ToArray();
            }

            sb.AppendLine("group by mus.user_id, mus.last_name, mus.first_name, mus.delflg, mus.modified_date");
            sb.AppendLine("order by delflg asc, user_id desc");
            searchSql = sb.ToString();
        }

        /// <summary>
        ///終了ボタンクリック 
        /// </summary>
        /// <param name="sender">イベントコントロール</param>
        /// <param name="e">イベント情報</param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 新規登録ボタンクリック
        /// </summary>
        /// <param name="sender">イベントコントロール</param>
        /// <param name="e">イベント情報</param>
        private void newUser_Click(object sender, EventArgs e)
        {
            String displayModeText = "Insert";
            using (userForm regist = new userForm(displayModeText)) 
            {
                regist.ShowDialog();
            }
        }

        /// <summary>
        /// 変更ボタンクリック
        /// </summary>
        /// <param name="sender">イベントコントロール</param>
        /// <param name="e">イベント引数</param>
        private void updateUser_Click(object sender, EventArgs e)
        {
            String displayModeText = "Update";
            using (userForm updateForm = new userForm(displayModeText))
            {
                //変更画面表示できるか
                if (updateButtonClickCheck()) return;

                //変更画面に選択ユーザーの情報を送る
                updateForm.userIdText = userIndex.CurrentRow.Cells["dgvColumnUserId"].Value.ToString();
                updateForm.lastNmText = userIndex.CurrentRow.Cells["dgvColumnLastNm"].Value.ToString();
                updateForm.firstNmText = userIndex.CurrentRow.Cells["dgvColumnFirstNm"].Value.ToString();
                updateForm.delflgText = userIndex.CurrentRow.Cells["dgvColumnDelflg"].Value.ToString();
                updateForm.modifiedDateText = userIndex.CurrentRow.Cells["dgvColumnModifiedDate"].Value.ToString();
                
                //変更画面開く
                updateForm.ShowDialog();

                //変更画面閉じた後確定ボタンが押され変更が完了している場合
                if(updateForm.updatedData)
                {
                    //変更フォームが閉じた後データグリッドビューを上書きする
                    userIndex.CurrentRow.Cells["dgvColumnUserId"].Value = updateForm.userIdText;
                    userIndex.CurrentRow.Cells["dgvColumnLastNm"].Value = updateForm.lastNmText;
                    userIndex.CurrentRow.Cells["dgvColumnFirstNm"].Value = updateForm.firstNmText;
                    userIndex.CurrentRow.Cells["dgvColumnDelflg"].Value = updateForm.delflgText;
                }               
            }
        }

        /// <summary>
        /// 変更画面表示できるか
        /// </summary>
        /// <returns>true:できない false:できる</returns>
        private bool updateButtonClickCheck()
        {
            //ユーザーを選択していないとき
            if (userIndex.SelectedRows.Count <= 0)
            {
                MessageBox.Show("ユーザーを選択してください", "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 削除ボタンクリック
        /// </summary>
        /// <param name="sender">イベントコントロール</param>
        /// <param name="e">イベント引数</param>
        private void deleteUser_Click(object sender, EventArgs e)
        {
            String displayModeText = "Delete";
            using (userForm deleteForm = new userForm(displayModeText))
            {
                //ユーザー削除画面表示できるかチェック
                if (deleteButtonClickCheck()) return;

                //削除画面に選択ユーザーの情報を送る
                deleteForm.userIdText = userIndex.CurrentRow.Cells["dgvColumnUserId"].Value.ToString();
                deleteForm.lastNmText = userIndex.CurrentRow.Cells["dgvColumnLastNm"].Value.ToString();
                deleteForm.firstNmText = userIndex.CurrentRow.Cells["dgvColumnFirstNm"].Value.ToString();
                deleteForm.delflgText = userIndex.CurrentRow.Cells["dgvColumnDelflg"].Value.ToString();
                deleteForm.modifiedDateText = userIndex.CurrentRow.Cells["dgvColumnModifiedDate"].Value.ToString();

                //削除画面を開く
                deleteForm.ShowDialog();

                //削除画面閉じた時再検索
                if (deleteForm.updatedData)
                {
                    this.searchButton.PerformClick();
                    //userIndex.CurrentRow.Cells["dgvColumnDelflg"].Value = leave;
                }

            }
        }

        /// <summary>
        /// ユーザー削除画面表示できるかチェック
        /// </summary>
        /// <returns>true:表示できない false:表示できる</returns>
        private bool deleteButtonClickCheck()
        {
            //ユーザーを選択していないとき
            if(userIndex.SelectedRows.Count <= 0) 
            {
                MessageBox.Show("ユーザーを選択してください", "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return true;
            }

            //選択しているユーザーのステータスが離職のとき
            if (userIndex.CurrentRow.Cells["dgvColumnDelflg"].Value.ToString() == leave)
            {
                MessageBox.Show("このユーザーはすでに削除済みです", "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return true;
            }

            return false;
        }

    }
}
