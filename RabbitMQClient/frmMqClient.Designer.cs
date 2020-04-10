namespace RabbitMQClient
{
    partial class frmMqClient
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCarno = new System.Windows.Forms.TextBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrintContent = new System.Windows.Forms.TextBox();
            this.txtCamera = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDb = new System.Windows.Forms.Button();
            this.btnCamera = new System.Windows.Forms.Button();
            this.richTxt = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCarno
            // 
            this.txtCarno.Location = new System.Drawing.Point(508, 41);
            this.txtCarno.Name = "txtCarno";
            this.txtCarno.Size = new System.Drawing.Size(233, 21);
            this.txtCarno.TabIndex = 19;
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(508, 78);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(233, 21);
            this.txtWeight.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(437, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "重量：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(437, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "车号：";
            // 
            // txtPrintContent
            // 
            this.txtPrintContent.Location = new System.Drawing.Point(94, 81);
            this.txtPrintContent.Multiline = true;
            this.txtPrintContent.Name = "txtPrintContent";
            this.txtPrintContent.Size = new System.Drawing.Size(233, 99);
            this.txtPrintContent.TabIndex = 15;
            // 
            // txtCamera
            // 
            this.txtCamera.Location = new System.Drawing.Point(94, 44);
            this.txtCamera.Name = "txtCamera";
            this.txtCamera.Size = new System.Drawing.Size(233, 21);
            this.txtCamera.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "内容：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "相机编号：";
            // 
            // btnDb
            // 
            this.btnDb.Location = new System.Drawing.Point(635, 200);
            this.btnDb.Name = "btnDb";
            this.btnDb.Size = new System.Drawing.Size(106, 23);
            this.btnDb.TabIndex = 11;
            this.btnDb.Text = "发送称重消息";
            this.btnDb.UseVisualStyleBackColor = true;
            this.btnDb.Click += new System.EventHandler(this.btnDb_Click);
            // 
            // btnCamera
            // 
            this.btnCamera.Location = new System.Drawing.Point(225, 200);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(102, 23);
            this.btnCamera.TabIndex = 10;
            this.btnCamera.Text = "发送摄像机消息";
            this.btnCamera.UseVisualStyleBackColor = true;
            this.btnCamera.Click += new System.EventHandler(this.btnCamera_Click);
            // 
            // richTxt
            // 
            this.richTxt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTxt.Location = new System.Drawing.Point(0, 249);
            this.richTxt.Name = "richTxt";
            this.richTxt.Size = new System.Drawing.Size(800, 378);
            this.richTxt.TabIndex = 20;
            this.richTxt.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(393, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(590, 147);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmMqClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 627);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTxt);
            this.Controls.Add(this.txtCarno);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrintContent);
            this.Controls.Add(this.txtCamera);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDb);
            this.Controls.Add(this.btnCamera);
            this.Name = "frmMqClient";
            this.Text = "客户端消息测试";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMqClient_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCarno;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrintContent;
        private System.Windows.Forms.TextBox txtCamera;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDb;
        private System.Windows.Forms.Button btnCamera;
        private System.Windows.Forms.RichTextBox richTxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

