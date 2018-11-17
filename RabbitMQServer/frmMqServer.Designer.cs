namespace RabbitMQServer
{
    partial class frmMqServer
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnRoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCarno = new System.Windows.Forms.TextBox();
            this.txtPrintContent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRoadContent = new System.Windows.Forms.TextBox();
            this.txtRoadgate = new System.Windows.Forms.TextBox();
            this.richTxt = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(226, 207);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(113, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "发送打印消息";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnRoad
            // 
            this.btnRoad.Location = new System.Drawing.Point(642, 207);
            this.btnRoad.Name = "btnRoad";
            this.btnRoad.Size = new System.Drawing.Size(111, 23);
            this.btnRoad.TabIndex = 1;
            this.btnRoad.Text = "发送道闸消息";
            this.btnRoad.UseVisualStyleBackColor = true;
            this.btnRoad.Click += new System.EventHandler(this.btnRoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "车号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "内容：";
            // 
            // txtCarno
            // 
            this.txtCarno.Location = new System.Drawing.Point(106, 51);
            this.txtCarno.Name = "txtCarno";
            this.txtCarno.Size = new System.Drawing.Size(233, 21);
            this.txtCarno.TabIndex = 4;
            // 
            // txtPrintContent
            // 
            this.txtPrintContent.Location = new System.Drawing.Point(106, 88);
            this.txtPrintContent.Multiline = true;
            this.txtPrintContent.Name = "txtPrintContent";
            this.txtPrintContent.Size = new System.Drawing.Size(233, 99);
            this.txtPrintContent.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(449, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "道闸编号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "道闸测试内容：";
            // 
            // txtRoadContent
            // 
            this.txtRoadContent.Location = new System.Drawing.Point(520, 85);
            this.txtRoadContent.Multiline = true;
            this.txtRoadContent.Name = "txtRoadContent";
            this.txtRoadContent.Size = new System.Drawing.Size(233, 99);
            this.txtRoadContent.TabIndex = 8;
            // 
            // txtRoadgate
            // 
            this.txtRoadgate.Location = new System.Drawing.Point(520, 48);
            this.txtRoadgate.Name = "txtRoadgate";
            this.txtRoadgate.Size = new System.Drawing.Size(233, 21);
            this.txtRoadgate.TabIndex = 9;
            // 
            // richTxt
            // 
            this.richTxt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTxt.Location = new System.Drawing.Point(0, 259);
            this.richTxt.Name = "richTxt";
            this.richTxt.Size = new System.Drawing.Size(832, 333);
            this.richTxt.TabIndex = 10;
            this.richTxt.Text = "";
            // 
            // frmMqServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 592);
            this.Controls.Add(this.richTxt);
            this.Controls.Add(this.txtRoadgate);
            this.Controls.Add(this.txtRoadContent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrintContent);
            this.Controls.Add(this.txtCarno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRoad);
            this.Controls.Add(this.btnPrint);
            this.Name = "frmMqServer";
            this.Text = "服务端消息发送接收";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMqServer_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnRoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCarno;
        private System.Windows.Forms.TextBox txtPrintContent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRoadContent;
        private System.Windows.Forms.TextBox txtRoadgate;
        private System.Windows.Forms.RichTextBox richTxt;
    }
}

