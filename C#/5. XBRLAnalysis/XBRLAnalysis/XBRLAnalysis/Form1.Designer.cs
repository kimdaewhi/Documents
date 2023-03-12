namespace XBRLAnalysis
{
    partial class XBRLAnalysis
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
            this.tv_xbrlList = new System.Windows.Forms.TreeView();
            this.pnl_Left = new System.Windows.Forms.Panel();
            this.grpBox_TreeList = new System.Windows.Forms.GroupBox();
            this.pnl_LeftTop = new System.Windows.Forms.Panel();
            this.pnl_treeView1 = new System.Windows.Forms.Panel();
            this.pnl_treeViewInfo = new System.Windows.Forms.Panel();
            this.lbl_ext = new System.Windows.Forms.Label();
            this.checkBox_ExpandTree = new System.Windows.Forms.CheckBox();
            this.pnl_Right = new System.Windows.Forms.Panel();
            this.pnl_RightBottom = new System.Windows.Forms.Panel();
            this.btn_ToExcel = new System.Windows.Forms.Button();
            this.btn_ConsoleClear = new System.Windows.Forms.Button();
            this.pnl_RightTop = new System.Windows.Forms.Panel();
            this.groupBox_FilePath = new System.Windows.Forms.GroupBox();
            this.btn_MergeDT = new System.Windows.Forms.Button();
            this.btn_Test2 = new System.Windows.Forms.Button();
            this.btn_Test = new System.Windows.Forms.Button();
            this.txtBox_Console = new System.Windows.Forms.TextBox();
            this.radio_LinkCal = new System.Windows.Forms.RadioButton();
            this.radio_LinkDim = new System.Windows.Forms.RadioButton();
            this.radio_LinkPre = new System.Windows.Forms.RadioButton();
            this.radio_LabelEn = new System.Windows.Forms.RadioButton();
            this.btn_OpenFileDialog2 = new System.Windows.Forms.Button();
            this.btn_ConvertXbrl2 = new System.Windows.Forms.Button();
            this.lbl_FilePath2 = new System.Windows.Forms.Label();
            this.txt_xbrlFilePath2 = new System.Windows.Forms.TextBox();
            this.btn_OpenFileDialog = new System.Windows.Forms.Button();
            this.lbl_fileType = new System.Windows.Forms.Label();
            this.radio_LabelKo = new System.Windows.Forms.RadioButton();
            this.radio_XBRL = new System.Windows.Forms.RadioButton();
            this.btn_ConvertXbrl = new System.Windows.Forms.Button();
            this.lbl_FilePath1 = new System.Windows.Forms.Label();
            this.txt_xbrlFilePath1 = new System.Windows.Forms.TextBox();
            this.pnl_Left.SuspendLayout();
            this.grpBox_TreeList.SuspendLayout();
            this.pnl_LeftTop.SuspendLayout();
            this.pnl_treeView1.SuspendLayout();
            this.pnl_treeViewInfo.SuspendLayout();
            this.pnl_Right.SuspendLayout();
            this.pnl_RightBottom.SuspendLayout();
            this.pnl_RightTop.SuspendLayout();
            this.groupBox_FilePath.SuspendLayout();
            this.SuspendLayout();
            // 
            // tv_xbrlList
            // 
            this.tv_xbrlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_xbrlList.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tv_xbrlList.Location = new System.Drawing.Point(0, 33);
            this.tv_xbrlList.Name = "tv_xbrlList";
            this.tv_xbrlList.Size = new System.Drawing.Size(457, 563);
            this.tv_xbrlList.TabIndex = 1;
            // 
            // pnl_Left
            // 
            this.pnl_Left.Controls.Add(this.grpBox_TreeList);
            this.pnl_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_Left.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnl_Left.Location = new System.Drawing.Point(0, 0);
            this.pnl_Left.Name = "pnl_Left";
            this.pnl_Left.Size = new System.Drawing.Size(463, 616);
            this.pnl_Left.TabIndex = 2;
            // 
            // grpBox_TreeList
            // 
            this.grpBox_TreeList.Controls.Add(this.pnl_LeftTop);
            this.grpBox_TreeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBox_TreeList.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grpBox_TreeList.Location = new System.Drawing.Point(0, 0);
            this.grpBox_TreeList.Name = "grpBox_TreeList";
            this.grpBox_TreeList.Size = new System.Drawing.Size(463, 616);
            this.grpBox_TreeList.TabIndex = 3;
            this.grpBox_TreeList.TabStop = false;
            this.grpBox_TreeList.Text = "xbrl";
            // 
            // pnl_LeftTop
            // 
            this.pnl_LeftTop.Controls.Add(this.pnl_treeView1);
            this.pnl_LeftTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_LeftTop.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnl_LeftTop.Location = new System.Drawing.Point(3, 17);
            this.pnl_LeftTop.Name = "pnl_LeftTop";
            this.pnl_LeftTop.Size = new System.Drawing.Size(457, 596);
            this.pnl_LeftTop.TabIndex = 0;
            // 
            // pnl_treeView1
            // 
            this.pnl_treeView1.Controls.Add(this.tv_xbrlList);
            this.pnl_treeView1.Controls.Add(this.pnl_treeViewInfo);
            this.pnl_treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_treeView1.Location = new System.Drawing.Point(0, 0);
            this.pnl_treeView1.Name = "pnl_treeView1";
            this.pnl_treeView1.Size = new System.Drawing.Size(457, 596);
            this.pnl_treeView1.TabIndex = 2;
            // 
            // pnl_treeViewInfo
            // 
            this.pnl_treeViewInfo.Controls.Add(this.lbl_ext);
            this.pnl_treeViewInfo.Controls.Add(this.checkBox_ExpandTree);
            this.pnl_treeViewInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_treeViewInfo.Location = new System.Drawing.Point(0, 0);
            this.pnl_treeViewInfo.Name = "pnl_treeViewInfo";
            this.pnl_treeViewInfo.Size = new System.Drawing.Size(457, 33);
            this.pnl_treeViewInfo.TabIndex = 13;
            // 
            // lbl_ext
            // 
            this.lbl_ext.AutoSize = true;
            this.lbl_ext.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_ext.Location = new System.Drawing.Point(371, 9);
            this.lbl_ext.Name = "lbl_ext";
            this.lbl_ext.Size = new System.Drawing.Size(50, 14);
            this.lbl_ext.TabIndex = 12;
            this.lbl_ext.Text = "확장자 : ";
            // 
            // checkBox_ExpandTree
            // 
            this.checkBox_ExpandTree.AutoSize = true;
            this.checkBox_ExpandTree.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBox_ExpandTree.Location = new System.Drawing.Point(9, 8);
            this.checkBox_ExpandTree.Name = "checkBox_ExpandTree";
            this.checkBox_ExpandTree.Size = new System.Drawing.Size(59, 18);
            this.checkBox_ExpandTree.TabIndex = 3;
            this.checkBox_ExpandTree.Text = "펼치기";
            this.checkBox_ExpandTree.UseVisualStyleBackColor = true;
            this.checkBox_ExpandTree.CheckedChanged += new System.EventHandler(this.checkBox_ExpandTree_CheckedChanged);
            // 
            // pnl_Right
            // 
            this.pnl_Right.Controls.Add(this.pnl_RightBottom);
            this.pnl_Right.Controls.Add(this.pnl_RightTop);
            this.pnl_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Right.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnl_Right.Location = new System.Drawing.Point(463, 0);
            this.pnl_Right.Name = "pnl_Right";
            this.pnl_Right.Size = new System.Drawing.Size(871, 616);
            this.pnl_Right.TabIndex = 5;
            // 
            // pnl_RightBottom
            // 
            this.pnl_RightBottom.Controls.Add(this.btn_ToExcel);
            this.pnl_RightBottom.Controls.Add(this.btn_ConsoleClear);
            this.pnl_RightBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_RightBottom.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnl_RightBottom.Location = new System.Drawing.Point(0, 559);
            this.pnl_RightBottom.Name = "pnl_RightBottom";
            this.pnl_RightBottom.Size = new System.Drawing.Size(871, 57);
            this.pnl_RightBottom.TabIndex = 11;
            // 
            // btn_ToExcel
            // 
            this.btn_ToExcel.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_ToExcel.Location = new System.Drawing.Point(784, 12);
            this.btn_ToExcel.Name = "btn_ToExcel";
            this.btn_ToExcel.Size = new System.Drawing.Size(75, 23);
            this.btn_ToExcel.TabIndex = 14;
            this.btn_ToExcel.Text = "Excel 출력";
            this.btn_ToExcel.UseVisualStyleBackColor = true;
            this.btn_ToExcel.Click += new System.EventHandler(this.btn_ToExcel_Click);
            // 
            // btn_ConsoleClear
            // 
            this.btn_ConsoleClear.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_ConsoleClear.Location = new System.Drawing.Point(703, 12);
            this.btn_ConsoleClear.Name = "btn_ConsoleClear";
            this.btn_ConsoleClear.Size = new System.Drawing.Size(75, 23);
            this.btn_ConsoleClear.TabIndex = 13;
            this.btn_ConsoleClear.Text = "삭제";
            this.btn_ConsoleClear.UseVisualStyleBackColor = true;
            this.btn_ConsoleClear.Click += new System.EventHandler(this.btn_ConsoleClear_Click);
            // 
            // pnl_RightTop
            // 
            this.pnl_RightTop.Controls.Add(this.groupBox_FilePath);
            this.pnl_RightTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_RightTop.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnl_RightTop.Location = new System.Drawing.Point(0, 0);
            this.pnl_RightTop.Name = "pnl_RightTop";
            this.pnl_RightTop.Size = new System.Drawing.Size(871, 616);
            this.pnl_RightTop.TabIndex = 10;
            // 
            // groupBox_FilePath
            // 
            this.groupBox_FilePath.Controls.Add(this.btn_MergeDT);
            this.groupBox_FilePath.Controls.Add(this.btn_Test2);
            this.groupBox_FilePath.Controls.Add(this.btn_Test);
            this.groupBox_FilePath.Controls.Add(this.txtBox_Console);
            this.groupBox_FilePath.Controls.Add(this.radio_LinkCal);
            this.groupBox_FilePath.Controls.Add(this.radio_LinkDim);
            this.groupBox_FilePath.Controls.Add(this.radio_LinkPre);
            this.groupBox_FilePath.Controls.Add(this.radio_LabelEn);
            this.groupBox_FilePath.Controls.Add(this.btn_OpenFileDialog2);
            this.groupBox_FilePath.Controls.Add(this.btn_ConvertXbrl2);
            this.groupBox_FilePath.Controls.Add(this.lbl_FilePath2);
            this.groupBox_FilePath.Controls.Add(this.txt_xbrlFilePath2);
            this.groupBox_FilePath.Controls.Add(this.btn_OpenFileDialog);
            this.groupBox_FilePath.Controls.Add(this.lbl_fileType);
            this.groupBox_FilePath.Controls.Add(this.radio_LabelKo);
            this.groupBox_FilePath.Controls.Add(this.radio_XBRL);
            this.groupBox_FilePath.Controls.Add(this.btn_ConvertXbrl);
            this.groupBox_FilePath.Controls.Add(this.lbl_FilePath1);
            this.groupBox_FilePath.Controls.Add(this.txt_xbrlFilePath1);
            this.groupBox_FilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_FilePath.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox_FilePath.Location = new System.Drawing.Point(0, 0);
            this.groupBox_FilePath.Name = "groupBox_FilePath";
            this.groupBox_FilePath.Size = new System.Drawing.Size(871, 616);
            this.groupBox_FilePath.TabIndex = 8;
            this.groupBox_FilePath.TabStop = false;
            this.groupBox_FilePath.Text = "파일경로";
            // 
            // btn_MergeDT
            // 
            this.btn_MergeDT.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_MergeDT.Location = new System.Drawing.Point(784, 115);
            this.btn_MergeDT.Name = "btn_MergeDT";
            this.btn_MergeDT.Size = new System.Drawing.Size(75, 44);
            this.btn_MergeDT.TabIndex = 27;
            this.btn_MergeDT.Text = "계정명 매핑/엑셀 출력";
            this.btn_MergeDT.UseVisualStyleBackColor = true;
            this.btn_MergeDT.Click += new System.EventHandler(this.btn_MergeDT_Click);
            // 
            // btn_Test2
            // 
            this.btn_Test2.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Test2.Location = new System.Drawing.Point(675, 511);
            this.btn_Test2.Name = "btn_Test2";
            this.btn_Test2.Size = new System.Drawing.Size(75, 23);
            this.btn_Test2.TabIndex = 15;
            this.btn_Test2.Text = "Test2";
            this.btn_Test2.UseVisualStyleBackColor = true;
            this.btn_Test2.Click += new System.EventHandler(this.btn_Test2_Click);
            // 
            // btn_Test
            // 
            this.btn_Test.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Test.Location = new System.Drawing.Point(768, 511);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(75, 23);
            this.btn_Test.TabIndex = 5;
            this.btn_Test.Text = "Test";
            this.btn_Test.UseVisualStyleBackColor = true;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // txtBox_Console
            // 
            this.txtBox_Console.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtBox_Console.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBox_Console.Location = new System.Drawing.Point(3, 165);
            this.txtBox_Console.Multiline = true;
            this.txtBox_Console.Name = "txtBox_Console";
            this.txtBox_Console.ReadOnly = true;
            this.txtBox_Console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBox_Console.Size = new System.Drawing.Size(865, 448);
            this.txtBox_Console.TabIndex = 8;
            // 
            // radio_LinkCal
            // 
            this.radio_LinkCal.AutoSize = true;
            this.radio_LinkCal.Location = new System.Drawing.Point(529, 21);
            this.radio_LinkCal.Name = "radio_LinkCal";
            this.radio_LinkCal.Size = new System.Drawing.Size(78, 18);
            this.radio_LinkCal.TabIndex = 26;
            this.radio_LinkCal.TabStop = true;
            this.radio_LinkCal.Text = "Link(CAL)";
            this.radio_LinkCal.UseVisualStyleBackColor = true;
            this.radio_LinkCal.CheckedChanged += new System.EventHandler(this.radio_LinkCal_CheckedChanged);
            // 
            // radio_LinkDim
            // 
            this.radio_LinkDim.AutoSize = true;
            this.radio_LinkDim.Location = new System.Drawing.Point(435, 21);
            this.radio_LinkDim.Name = "radio_LinkDim";
            this.radio_LinkDim.Size = new System.Drawing.Size(79, 18);
            this.radio_LinkDim.TabIndex = 25;
            this.radio_LinkDim.TabStop = true;
            this.radio_LinkDim.Text = "Link(DIM)";
            this.radio_LinkDim.UseVisualStyleBackColor = true;
            this.radio_LinkDim.CheckedChanged += new System.EventHandler(this.radio_LinkDim_CheckedChanged);
            // 
            // radio_LinkPre
            // 
            this.radio_LinkPre.AutoSize = true;
            this.radio_LinkPre.Location = new System.Drawing.Point(341, 21);
            this.radio_LinkPre.Name = "radio_LinkPre";
            this.radio_LinkPre.Size = new System.Drawing.Size(76, 18);
            this.radio_LinkPre.TabIndex = 24;
            this.radio_LinkPre.TabStop = true;
            this.radio_LinkPre.Text = "Link(PRE)";
            this.radio_LinkPre.UseVisualStyleBackColor = true;
            this.radio_LinkPre.CheckedChanged += new System.EventHandler(this.radio_LinkPre_CheckedChanged);
            // 
            // radio_LabelEn
            // 
            this.radio_LabelEn.AutoSize = true;
            this.radio_LabelEn.Location = new System.Drawing.Point(247, 21);
            this.radio_LabelEn.Name = "radio_LabelEn";
            this.radio_LabelEn.Size = new System.Drawing.Size(79, 18);
            this.radio_LabelEn.TabIndex = 23;
            this.radio_LabelEn.TabStop = true;
            this.radio_LabelEn.Text = "Label(EN)";
            this.radio_LabelEn.UseVisualStyleBackColor = true;
            this.radio_LabelEn.CheckedChanged += new System.EventHandler(this.radio_LabelEn_CheckedChanged);
            // 
            // btn_OpenFileDialog2
            // 
            this.btn_OpenFileDialog2.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_OpenFileDialog2.Location = new System.Drawing.Point(756, 83);
            this.btn_OpenFileDialog2.Name = "btn_OpenFileDialog2";
            this.btn_OpenFileDialog2.Size = new System.Drawing.Size(28, 23);
            this.btn_OpenFileDialog2.TabIndex = 22;
            this.btn_OpenFileDialog2.Text = "...";
            this.btn_OpenFileDialog2.UseVisualStyleBackColor = true;
            this.btn_OpenFileDialog2.Click += new System.EventHandler(this.btn_OpenFileDialog2_Click);
            // 
            // btn_ConvertXbrl2
            // 
            this.btn_ConvertXbrl2.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_ConvertXbrl2.Location = new System.Drawing.Point(784, 83);
            this.btn_ConvertXbrl2.Name = "btn_ConvertXbrl2";
            this.btn_ConvertXbrl2.Size = new System.Drawing.Size(75, 23);
            this.btn_ConvertXbrl2.TabIndex = 21;
            this.btn_ConvertXbrl2.Text = "변환";
            this.btn_ConvertXbrl2.UseVisualStyleBackColor = true;
            this.btn_ConvertXbrl2.Click += new System.EventHandler(this.btn_ConvertXbrl2_Click);
            // 
            // lbl_FilePath2
            // 
            this.lbl_FilePath2.AutoSize = true;
            this.lbl_FilePath2.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_FilePath2.Location = new System.Drawing.Point(17, 88);
            this.lbl_FilePath2.Name = "lbl_FilePath2";
            this.lbl_FilePath2.Size = new System.Drawing.Size(58, 14);
            this.lbl_FilePath2.TabIndex = 20;
            this.lbl_FilePath2.Text = "파일경로2";
            // 
            // txt_xbrlFilePath2
            // 
            this.txt_xbrlFilePath2.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_xbrlFilePath2.Location = new System.Drawing.Point(86, 84);
            this.txt_xbrlFilePath2.Name = "txt_xbrlFilePath2";
            this.txt_xbrlFilePath2.Size = new System.Drawing.Size(664, 21);
            this.txt_xbrlFilePath2.TabIndex = 19;
            // 
            // btn_OpenFileDialog
            // 
            this.btn_OpenFileDialog.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_OpenFileDialog.Location = new System.Drawing.Point(756, 47);
            this.btn_OpenFileDialog.Name = "btn_OpenFileDialog";
            this.btn_OpenFileDialog.Size = new System.Drawing.Size(28, 23);
            this.btn_OpenFileDialog.TabIndex = 18;
            this.btn_OpenFileDialog.Text = "...";
            this.btn_OpenFileDialog.UseVisualStyleBackColor = true;
            this.btn_OpenFileDialog.Click += new System.EventHandler(this.btn_OpenFileDialog_Click);
            // 
            // lbl_fileType
            // 
            this.lbl_fileType.AutoSize = true;
            this.lbl_fileType.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_fileType.Location = new System.Drawing.Point(17, 23);
            this.lbl_fileType.Name = "lbl_fileType";
            this.lbl_fileType.Size = new System.Drawing.Size(54, 14);
            this.lbl_fileType.TabIndex = 17;
            this.lbl_fileType.Text = "파일 타입";
            // 
            // radio_LabelKo
            // 
            this.radio_LabelKo.AutoSize = true;
            this.radio_LabelKo.Location = new System.Drawing.Point(153, 21);
            this.radio_LabelKo.Name = "radio_LabelKo";
            this.radio_LabelKo.Size = new System.Drawing.Size(80, 18);
            this.radio_LabelKo.TabIndex = 16;
            this.radio_LabelKo.TabStop = true;
            this.radio_LabelKo.Text = "Label(KO)";
            this.radio_LabelKo.UseVisualStyleBackColor = true;
            this.radio_LabelKo.CheckedChanged += new System.EventHandler(this.radio_LabelKo_CheckedChanged);
            // 
            // radio_XBRL
            // 
            this.radio_XBRL.AutoSize = true;
            this.radio_XBRL.Location = new System.Drawing.Point(86, 21);
            this.radio_XBRL.Name = "radio_XBRL";
            this.radio_XBRL.Size = new System.Drawing.Size(53, 18);
            this.radio_XBRL.TabIndex = 15;
            this.radio_XBRL.TabStop = true;
            this.radio_XBRL.Text = "XBRL";
            this.radio_XBRL.UseVisualStyleBackColor = true;
            this.radio_XBRL.CheckedChanged += new System.EventHandler(this.radio_XBRL_CheckedChanged);
            // 
            // btn_ConvertXbrl
            // 
            this.btn_ConvertXbrl.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_ConvertXbrl.Location = new System.Drawing.Point(784, 47);
            this.btn_ConvertXbrl.Name = "btn_ConvertXbrl";
            this.btn_ConvertXbrl.Size = new System.Drawing.Size(75, 23);
            this.btn_ConvertXbrl.TabIndex = 11;
            this.btn_ConvertXbrl.Text = "변환";
            this.btn_ConvertXbrl.UseVisualStyleBackColor = true;
            this.btn_ConvertXbrl.Click += new System.EventHandler(this.btn_ConvertXbrl_Click);
            // 
            // lbl_FilePath1
            // 
            this.lbl_FilePath1.AutoSize = true;
            this.lbl_FilePath1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_FilePath1.Location = new System.Drawing.Point(17, 52);
            this.lbl_FilePath1.Name = "lbl_FilePath1";
            this.lbl_FilePath1.Size = new System.Drawing.Size(58, 14);
            this.lbl_FilePath1.TabIndex = 9;
            this.lbl_FilePath1.Text = "파일경로1";
            // 
            // txt_xbrlFilePath1
            // 
            this.txt_xbrlFilePath1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_xbrlFilePath1.Location = new System.Drawing.Point(86, 48);
            this.txt_xbrlFilePath1.Name = "txt_xbrlFilePath1";
            this.txt_xbrlFilePath1.Size = new System.Drawing.Size(664, 21);
            this.txt_xbrlFilePath1.TabIndex = 7;
            // 
            // XBRLAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 616);
            this.Controls.Add(this.pnl_Right);
            this.Controls.Add(this.pnl_Left);
            this.Name = "XBRLAnalysis";
            this.Text = "XBRLAnalysis";
            this.pnl_Left.ResumeLayout(false);
            this.grpBox_TreeList.ResumeLayout(false);
            this.pnl_LeftTop.ResumeLayout(false);
            this.pnl_treeView1.ResumeLayout(false);
            this.pnl_treeViewInfo.ResumeLayout(false);
            this.pnl_treeViewInfo.PerformLayout();
            this.pnl_Right.ResumeLayout(false);
            this.pnl_RightBottom.ResumeLayout(false);
            this.pnl_RightTop.ResumeLayout(false);
            this.groupBox_FilePath.ResumeLayout(false);
            this.groupBox_FilePath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView tv_xbrlList;
        private System.Windows.Forms.Panel pnl_Left;
        private System.Windows.Forms.GroupBox grpBox_TreeList;
        private System.Windows.Forms.Panel pnl_Right;
        private System.Windows.Forms.GroupBox groupBox_FilePath;
        private System.Windows.Forms.Label lbl_FilePath1;
        private System.Windows.Forms.TextBox txt_xbrlFilePath1;
        private System.Windows.Forms.Button btn_Test;
        private System.Windows.Forms.Button btn_ConvertXbrl;
        private System.Windows.Forms.Panel pnl_LeftTop;
        private System.Windows.Forms.CheckBox checkBox_ExpandTree;
        private System.Windows.Forms.Panel pnl_RightBottom;
        private System.Windows.Forms.Button btn_ConsoleClear;
        private System.Windows.Forms.Panel pnl_RightTop;
        private System.Windows.Forms.Button btn_ToExcel;
        private System.Windows.Forms.Label lbl_ext;
        private System.Windows.Forms.Panel pnl_treeView1;
        private System.Windows.Forms.Label lbl_fileType;
        private System.Windows.Forms.RadioButton radio_LabelKo;
        private System.Windows.Forms.RadioButton radio_XBRL;
        private System.Windows.Forms.Button btn_OpenFileDialog;
        private System.Windows.Forms.Label lbl_FilePath2;
        private System.Windows.Forms.TextBox txt_xbrlFilePath2;
        private System.Windows.Forms.Panel pnl_treeViewInfo;
        private System.Windows.Forms.Button btn_OpenFileDialog2;
        private System.Windows.Forms.Button btn_ConvertXbrl2;
        private System.Windows.Forms.RadioButton radio_LinkCal;
        private System.Windows.Forms.RadioButton radio_LinkDim;
        private System.Windows.Forms.RadioButton radio_LinkPre;
        private System.Windows.Forms.RadioButton radio_LabelEn;
        private System.Windows.Forms.Button btn_Test2;
        private System.Windows.Forms.Button btn_MergeDT;
        private System.Windows.Forms.TextBox txtBox_Console;
    }
}

