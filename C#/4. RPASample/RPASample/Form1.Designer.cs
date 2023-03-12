
namespace RPASample
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_prcMaximize = new System.Windows.Forms.Button();
            this.txtBox_processName = new System.Windows.Forms.TextBox();
            this.lbl_processName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_prcMaximize
            // 
            this.btn_prcMaximize.Location = new System.Drawing.Point(360, 27);
            this.btn_prcMaximize.Name = "btn_prcMaximize";
            this.btn_prcMaximize.Size = new System.Drawing.Size(75, 23);
            this.btn_prcMaximize.TabIndex = 0;
            this.btn_prcMaximize.Text = "테슷흐";
            this.btn_prcMaximize.UseVisualStyleBackColor = true;
            this.btn_prcMaximize.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBox_processName
            // 
            this.txtBox_processName.Location = new System.Drawing.Point(85, 27);
            this.txtBox_processName.Name = "txtBox_processName";
            this.txtBox_processName.Size = new System.Drawing.Size(269, 21);
            this.txtBox_processName.TabIndex = 1;
            this.txtBox_processName.Text = "DaouOfficeMessenger";
            // 
            // lbl_processName
            // 
            this.lbl_processName.AutoSize = true;
            this.lbl_processName.Location = new System.Drawing.Point(12, 32);
            this.lbl_processName.Name = "lbl_processName";
            this.lbl_processName.Size = new System.Drawing.Size(65, 12);
            this.lbl_processName.TabIndex = 2;
            this.lbl_processName.Text = "프로세스명";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 157);
            this.Controls.Add(this.lbl_processName);
            this.Controls.Add(this.txtBox_processName);
            this.Controls.Add(this.btn_prcMaximize);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_prcMaximize;
        private System.Windows.Forms.TextBox txtBox_processName;
        private System.Windows.Forms.Label lbl_processName;
    }
}

