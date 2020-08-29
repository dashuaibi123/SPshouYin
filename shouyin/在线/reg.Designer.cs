namespace shouyin
{
    partial class reg
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
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialSingleLineTextField1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialSingleLineTextField2 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialSingleLineTextField3 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialSingleLineTextField4 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialFlatButton2 = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Location = new System.Drawing.Point(146, 168);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(87, 36);
            this.materialFlatButton1.TabIndex = 7;
            this.materialFlatButton1.Text = "获取验证码";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(21, 73);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(108, 19);
            this.materialLabel1.TabIndex = 8;
            this.materialLabel1.Text = "materialLabel1";
            // 
            // materialSingleLineTextField1
            // 
            this.materialSingleLineTextField1.AllowDrop = true;
            this.materialSingleLineTextField1.Depth = 0;
            this.materialSingleLineTextField1.Hint = "";
            this.materialSingleLineTextField1.Location = new System.Drawing.Point(54, 123);
            this.materialSingleLineTextField1.MaxLength = 32767;
            this.materialSingleLineTextField1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField1.Name = "materialSingleLineTextField1";
            this.materialSingleLineTextField1.PasswordChar = '\0';
            this.materialSingleLineTextField1.SelectedText = "";
            this.materialSingleLineTextField1.SelectionLength = 0;
            this.materialSingleLineTextField1.SelectionStart = 0;
            this.materialSingleLineTextField1.Size = new System.Drawing.Size(75, 23);
            this.materialSingleLineTextField1.TabIndex = 9;
            this.materialSingleLineTextField1.TabStop = false;
            this.materialSingleLineTextField1.Text = "账号";
            this.materialSingleLineTextField1.UseSystemPasswordChar = false;
            this.materialSingleLineTextField1.Enter += new System.EventHandler(this.materialSingleLineTextField1_Enter);
            this.materialSingleLineTextField1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.materialSingleLineTextField1_KeyPress);
            this.materialSingleLineTextField1.Leave += new System.EventHandler(this.materialSingleLineTextField1_Leave);
            this.materialSingleLineTextField1.TextChanged += new System.EventHandler(this.materialSingleLineTextField1_TextChanged);
            // 
            // materialSingleLineTextField2
            // 
            this.materialSingleLineTextField2.Depth = 0;
            this.materialSingleLineTextField2.Hint = "";
            this.materialSingleLineTextField2.Location = new System.Drawing.Point(54, 152);
            this.materialSingleLineTextField2.MaxLength = 32767;
            this.materialSingleLineTextField2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField2.Name = "materialSingleLineTextField2";
            this.materialSingleLineTextField2.PasswordChar = '\0';
            this.materialSingleLineTextField2.SelectedText = "";
            this.materialSingleLineTextField2.SelectionLength = 0;
            this.materialSingleLineTextField2.SelectionStart = 0;
            this.materialSingleLineTextField2.Size = new System.Drawing.Size(75, 23);
            this.materialSingleLineTextField2.TabIndex = 10;
            this.materialSingleLineTextField2.TabStop = false;
            this.materialSingleLineTextField2.Text = "密码";
            this.materialSingleLineTextField2.UseSystemPasswordChar = false;
            this.materialSingleLineTextField2.Enter += new System.EventHandler(this.materialSingleLineTextField2_Enter);
            this.materialSingleLineTextField2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.materialSingleLineTextField2_KeyPress);
            this.materialSingleLineTextField2.Leave += new System.EventHandler(this.materialSingleLineTextField2_Leave);
            // 
            // materialSingleLineTextField3
            // 
            this.materialSingleLineTextField3.Depth = 0;
            this.materialSingleLineTextField3.Hint = "";
            this.materialSingleLineTextField3.Location = new System.Drawing.Point(54, 181);
            this.materialSingleLineTextField3.MaxLength = 11;
            this.materialSingleLineTextField3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField3.Name = "materialSingleLineTextField3";
            this.materialSingleLineTextField3.PasswordChar = '\0';
            this.materialSingleLineTextField3.SelectedText = "";
            this.materialSingleLineTextField3.SelectionLength = 0;
            this.materialSingleLineTextField3.SelectionStart = 0;
            this.materialSingleLineTextField3.Size = new System.Drawing.Size(75, 23);
            this.materialSingleLineTextField3.TabIndex = 11;
            this.materialSingleLineTextField3.TabStop = false;
            this.materialSingleLineTextField3.Text = "手机号码";
            this.materialSingleLineTextField3.UseSystemPasswordChar = false;
            this.materialSingleLineTextField3.Click += new System.EventHandler(this.materialSingleLineTextField3_Click);
            this.materialSingleLineTextField3.Enter += new System.EventHandler(this.materialSingleLineTextField3_Enter);
            this.materialSingleLineTextField3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.materialSingleLineTextField3_KeyPress);
            this.materialSingleLineTextField3.Leave += new System.EventHandler(this.materialSingleLineTextField3_Leave);
            // 
            // materialSingleLineTextField4
            // 
            this.materialSingleLineTextField4.Depth = 0;
            this.materialSingleLineTextField4.Hint = "";
            this.materialSingleLineTextField4.Location = new System.Drawing.Point(54, 211);
            this.materialSingleLineTextField4.MaxLength = 32767;
            this.materialSingleLineTextField4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField4.Name = "materialSingleLineTextField4";
            this.materialSingleLineTextField4.PasswordChar = '\0';
            this.materialSingleLineTextField4.SelectedText = "";
            this.materialSingleLineTextField4.SelectionLength = 0;
            this.materialSingleLineTextField4.SelectionStart = 0;
            this.materialSingleLineTextField4.Size = new System.Drawing.Size(75, 23);
            this.materialSingleLineTextField4.TabIndex = 12;
            this.materialSingleLineTextField4.TabStop = false;
            this.materialSingleLineTextField4.Text = "验证码";
            this.materialSingleLineTextField4.UseSystemPasswordChar = false;
            this.materialSingleLineTextField4.Enter += new System.EventHandler(this.materialSingleLineTextField4_Enter);
            this.materialSingleLineTextField4.Leave += new System.EventHandler(this.materialSingleLineTextField4_Leave);
            // 
            // materialFlatButton2
            // 
            this.materialFlatButton2.AutoSize = true;
            this.materialFlatButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton2.Depth = 0;
            this.materialFlatButton2.Location = new System.Drawing.Point(114, 256);
            this.materialFlatButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton2.Name = "materialFlatButton2";
            this.materialFlatButton2.Primary = false;
            this.materialFlatButton2.Size = new System.Drawing.Size(42, 36);
            this.materialFlatButton2.TabIndex = 13;
            this.materialFlatButton2.Text = "注册";
            this.materialFlatButton2.UseVisualStyleBackColor = true;
            this.materialFlatButton2.Click += new System.EventHandler(this.materialFlatButton2_Click);
            // 
            // reg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(267, 307);
            this.Controls.Add(this.materialFlatButton2);
            this.Controls.Add(this.materialSingleLineTextField4);
            this.Controls.Add(this.materialSingleLineTextField3);
            this.Controls.Add(this.materialSingleLineTextField2);
            this.Controls.Add(this.materialSingleLineTextField1);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialFlatButton1);
            this.Name = "reg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.reg_FormClosed);
            this.Load += new System.EventHandler(this.reg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField1;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField2;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField3;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField4;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton2;
    }
}