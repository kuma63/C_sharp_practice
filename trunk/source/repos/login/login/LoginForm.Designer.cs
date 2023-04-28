using System;

namespace login
{
    partial class LoginForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inputUserId = new System.Windows.Forms.TextBox();
            this.inputPassword = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.endButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(108, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "ユーザーID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(108, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "パスワード";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // inputUserId
            // 
            this.inputUserId.BackColor = System.Drawing.Color.White;
            this.inputUserId.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.inputUserId.Location = new System.Drawing.Point(200, 53);
            this.inputUserId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inputUserId.MaxLength = 5;
            this.inputUserId.Name = "inputUserId";
            this.inputUserId.Size = new System.Drawing.Size(56, 21);
            this.inputUserId.TabIndex = 2;
            this.inputUserId.Text = "WWWWW";
            this.inputUserId.TextChanged += new System.EventHandler(this.inputUserId_TextChanged);
            // 
            // inputPassword
            // 
            this.inputPassword.BackColor = System.Drawing.Color.White;
            this.inputPassword.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.inputPassword.Location = new System.Drawing.Point(200, 91);
            this.inputPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inputPassword.MaxLength = 10;
            this.inputPassword.Name = "inputPassword";
            this.inputPassword.PasswordChar = '*';
            this.inputPassword.Size = new System.Drawing.Size(80, 21);
            this.inputPassword.TabIndex = 3;
            this.inputPassword.Text = "WWWWWWWWWW";
            this.inputPassword.TextChanged += new System.EventHandler(this.inputPassword_TextChanged);
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(79)))), ((int)(((byte)(36)))));
            this.loginButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Location = new System.Drawing.Point(200, 121);
            this.loginButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(112, 39);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "ログイン";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // endButton
            // 
            this.endButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(111)))), ((int)(((byte)(116)))));
            this.endButton.FlatAppearance.BorderSize = 0;
            this.endButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.endButton.Location = new System.Drawing.Point(328, 121);
            this.endButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.endButton.Name = "endButton";
            this.endButton.Size = new System.Drawing.Size(100, 38);
            this.endButton.TabIndex = 5;
            this.endButton.Text = "終了";
            this.endButton.UseVisualStyleBackColor = false;
            this.endButton.Click += new System.EventHandler(this.endButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(174)))), ((int)(((byte)(48)))));
            this.clearButton.FlatAppearance.BorderSize = 0;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Location = new System.Drawing.Point(16, 16);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(88, 32);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "クリア";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(443, 176);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.endButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.inputPassword);
            this.Controls.Add(this.inputUserId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LoginForm";
            this.Text = "ログイン画面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputUserId;
        private System.Windows.Forms.TextBox inputPassword;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button endButton;
        private System.Windows.Forms.Button clearButton;
    }
}

