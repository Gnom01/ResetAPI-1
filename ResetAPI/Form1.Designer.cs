namespace ResetAPI
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textResponse = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.textUserName = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioNTLM = new System.Windows.Forms.RadioButton();
            this.radioBasik = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioNetwork = new System.Windows.Forms.RadioButton();
            this.radioYourOwn = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textCategory = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Resp URI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Response";
            // 
            // textResponse
            // 
            this.textResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textResponse.Location = new System.Drawing.Point(71, 161);
            this.textResponse.Multiline = true;
            this.textResponse.Name = "textResponse";
            this.textResponse.Size = new System.Drawing.Size(472, 206);
            this.textResponse.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(72, 13);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(385, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "https://allegro.pl/auth/oauth/token?grant_type=client_credentials";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StartButton.Location = new System.Drawing.Point(434, 10);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(104, 23);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // textUserName
            // 
            this.textUserName.Location = new System.Drawing.Point(129, 42);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(135, 20);
            this.textUserName.TabIndex = 5;
            this.textUserName.Text = "4e3b7537a4524fc7a7acbb173b7eca7f";
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(344, 41);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(133, 20);
            this.textPassword.TabIndex = 6;
            this.textPassword.Text = "cctw9ui5JNbQ1D19OZf1yu1fVMhE3SizV32aw369cKtwp9gmxpSvQS12FAEr3onN";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioNTLM);
            this.groupBox1.Controls.Add(this.radioBasik);
            this.groupBox1.Location = new System.Drawing.Point(72, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 88);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auth Typie";
            // 
            // radioNTLM
            // 
            this.radioNTLM.AutoSize = true;
            this.radioNTLM.Location = new System.Drawing.Point(6, 49);
            this.radioNTLM.Name = "radioNTLM";
            this.radioNTLM.Size = new System.Drawing.Size(99, 17);
            this.radioNTLM.TabIndex = 1;
            this.radioNTLM.TabStop = true;
            this.radioNTLM.Text = "NTLM windows";
            this.radioNTLM.UseVisualStyleBackColor = true;
            // 
            // radioBasik
            // 
            this.radioBasik.AutoSize = true;
            this.radioBasik.Checked = true;
            this.radioBasik.Location = new System.Drawing.Point(6, 19);
            this.radioBasik.Name = "radioBasik";
            this.radioBasik.Size = new System.Drawing.Size(121, 17);
            this.radioBasik.TabIndex = 0;
            this.radioBasik.TabStop = true;
            this.radioBasik.Text = "Basic Autotithication";
            this.radioBasik.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioNetwork);
            this.groupBox2.Controls.Add(this.radioYourOwn);
            this.groupBox2.Location = new System.Drawing.Point(285, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 88);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Technique";
            // 
            // radioNetwork
            // 
            this.radioNetwork.AutoSize = true;
            this.radioNetwork.Location = new System.Drawing.Point(7, 50);
            this.radioNetwork.Name = "radioNetwork";
            this.radioNetwork.Size = new System.Drawing.Size(138, 17);
            this.radioNetwork.TabIndex = 1;
            this.radioNetwork.TabStop = true;
            this.radioNetwork.Text = "NetworkCredental Class";
            this.radioNetwork.UseVisualStyleBackColor = true;
            // 
            // radioYourOwn
            // 
            this.radioYourOwn.AutoSize = true;
            this.radioYourOwn.Checked = true;
            this.radioYourOwn.Location = new System.Drawing.Point(7, 20);
            this.radioYourOwn.Name = "radioYourOwn";
            this.radioYourOwn.Size = new System.Drawing.Size(93, 17);
            this.radioYourOwn.TabIndex = 0;
            this.radioYourOwn.TabStop = true;
            this.radioYourOwn.Text = "Roll Tour Own";
            this.radioYourOwn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "User Name";
            // 
            // textCategory
            // 
            this.textCategory.Location = new System.Drawing.Point(71, 374);
            this.textCategory.Multiline = true;
            this.textCategory.Name = "textCategory";
            this.textCategory.Size = new System.Drawing.Size(467, 200);
            this.textCategory.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 374);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Text2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 586);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textCategory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textUserName);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textResponse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textResponse;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox textUserName;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioNTLM;
        private System.Windows.Forms.RadioButton radioBasik;
        private System.Windows.Forms.RadioButton radioNetwork;
        private System.Windows.Forms.RadioButton radioYourOwn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textCategory;
        private System.Windows.Forms.Label label5;
    }
}

