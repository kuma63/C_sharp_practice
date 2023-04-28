using System;

namespace login
{
    partial class LoginHisView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.loginHis = new System.Windows.Forms.DataGridView();
            this.dgvColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnDelflg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnPcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserID = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.Label();
            this.LoginDate = new System.Windows.Forms.Label();
            this.inputUserId = new System.Windows.Forms.TextBox();
            this.inputUserNm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.firstDate = new System.Windows.Forms.TextBox();
            this.lastDate = new System.Windows.Forms.TextBox();
            this.delflgCheckBox = new System.Windows.Forms.CheckBox();
            this.radioUserId = new System.Windows.Forms.RadioButton();
            this.radioUserNm = new System.Windows.Forms.RadioButton();
            this.radioLoginUser = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.comboLoginUser = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.updateHisButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.loginHis)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginHis
            // 
            this.loginHis.AllowUserToAddRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(215)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.loginHis.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.loginHis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.loginHis.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(111)))), ((int)(((byte)(116)))));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(134)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.loginHis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.loginHis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.loginHis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColumnDate,
            this.dgvColumnId,
            this.dgvColumnName,
            this.dgvColumnDelflg,
            this.dgvColumnPcName,
            this.dgvColumnIp});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.loginHis.DefaultCellStyle = dataGridViewCellStyle8;
            this.loginHis.EnableHeadersVisualStyles = false;
            this.loginHis.GridColor = System.Drawing.Color.AntiqueWhite;
            this.loginHis.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.loginHis.Location = new System.Drawing.Point(8, 136);
            this.loginHis.Name = "loginHis";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.loginHis.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.loginHis.RowHeadersVisible = false;
            this.loginHis.RowHeadersWidth = 51;
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.loginHis.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.loginHis.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.loginHis.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.loginHis.RowTemplate.Height = 24;
            this.loginHis.Size = new System.Drawing.Size(984, 336);
            this.loginHis.TabIndex = 7;
            this.loginHis.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.loginHis_CellContentClick);
            this.loginHis.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.loginHisCellFormatting);
            // 
            // dgvColumnDate
            // 
            this.dgvColumnDate.HeaderText = "ログイン日";
            this.dgvColumnDate.MinimumWidth = 6;
            this.dgvColumnDate.Name = "dgvColumnDate";
            // 
            // dgvColumnId
            // 
            this.dgvColumnId.HeaderText = "ユーザーID";
            this.dgvColumnId.MinimumWidth = 6;
            this.dgvColumnId.Name = "dgvColumnId";
            // 
            // dgvColumnName
            // 
            this.dgvColumnName.HeaderText = "ユーザー名";
            this.dgvColumnName.MinimumWidth = 6;
            this.dgvColumnName.Name = "dgvColumnName";
            // 
            // dgvColumnDelflg
            // 
            this.dgvColumnDelflg.HeaderText = "ステータス";
            this.dgvColumnDelflg.MinimumWidth = 6;
            this.dgvColumnDelflg.Name = "dgvColumnDelflg";
            // 
            // dgvColumnPcName
            // 
            this.dgvColumnPcName.HeaderText = "PC名";
            this.dgvColumnPcName.MinimumWidth = 6;
            this.dgvColumnPcName.Name = "dgvColumnPcName";
            // 
            // dgvColumnIp
            // 
            this.dgvColumnIp.HeaderText = "IPアドレス";
            this.dgvColumnIp.MinimumWidth = 6;
            this.dgvColumnIp.Name = "dgvColumnIp";
            // 
            // UserID
            // 
            this.UserID.AutoSize = true;
            this.UserID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.UserID.ForeColor = System.Drawing.Color.Black;
            this.UserID.Location = new System.Drawing.Point(24, 16);
            this.UserID.Name = "UserID";
            this.UserID.Size = new System.Drawing.Size(78, 15);
            this.UserID.TabIndex = 1;
            this.UserID.Text = "ユーザーID";
            this.UserID.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Location = new System.Drawing.Point(24, 56);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(79, 15);
            this.UserName.TabIndex = 4;
            this.UserName.Text = "ユーザー名";
            this.UserName.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // LoginDate
            // 
            this.LoginDate.AutoSize = true;
            this.LoginDate.Location = new System.Drawing.Point(608, 32);
            this.LoginDate.Name = "LoginDate";
            this.LoginDate.Size = new System.Drawing.Size(74, 15);
            this.LoginDate.TabIndex = 1;
            this.LoginDate.Text = "ログイン日";
            this.LoginDate.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // inputUserId
            // 
            this.inputUserId.BackColor = System.Drawing.Color.White;
            this.inputUserId.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.inputUserId.Location = new System.Drawing.Point(104, 16);
            this.inputUserId.MaxLength = 5;
            this.inputUserId.Name = "inputUserId";
            this.inputUserId.Size = new System.Drawing.Size(56, 22);
            this.inputUserId.TabIndex = 2;
            this.inputUserId.Text = "WWWWW";
            // 
            // inputUserNm
            // 
            this.inputUserNm.BackColor = System.Drawing.Color.White;
            this.inputUserNm.Location = new System.Drawing.Point(104, 56);
            this.inputUserNm.MaxLength = 20;
            this.inputUserNm.Name = "inputUserNm";
            this.inputUserNm.Size = new System.Drawing.Size(208, 22);
            this.inputUserNm.TabIndex = 5;
            this.inputUserNm.Text = "WWWWWWWWWWWWWWWWWWWW";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(792, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "~";
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.Tomato;
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Location = new System.Drawing.Point(816, 80);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(104, 40);
            this.searchButton.TabIndex = 6;
            this.searchButton.Text = "検索";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(174)))), ((int)(((byte)(48)))));
            this.resetButton.FlatAppearance.BorderSize = 0;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetButton.Location = new System.Drawing.Point(16, 16);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(96, 40);
            this.resetButton.TabIndex = 8;
            this.resetButton.Text = "クリア";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // firstDate
            // 
            this.firstDate.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.firstDate.Location = new System.Drawing.Point(688, 32);
            this.firstDate.Name = "firstDate";
            this.firstDate.Size = new System.Drawing.Size(100, 22);
            this.firstDate.TabIndex = 2;
            // 
            // lastDate
            // 
            this.lastDate.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.lastDate.Location = new System.Drawing.Point(816, 32);
            this.lastDate.Name = "lastDate";
            this.lastDate.Size = new System.Drawing.Size(100, 22);
            this.lastDate.TabIndex = 4;
            // 
            // delflgCheckBox
            // 
            this.delflgCheckBox.AutoSize = true;
            this.delflgCheckBox.Checked = true;
            this.delflgCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.delflgCheckBox.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.delflgCheckBox.Location = new System.Drawing.Point(592, 96);
            this.delflgCheckBox.Name = "delflgCheckBox";
            this.delflgCheckBox.Size = new System.Drawing.Size(169, 18);
            this.delflgCheckBox.TabIndex = 5;
            this.delflgCheckBox.Text = "削除済みユーザーを除く";
            this.delflgCheckBox.UseVisualStyleBackColor = true;
            // 
            // radioUserId
            // 
            this.radioUserId.AutoSize = true;
            this.radioUserId.CheckAlign = System.Drawing.ContentAlignment.BottomRight;
            this.radioUserId.Location = new System.Drawing.Point(8, 16);
            this.radioUserId.Name = "radioUserId";
            this.radioUserId.Size = new System.Drawing.Size(14, 13);
            this.radioUserId.TabIndex = 0;
            this.radioUserId.TabStop = true;
            this.radioUserId.UseVisualStyleBackColor = true;
            this.radioUserId.CheckedChanged += new System.EventHandler(this.radioUserId_CheckedChanged);
            // 
            // radioUserNm
            // 
            this.radioUserNm.AutoSize = true;
            this.radioUserNm.CheckAlign = System.Drawing.ContentAlignment.BottomRight;
            this.radioUserNm.Location = new System.Drawing.Point(8, 56);
            this.radioUserNm.Name = "radioUserNm";
            this.radioUserNm.Size = new System.Drawing.Size(14, 13);
            this.radioUserNm.TabIndex = 3;
            this.radioUserNm.TabStop = true;
            this.radioUserNm.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.radioUserNm.UseVisualStyleBackColor = true;
            this.radioUserNm.CheckedChanged += new System.EventHandler(this.radioUserNm_CheckedChanged);
            // 
            // radioLoginUser
            // 
            this.radioLoginUser.AutoSize = true;
            this.radioLoginUser.CheckAlign = System.Drawing.ContentAlignment.BottomRight;
            this.radioLoginUser.Location = new System.Drawing.Point(8, 96);
            this.radioLoginUser.Name = "radioLoginUser";
            this.radioLoginUser.Size = new System.Drawing.Size(14, 13);
            this.radioLoginUser.TabIndex = 6;
            this.radioLoginUser.TabStop = true;
            this.radioLoginUser.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.radioLoginUser.UseVisualStyleBackColor = true;
            this.radioLoginUser.CheckedChanged += new System.EventHandler(this.radioLoginUser_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "ログインユーザー名";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // comboLoginUser
            // 
            this.comboLoginUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLoginUser.FormattingEnabled = true;
            this.comboLoginUser.Location = new System.Drawing.Point(160, 96);
            this.comboLoginUser.Name = "comboLoginUser";
            this.comboLoginUser.Size = new System.Drawing.Size(152, 22);
            this.comboLoginUser.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioUserId);
            this.panel1.Controls.Add(this.comboLoginUser);
            this.panel1.Controls.Add(this.UserID);
            this.panel1.Controls.Add(this.inputUserNm);
            this.panel1.Controls.Add(this.inputUserId);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.radioUserNm);
            this.panel1.Controls.Add(this.UserName);
            this.panel1.Controls.Add(this.radioLoginUser);
            this.panel1.Location = new System.Drawing.Point(176, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 136);
            this.panel1.TabIndex = 0;
            // 
            // updateHisButton
            // 
            this.updateHisButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(174)))), ((int)(((byte)(48)))));
            this.updateHisButton.FlatAppearance.BorderSize = 0;
            this.updateHisButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateHisButton.Location = new System.Drawing.Point(16, 72);
            this.updateHisButton.Name = "updateHisButton";
            this.updateHisButton.Size = new System.Drawing.Size(80, 48);
            this.updateHisButton.TabIndex = 9;
            this.updateHisButton.Text = "ユーザー一覧画面";
            this.updateHisButton.UseVisualStyleBackColor = false;
            this.updateHisButton.Click += new System.EventHandler(this.updateHisButton_Click);
            // 
            // LoginHisView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1002, 478);
            this.Controls.Add(this.updateHisButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.delflgCheckBox);
            this.Controls.Add(this.lastDate);
            this.Controls.Add(this.firstDate);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoginDate);
            this.Controls.Add(this.loginHis);
            this.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "LoginHisView";
            this.Text = "ログイン履歴画面";
            this.Load += new System.EventHandler(this.LoginHisView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loginHis)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView loginHis;
        private System.Windows.Forms.Label UserID;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.Label LoginDate;
        private System.Windows.Forms.TextBox inputUserId;
        private System.Windows.Forms.TextBox inputUserNm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.TextBox firstDate;
        private System.Windows.Forms.TextBox lastDate;
        private System.Windows.Forms.CheckBox delflgCheckBox;
        private System.Windows.Forms.RadioButton radioUserId;
        private System.Windows.Forms.RadioButton radioUserNm;
        private System.Windows.Forms.RadioButton radioLoginUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboLoginUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnDelflg;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnPcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnIp;
        private System.Windows.Forms.Button updateHisButton;
    }
}