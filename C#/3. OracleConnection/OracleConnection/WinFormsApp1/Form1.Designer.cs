namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpBox_connState = new System.Windows.Forms.GroupBox();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.lbl_ServiceName = new System.Windows.Forms.Label();
            this.lbl_conState = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl_oraID = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpBox_connInfo = new System.Windows.Forms.GroupBox();
            this.lbl_oraPW = new System.Windows.Forms.Label();
            this.lbl_oraID = new System.Windows.Forms.Label();
            this.txtBox_oraPW = new System.Windows.Forms.TextBox();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.txtBox_oraID = new System.Windows.Forms.TextBox();
            this.grpBox_sql = new System.Windows.Forms.GroupBox();
            this.btn_RunSQL = new System.Windows.Forms.Button();
            this.richTxt_sql = new System.Windows.Forms.RichTextBox();
            this.gridView_result = new System.Windows.Forms.DataGridView();
            this.grpBox_connState.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.grpBox_connInfo.SuspendLayout();
            this.grpBox_sql.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_result)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBox_connState
            // 
            this.grpBox_connState.Controls.Add(this.lbl_Version);
            this.grpBox_connState.Controls.Add(this.lbl_ServiceName);
            this.grpBox_connState.Controls.Add(this.lbl_conState);
            this.grpBox_connState.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpBox_connState.Location = new System.Drawing.Point(12, 8);
            this.grpBox_connState.Name = "grpBox_connState";
            this.grpBox_connState.Size = new System.Drawing.Size(345, 92);
            this.grpBox_connState.TabIndex = 7;
            this.grpBox_connState.TabStop = false;
            this.grpBox_connState.Text = "상태";
            // 
            // lbl_Version
            // 
            this.lbl_Version.AutoSize = true;
            this.lbl_Version.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Version.Location = new System.Drawing.Point(6, 63);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(39, 14);
            this.lbl_Version.TabIndex = 5;
            this.lbl_Version.Text = "버전 : ";
            // 
            // lbl_ServiceName
            // 
            this.lbl_ServiceName.AutoSize = true;
            this.lbl_ServiceName.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_ServiceName.Location = new System.Drawing.Point(6, 40);
            this.lbl_ServiceName.Name = "lbl_ServiceName";
            this.lbl_ServiceName.Size = new System.Drawing.Size(83, 14);
            this.lbl_ServiceName.TabIndex = 4;
            this.lbl_ServiceName.Text = "데이터베이스 : ";
            // 
            // lbl_conState
            // 
            this.lbl_conState.AutoSize = true;
            this.lbl_conState.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_conState.Location = new System.Drawing.Point(6, 17);
            this.lbl_conState.Name = "lbl_conState";
            this.lbl_conState.Size = new System.Drawing.Size(61, 14);
            this.lbl_conState.TabIndex = 3;
            this.lbl_conState.Text = "[연결안됨]";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_oraID});
            this.statusStrip1.Location = new System.Drawing.Point(0, 587);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1235, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl_oraID
            // 
            this.tssl_oraID.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tssl_oraID.Name = "tssl_oraID";
            this.tssl_oraID.Size = new System.Drawing.Size(0, 17);
            // 
            // grpBox_connInfo
            // 
            this.grpBox_connInfo.Controls.Add(this.lbl_oraPW);
            this.grpBox_connInfo.Controls.Add(this.lbl_oraID);
            this.grpBox_connInfo.Controls.Add(this.txtBox_oraPW);
            this.grpBox_connInfo.Controls.Add(this.btn_Connect);
            this.grpBox_connInfo.Controls.Add(this.txtBox_oraID);
            this.grpBox_connInfo.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpBox_connInfo.Location = new System.Drawing.Point(12, 106);
            this.grpBox_connInfo.Name = "grpBox_connInfo";
            this.grpBox_connInfo.Size = new System.Drawing.Size(345, 80);
            this.grpBox_connInfo.TabIndex = 9;
            this.grpBox_connInfo.TabStop = false;
            this.grpBox_connInfo.Text = "접속정보 입력";
            // 
            // lbl_oraPW
            // 
            this.lbl_oraPW.AutoSize = true;
            this.lbl_oraPW.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_oraPW.Location = new System.Drawing.Point(14, 50);
            this.lbl_oraPW.Name = "lbl_oraPW";
            this.lbl_oraPW.Size = new System.Drawing.Size(26, 14);
            this.lbl_oraPW.TabIndex = 11;
            this.lbl_oraPW.Text = "PW";
            // 
            // lbl_oraID
            // 
            this.lbl_oraID.AutoSize = true;
            this.lbl_oraID.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_oraID.Location = new System.Drawing.Point(14, 23);
            this.lbl_oraID.Name = "lbl_oraID";
            this.lbl_oraID.Size = new System.Drawing.Size(19, 14);
            this.lbl_oraID.TabIndex = 10;
            this.lbl_oraID.Text = "ID";
            // 
            // txtBox_oraPW
            // 
            this.txtBox_oraPW.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBox_oraPW.Location = new System.Drawing.Point(59, 47);
            this.txtBox_oraPW.Name = "txtBox_oraPW";
            this.txtBox_oraPW.PasswordChar = '●';
            this.txtBox_oraPW.Size = new System.Drawing.Size(184, 21);
            this.txtBox_oraPW.TabIndex = 8;
            // 
            // btn_Connect
            // 
            this.btn_Connect.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Connect.Location = new System.Drawing.Point(249, 20);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(84, 48);
            this.btn_Connect.TabIndex = 9;
            this.btn_Connect.Text = "연결 테스트";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // txtBox_oraID
            // 
            this.txtBox_oraID.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBox_oraID.Location = new System.Drawing.Point(59, 20);
            this.txtBox_oraID.Name = "txtBox_oraID";
            this.txtBox_oraID.Size = new System.Drawing.Size(184, 21);
            this.txtBox_oraID.TabIndex = 7;
            // 
            // grpBox_sql
            // 
            this.grpBox_sql.Controls.Add(this.btn_RunSQL);
            this.grpBox_sql.Controls.Add(this.richTxt_sql);
            this.grpBox_sql.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpBox_sql.Location = new System.Drawing.Point(363, 12);
            this.grpBox_sql.Name = "grpBox_sql";
            this.grpBox_sql.Size = new System.Drawing.Size(860, 386);
            this.grpBox_sql.TabIndex = 10;
            this.grpBox_sql.TabStop = false;
            this.grpBox_sql.Text = "sql";
            // 
            // btn_RunSQL
            // 
            this.btn_RunSQL.Location = new System.Drawing.Point(774, 356);
            this.btn_RunSQL.Name = "btn_RunSQL";
            this.btn_RunSQL.Size = new System.Drawing.Size(80, 23);
            this.btn_RunSQL.TabIndex = 1;
            this.btn_RunSQL.Text = "SQL 실행";
            this.btn_RunSQL.UseVisualStyleBackColor = true;
            this.btn_RunSQL.Click += new System.EventHandler(this.btn_RunSQL_Click);
            // 
            // richTxt_sql
            // 
            this.richTxt_sql.Enabled = false;
            this.richTxt_sql.Location = new System.Drawing.Point(6, 20);
            this.richTxt_sql.Name = "richTxt_sql";
            this.richTxt_sql.Size = new System.Drawing.Size(848, 331);
            this.richTxt_sql.TabIndex = 0;
            this.richTxt_sql.Text = "";
            // 
            // gridView_result
            // 
            this.gridView_result.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gridView_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_result.Location = new System.Drawing.Point(12, 404);
            this.gridView_result.Name = "gridView_result";
            this.gridView_result.RowTemplate.Height = 25;
            this.gridView_result.Size = new System.Drawing.Size(1211, 174);
            this.gridView_result.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 609);
            this.Controls.Add(this.gridView_result);
            this.Controls.Add(this.grpBox_sql);
            this.Controls.Add(this.grpBox_connInfo);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpBox_connState);
            this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.grpBox_connState.ResumeLayout(false);
            this.grpBox_connState.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpBox_connInfo.ResumeLayout(false);
            this.grpBox_connInfo.PerformLayout();
            this.grpBox_sql.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView_result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GroupBox grpBox_connState;
        private Label lbl_Version;
        private Label lbl_ServiceName;
        private Label lbl_conState;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tssl_oraID;
        private GroupBox grpBox_connInfo;
        private Label lbl_oraPW;
        private Label lbl_oraID;
        private TextBox txtBox_oraPW;
        private Button btn_Connect;
        private TextBox txtBox_oraID;
        private GroupBox grpBox_sql;
        private RichTextBox richTxt_sql;
        private Button btn_RunSQL;
        private DataGridView gridView_result;
    }
}