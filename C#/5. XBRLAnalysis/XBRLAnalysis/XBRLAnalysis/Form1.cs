using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Office.Interop.Excel;
using System.Configuration;
using DataTable = System.Data.DataTable;
using OpenDartXBRL;

namespace XBRLAnalysis
{
    public partial class XBRLAnalysis : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);


        // 파일 확장자
        private enum FileType
        {
            XBRL = 0,
            LABEL_KO = 1,
            LABEL_EN = 2,
            LINK_CAL = 3,
            LINK_DIM = 4,
            LINK_PRE = 5,
            LINK_SCHEMA = 6
        }

        private List<string> xmlNodeList;       // root 제와한 최상위 노드 List

        private int iRow;                       // Excel 출력 시 row line
        private int iCol;                       // Excel 출력 시 column line

        // xml/xbrl 파일을 DataSet 형태로 변환한 객체
        private System.Data.DataSet ds_global = new System.Data.DataSet();

        // 파일 확장자 타입
        private FileType ft;

        private int ord_Pre = 0;
        private int ord_Def = 0;


        public XBRLAnalysis()
        {
            InitializeComponent();
            xmlNodeList = new List<string>();

            iRow = 4;
            iCol = 2;
            radio_XBRL.Checked = true;
        }


        /// <summary>
        /// xbrl / xml 파일 변환하여 TreeView 출력
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ConvertXbrl_Click(object sender, EventArgs e)
        {
            if(txt_xbrlFilePath1.Text == string.Empty)
            {
                MessageBox.Show("파일 경로가 입력되지 않았습니다.");
                return;
            }
            string sXmlFilePath1 = txt_xbrlFilePath1.Text;
            lbl_ext.Text = "확장자 : " + sXmlFilePath1.Split('.')[1].ToString();

            SetXmlNodeTree(sXmlFilePath1);
        }

        /// <summary>
        /// xbrl / xml 파일 변환하여 TreeView 출력
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ConvertXbrl2_Click(object sender, EventArgs e)
        {
            if (txt_xbrlFilePath2.Text == string.Empty)
            {
                MessageBox.Show("파일 경로가 입력되지 않았습니다.");
                return;
            }
            string sXmlFilePath2 = txt_xbrlFilePath2.Text;
            lbl_ext.Text = "확장자 : " + sXmlFilePath2.Split('.')[1].ToString();


            SetXmlNodeTree(sXmlFilePath2);
        }

        /// <summary>
        /// 변환한 xbrl / xml 파일 Excel 출력
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ToExcel_Click(object sender, EventArgs e)
        {
            string sFileName = string.Empty;
            string sXmlFilePath = string.Empty;

            // 출력할 Excel 파일 경로
            switch (ft)
            {
                case FileType.XBRL:
                    sFileName = ConfigurationManager.AppSettings["Path_XbrlTemplatePath"] + ConfigurationManager.AppSettings["File_XbrlInstance"];
                    break;

                case FileType.LABEL_KO:
                    sFileName = ConfigurationManager.AppSettings["Path_XbrlTemplatePath"] + ConfigurationManager.AppSettings["File_XbrlLabel"];
                    break;

                case FileType.LABEL_EN:
                    sFileName = ConfigurationManager.AppSettings["Path_XbrlTemplatePath"] + ConfigurationManager.AppSettings["File_XbrlLabel"];
                    break;

                case FileType.LINK_PRE:
                    sFileName = ConfigurationManager.AppSettings["Path_XbrlTemplatePath"] + ConfigurationManager.AppSettings["File_XbrlLinkPresentation"];
                    break;

                case FileType.LINK_DIM:
                    sFileName = ConfigurationManager.AppSettings["Path_XbrlTemplatePath"] + ConfigurationManager.AppSettings["File_XbrlLinkDimension"];
                    break;
            }

            // 1. Excel파일 열기
            Microsoft.Office.Interop.Excel._Application XL = XLM_Simple.GetActiveExcel();
            try
            {
                XLM_Simple.Open(XL, sFileName, true, Type.Missing);
                XL = XLM_Simple.GetActiveExcel();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Excel 파일 열기에 실패하였습니다." + Environment.NewLine + ex.Message);
                return;
            }

            // 2. xbrl 최상위 노드 집합의 DataSet 생성/데이터 추가
            ds_global = GetDataSetXbrl(ft, txt_xbrlFilePath1.Text);

            // 3. DataSet을 Excel에 출력
            for (int i = 0; i < ds_global.Tables.Count; i++)
            {
                System.Data.DataTable dt = ds_global.Tables[i];
                XLM_Simple.SetDataOnCell(XL, dt.TableName, iRow, iCol, dt);
            }

            // 4. 다른 이름으로 저장
            string sNewFileName = sFileName.Split('\\')[sFileName.Split('\\').Length - 2] + "_1";
            XLM_Simple.OpenSaveDialog(XL, sNewFileName);

            if (XL != null)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(XL.Worksheets);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(XL.Workbooks);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(XL);

                XL = null;
            }
            System.Windows.Forms.Application.DoEvents();

        }



        private void btn_OpenFileDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ft == FileType.XBRL ? "XBRL files (*.xbrl)|*.xbrl" : "XML files (*.xml)|*.xml";
            ofd.RestoreDirectory = true;

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                txt_xbrlFilePath1.Text = ofd.FileName;
            }
            
        }

        private void btn_OpenFileDialog2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ft == FileType.XBRL ? "XBRL files (*.xbrl)|*.xbrl" : "XML files (*.xml)|*.xml";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txt_xbrlFilePath1.Text = ofd.FileName;
            }
        }


        /// <summary>
        /// Xbrl Instance + Label 매핑하기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MergeDT_Click(object sender, EventArgs e)
        {
            // 1. 파일 경로 체크
            if(txt_xbrlFilePath1.Text == string.Empty && txt_xbrlFilePath2.Text == string.Empty)
            {
                MessageBox.Show("파일 경로가 입력되지 않았습니다.");
                return;
            }

            // 2. xbrl 최상위 노드 집합의 DataSet 생성/데이터 추가
            // DataSet ds_xbrl = GetDataSetXbrl(FileType.XBRL, txt_xbrlFilePath1.Text);
            // DataSet ds_label_ko = GetDataSetXbrl(FileType.LABEL_KO, txt_xbrlFilePath2.Text);

            /* 예제 */
            DataSet ds_xbrl = GetDataSetXbrl(FileType.XBRL, @"D:\Project\XBRLAnalysis-master\삼성전자_2021_사업보고서_XBRL\00126380_2011-04-30.xbrl");
            DataSet ds_label_ko = GetDataSetXbrl(FileType.LABEL_KO, @"D:\Project\XBRLAnalysis-master\삼성전자_2021_사업보고서_XBRL\labels\lab_00126380-ko_2011-04-30.xml");
            DataSet ds_label_en = GetDataSetXbrl(FileType.LABEL_KO, @"D:\Project\XBRLAnalysis-master\삼성전자_2021_사업보고서_XBRL\labels\lab_00126380-en_2011-04-30.xml");


            DataSet ds_result = ds_xbrl.Clone();            // 결과 담을 result DataSet

            // 3. key값으로 매핑 후 LINQ 이용하여 결과셋에 담기
            for (int i = 0; i < ds_result.Tables.Count; i++)
            {
                if (ds_xbrl.Tables[i].TableName == "dart" || ds_xbrl.Tables[i].TableName.Contains("entity") || ds_xbrl.Tables[i].TableName == "ifrs-full")
                {
                    #region 재무제표에 해당하는 시트

                    #region 국문 라벨
                    // ds_result.Tables[i].Columns.Add("ItemName_KO", typeof(string));        // 라벨 명칭 추가할 새로운 Column

                    // Instance Column Key : namespace | label Column Key : Xbrl_ItemCode
                    //var qry = from tb_xbrl in ds_xbrl.Tables[i].AsEnumerable()
                    //          join tb_label in ds_label_ko.Tables[1].AsEnumerable()
                    //          on tb_xbrl.Field<string>("namespace") equals tb_label.Field<string>("Xbrl_ItemCode") into dataKey
                    //          from tb_label in dataKey.DefaultIfEmpty()
                    //          select new
                    //          {
                    //              Namespace = tb_xbrl.Field<string>("namespace"),
                    //              ContextRef = tb_xbrl.Field<string>("contextRef"),
                    //              Decimals = tb_xbrl.Field<string>("decimals"),
                    //              UnitRef = tb_xbrl.Field<string>("unitRef"),
                    //              Value = tb_xbrl.Field<double?>("value"),
                    //              ItemName = (tb_label == null) ? "(no Label)" : tb_label.Field<string>("label_value")      // LINQ로 left outer join 구현할 때 꼭 null 처리 해주자...
                    //          };

                    //foreach (var row in qry)
                    //{
                    //    ds_result.Tables[i].Rows.Add(row.Namespace, row.ContextRef, row.Decimals, row.UnitRef, row.Value, row.ItemName);
                    //}
                    #endregion

                    #region 계정종류 + 국문 라벨 + 영문 라벨
                    ds_result.Tables[i].Columns.Add("Item_Category", typeof(string));
                    ds_result.Tables[i].Columns.Add("ItemName_KO", typeof(string));
                    ds_result.Tables[i].Columns.Add("ItemName_EN", typeof(string));        // 라벨 명칭 추가할 새로운 Column

                    var qry = from tb_xbrl in ds_xbrl.Tables[i].AsEnumerable()

                              join tb_label_ko in ds_label_ko.Tables[1].AsEnumerable() on tb_xbrl.Field<string>("namespace") equals tb_label_ko.Field<string>("Xbrl_ItemCode") into dataKey
                              from lblKoRslt in dataKey.DefaultIfEmpty()

                              join tb_label_en in ds_label_en.Tables[1].AsEnumerable() on tb_xbrl.Field<string>("namespace") equals tb_label_en.Field<string>("Xbrl_ItemCode") into dataKey2
                              from lblEnRslt in dataKey2.DefaultIfEmpty()

                              select new
                              {
                                  Namespace = tb_xbrl.Field<string>("namespace"),
                                  ContextRef = tb_xbrl.Field<string>("contextRef"),
                                  Decimals = tb_xbrl.Field<string>("decimals"),
                                  UnitRef = tb_xbrl.Field<string>("unitRef"),
                                  Value = tb_xbrl.Field<double?>("value"),
                                  // Item_Category = (lblKoRslt == null) ? "(no Label Category)" : lblKoRslt.Field<string>("Xbrl_Namespace"),
                                  Item_Category = (lblKoRslt == null) ? ( (lblEnRslt == null) ? "(no Label Category)" : lblEnRslt.Field<string>("Xbrl_Namespace") ) : lblKoRslt.Field<string>("Xbrl_Namespace"),
                                  ItemName_KO = (lblKoRslt == null) ? "(no Label_ko)" : lblKoRslt.Field<string>("label_value"),      // LINQ로 left outer join 구현할 때 꼭 null 처리 해주자...
                                  ItemName_EN = (lblEnRslt == null) ? "(no Label_en)" : lblEnRslt.Field<string>("label_value")
                              };

                    foreach (var row in qry)
                    {
                        ds_result.Tables[i].Rows.Add(row.Namespace, row.ContextRef, row.Decimals, row.UnitRef, row.Value, row.Item_Category, row.ItemName_KO, row.ItemName_EN);
                    }
                    #endregion

                    #endregion
                }
                else
                {
                    #region 재무제표에 해당하지 않는 시트(그대로 결과셋에 추가)
                    foreach(DataRow dr in ds_xbrl.Tables[i].Rows)
                    {
                        ds_result.Tables[i].ImportRow(dr);
                    }
                    #endregion

                }
                
            }

            // 4. Excel파일 열기 및 결과 셋 출력
            string sFileName = ConfigurationManager.AppSettings["Path_XbrlTemplatePath"] + ConfigurationManager.AppSettings["File_XbrlInstance"];
            Microsoft.Office.Interop.Excel._Application XL = XLM_Simple.GetActiveExcel();
            try
            {
                XLM_Simple.Open(XL, sFileName, true, Type.Missing);
                XL = XLM_Simple.GetActiveExcel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel 파일 열기에 실패하였습니다." + Environment.NewLine + ex.Message);
                return;
            }

            for (int i = 0; i < ds_result.Tables.Count; i++)
            {
                System.Data.DataTable dt = ds_result.Tables[i];
                XLM_Simple.SetDataOnCell(XL, dt.TableName, iRow, iCol, dt);
            }

            // 4. 다른 이름으로 저장
            string sNewFileName = sFileName.Split('\\')[sFileName.Split('\\').Length - 2] + "_1";
            XLM_Simple.OpenSaveDialog(XL, sNewFileName);

            if (XL != null)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(XL.Worksheets);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(XL.Workbooks);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(XL);

                XL = null;
            }
            System.Windows.Forms.Application.DoEvents();

        }



        private void btn_ConsoleClear_Click(object sender, EventArgs e)
        {
            txtBox_Console.Clear();
        }

        private void checkBox_ExpandTree_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_ExpandTree.Checked == true)
            {
                tv_xbrlList.ExpandAll();
            }
            else
            {
                tv_xbrlList.CollapseAll();
            }
        }

        private void radio_XBRL_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_XBRL.Checked == true)
            {
                ft = FileType.XBRL;
            }
        }

        private void radio_LabelKo_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_LabelKo.Checked == true)
            {
                ft = FileType.LABEL_KO;
            }
        }

        private void radio_LabelEn_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_LabelEn.Checked == true)
            {
                ft = FileType.LABEL_EN;
            }
        }

        private void radio_LinkPre_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_LinkPre.Checked == true)
            {
                ft = FileType.LINK_PRE;
            }
        }

        private void radio_LinkDim_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_LinkDim.Checked == true)
            {
                ft = FileType.LINK_DIM;
            }
        }

        private void radio_LinkCal_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_LinkCal.Checked == true)
            {
                ft = FileType.LINK_CAL;
            }
        }


        





        /// <summary>
        /// 읽어온 xml을 TreeView로 변환, 재귀함수 구조
        /// </summary>
        /// <param name="childNode">Xml의 하위노드</param>
        /// <param name="tn">추가할 TreeNode</param>
        /// <param name="i">Loop 순서</param>
        private void GetXbrlTreeNode(XmlNode childNode, TreeNode tn, int i)
        {
            if (childNode.Value != null)
                tn.Nodes.Add(childNode.Value);
            else
                tn.Nodes.Add(GetNodeNameTag(childNode.Name));


            if (childNode.HasChildNodes == true)
            {
                for (int j = 0; j < childNode.ChildNodes.Count; j++)
                {
                    XmlNode childNode2 = childNode.ChildNodes[j];
                    TreeNode tn2 = tn.Nodes[i];
                    GetXbrlTreeNode(childNode2, tn2, j);
                }

            }

        }


        /// <summary>
        /// Node명 Tag형식으로 변경
        /// ex. Tag >> <Tag>
        /// </summary>
        /// <param name="name">Tag명</param>
        /// <returns>Tag 반환값</returns>
        private string GetNodeNameTag(string name)
        {
            return "<" + name + ">";
        }

        /// <summary>
        /// Console 출력
        /// </summary>
        /// <param name="str">출력할 문자열</param>
        private void PrintConsole(string str)
        {
            StringBuilder sb = new StringBuilder(str);
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine("--------------------------------------------------------------------------------------------------------------------------------");
            txtBox_Console.Text = txtBox_Console.Text + sb.ToString();
            txtBox_Console.SelectionStart = txtBox_Console.Text.Length;
            txtBox_Console.ScrollToCaret();
        }


        private XmlDocument XmlDocumentLoad(string sFilePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(sFilePath);
            }
            catch (Exception ex) { }

            return xmlDoc;
        }


        /// <summary>
        /// 변환 파일 기반의 DataSet 생성(Header, Data)
        /// </summary>
        /// <param name="fe"></param>
        /// <returns></returns>
        private DataSet GetDataSetXbrl(FileType fe, string sFilePath)
        {
            string fp = string.Empty;
            ds_global.Tables.Clear();

            // DataSet 테이블, Header 추가(수동...(?))
            DataSet ds = MakeDataSet(fe);

            fp = sFilePath;
            XmlDocument xmlDoc = XmlDocumentLoad(fp);
            if (xmlDoc.DocumentElement == null)
                return ds;

            XmlElement root = xmlDoc.DocumentElement;
            for (int i = 0; i < root.ChildNodes.Count; i++)
            {
                // 생성된 DataSet에 데이터 추가
                InsertRow(fe, root, ds, i);
            }

            switch (fe)
            {
                case FileType.XBRL:
                    break;

                case FileType.LABEL_KO:
                    // 계정명이 없는애들 삭제
                    DataRow[] dr_Del = ds.Tables["link_labelLink"].Select("label_value = ''");
                    if (dr_Del != null && dr_Del.Length > 0)
                    {
                        foreach (DataRow row in dr_Del)
                        {
                            ds.Tables["link_labelLink"].Rows.Remove(row);
                        }
                    }
                    break;
            }

            return ds;
        }

        /// <summary>
        /// XML 파일 이용한 TreeView Set
        /// </summary>
        /// <param name="sXmlFilePath"></param>
        private void SetXmlNodeTree(string sXmlFilePath)
        {
            tv_xbrlList.Nodes.Clear();
            xmlNodeList.Clear();
            checkBox_ExpandTree.CheckState = CheckState.Unchecked;

            // 1. xml 파일 로드
            // XmlDocument xmlDoc = new XmlDocument();
            XmlDocument xmlDoc = XmlDocumentLoad(sXmlFilePath);
            if (xmlDoc.DocumentElement == null)
            {
                MessageBox.Show("xml 로드에 실패하였습니다." + Environment.NewLine + "xml 파일 경로를 확인하세요.");
                return;
            }

            // 2. xml의 Root 얻어오기 / TreeView 최상단 Item에 추가
            XmlElement root = xmlDoc.DocumentElement;
            tv_xbrlList.Nodes.Add(GetNodeNameTag(root.Name));   // root Name

            // 3. xml 각 노드를 하위 TreeView/List에 추가
            if (root.HasChildNodes == true)
            {
                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    XmlNode childNode = root.ChildNodes[i];
                    TreeNode tn = tv_xbrlList.Nodes[0];

                    xmlNodeList.Add(childNode.Name);        // List 추가
                    GetXbrlTreeNode(childNode, tn, i);      // TreeNode 추가

                }

            }

            // 4.중복 제거한 xml Element List 출력
            xmlNodeList = xmlNodeList.Distinct().ToList();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                sb.AppendLine("Node List[" + i + "] : " + xmlNodeList[i].ToString());
            }
            PrintConsole(sb.ToString());
            sb.Clear();
        }


        /// <summary>
        /// 파일 구조에 따른 DataSet 생성
        /// </summary>
        /// <param name="fe">파일 타입</param>
        /// <returns>데이터 추가된 DataSet</returns>
        private DataSet MakeDataSet(FileType fe)
        {
            DataSet ds = new DataSet();

            switch (fe)
            {
                case FileType.XBRL:
                    #region ============================== XBRL DataSet ==============================
                    ds.Tables.Add("link");
                    ds.Tables.Add("context");
                    ds.Tables.Add("unit");
                    ds.Tables.Add("dart-gcd");
                    ds.Tables.Add("dart");
                    ds.Tables.Add("entity00126380");
                    ds.Tables.Add("ifrs-full");

                    // Table["link"]
                    ds.Tables["link"].Columns.Add("link#xlink:type", typeof(string));
                    ds.Tables["link"].Columns.Add("link#xlink:href", typeof(string));

                    // Table["context"]
                    ds.Tables["context"].Columns.Add("id", typeof(string));
                    ds.Tables["context"].Columns.Add("entity_identifier", typeof(string));
                    ds.Tables["context"].Columns.Add("period_startDate", typeof(string));
                    ds.Tables["context"].Columns.Add("period_endDate", typeof(string));
                    ds.Tables["context"].Columns.Add("period_instant", typeof(string));
                    ds.Tables["context"].Columns.Add("dimension_id1", typeof(string));
                    ds.Tables["context"].Columns.Add("dimension_value1", typeof(string));
                    ds.Tables["context"].Columns.Add("dimension_id2", typeof(string));
                    ds.Tables["context"].Columns.Add("dimension_value2", typeof(string));

                    // Table["unit"]
                    ds.Tables["unit"].Columns.Add("unit_id", typeof(string));
                    ds.Tables["unit"].Columns.Add("unit_value", typeof(string));

                    // Table["dart-gcd"]
                    ds.Tables["dart-gcd"].Columns.Add("namespace", typeof(string));
                    ds.Tables["dart-gcd"].Columns.Add("contextRef", typeof(string));
                    ds.Tables["dart-gcd"].Columns.Add("xml:lang", typeof(string));
                    ds.Tables["dart-gcd"].Columns.Add("decimals", typeof(string));
                    ds.Tables["dart-gcd"].Columns.Add("unitRef", typeof(string));
                    ds.Tables["dart-gcd"].Columns.Add("value", typeof(string));

                    // Table["dart"]
                    ds.Tables["dart"].Columns.Add("namespace", typeof(string));
                    ds.Tables["dart"].Columns.Add("contextRef", typeof(string));
                    ds.Tables["dart"].Columns.Add("decimals", typeof(string));
                    ds.Tables["dart"].Columns.Add("unitRef", typeof(string));
                    ds.Tables["dart"].Columns.Add("value", typeof(double));

                    // Table["entity00126380"]
                    ds.Tables["entity00126380"].Columns.Add("namespace", typeof(string));
                    ds.Tables["entity00126380"].Columns.Add("contextRef", typeof(string));
                    ds.Tables["entity00126380"].Columns.Add("decimals", typeof(string));
                    ds.Tables["entity00126380"].Columns.Add("unitRef", typeof(string));
                    ds.Tables["entity00126380"].Columns.Add("value", typeof(double));

                    // Table["ifrs-full"]
                    ds.Tables["ifrs-full"].Columns.Add("namespace", typeof(string));
                    ds.Tables["ifrs-full"].Columns.Add("contextRef", typeof(string));
                    ds.Tables["ifrs-full"].Columns.Add("decimals", typeof(string));
                    ds.Tables["ifrs-full"].Columns.Add("unitRef", typeof(string));
                    ds.Tables["ifrs-full"].Columns.Add("value", typeof(double));
                    
                    break;
                    #endregion =======================================================================

                case FileType.LABEL_KO:
                    #region ============================== Label DataSet ==============================
                    ds.Tables.Add("link_roleRef");
                    ds.Tables.Add("link_labelLink");

                    // Table["link_roleRef"]
                    ds.Tables["link_roleRef"].Columns.Add("roleURI", typeof(string));
                    ds.Tables["link_roleRef"].Columns.Add("xlink:type", typeof(string));
                    ds.Tables["link_roleRef"].Columns.Add("xlink:href", typeof(string));

                    // Table["link_labelLink"]
                    ds.Tables["link_labelLink"].Columns.Add("loc_xlink:href", typeof(string));
                    ds.Tables["link_labelLink"].Columns.Add("loc_xlink:label", typeof(string));
                    ds.Tables["link_labelLink"].Columns.Add("loc_xlink:hrefVal", typeof(string));
                    ds.Tables["link_labelLink"].Columns.Add("label_xlink:role", typeof(string));
                    ds.Tables["link_labelLink"].Columns.Add("label_xlink:label", typeof(string));
                    ds.Tables["link_labelLink"].Columns.Add("label_xlink:lang", typeof(string));

                    ds.Tables["link_labelLink"].Columns.Add("label_id", typeof(string));
                    ds.Tables["link_labelLink"].Columns.Add("label_value", typeof(string));
                    ds.Tables["link_labelLink"].Columns.Add("labelArc_xlink:from", typeof(string));
                    ds.Tables["link_labelLink"].Columns.Add("labelArc_xlink:to", typeof(string));

                    ds.Tables["link_labelLink"].Columns.Add("Loc_HrefVal", typeof(string));
                    ds.Tables["link_labelLink"].Columns.Add("Xbrl_Namespace", typeof(string));
                    ds.Tables["link_labelLink"].Columns.Add("Xbrl_ItemCode", typeof(string));

                    break;
                #endregion =======================================================================

                case FileType.LABEL_EN:
                    break;

                case FileType.LINK_PRE:
                    #region ============================== Link_Pre DataSet ==============================
                    ds.Tables.Add("link_roleRef");
                    ds.Tables.Add("link_presentationLink");

                    // Table["link_roleRef"]
                    ds.Tables["link_roleRef"].Columns.Add("roleURI", typeof(string));
                    ds.Tables["link_roleRef"].Columns.Add("xlink:type", typeof(string));
                    ds.Tables["link_roleRef"].Columns.Add("xlink:href", typeof(string));

                    // Table["link_labelLink"]
                    ds.Tables["link_presentationLink"].Columns.Add("presentationLink_xlink:role", typeof(string));
                    ds.Tables["link_presentationLink"].Columns.Add("loc_xlink:href", typeof(string));
                    ds.Tables["link_presentationLink"].Columns.Add("loc_xlink:label", typeof(string));
                    ds.Tables["link_presentationLink"].Columns.Add("loc_xlink:type", typeof(string));
                    ds.Tables["link_presentationLink"].Columns.Add("preArc_xlink:type", typeof(string));
                    ds.Tables["link_presentationLink"].Columns.Add("preArc_xlink:arcrole", typeof(string));
                    ds.Tables["link_presentationLink"].Columns.Add("preArc_xlink:from", typeof(string));
                    ds.Tables["link_presentationLink"].Columns.Add("preArc_xlink:to", typeof(string));
                    ds.Tables["link_presentationLink"].Columns.Add("preArc_priority", typeof(string));
                    ds.Tables["link_presentationLink"].Columns.Add("preArc_order", typeof(string));
                    ds.Tables["link_presentationLink"].Columns.Add("preArc_use", typeof(string));

                    break;
                #endregion =======================================================================

                case FileType.LINK_DIM:
                    #region ============================== Link_Pre DataSet ==============================
                    ds.Tables.Add("link_arcroleRef");
                    ds.Tables.Add("link_roleRef");
                    ds.Tables.Add("link_definitionLink");

                    // Table["link_arcroleRef"]
                    ds.Tables["link_arcroleRef"].Columns.Add("arcroleURI", typeof(string));
                    ds.Tables["link_arcroleRef"].Columns.Add("xlink:type", typeof(string));
                    ds.Tables["link_arcroleRef"].Columns.Add("xlink:href", typeof(string));

                    // Table["link_roleRef"]
                    ds.Tables["link_roleRef"].Columns.Add("roleURI", typeof(string));
                    ds.Tables["link_roleRef"].Columns.Add("xlink:type", typeof(string));
                    ds.Tables["link_roleRef"].Columns.Add("xlink:href", typeof(string));

                    // Table["link_labelLink"]
                    ds.Tables["link_definitionLink"].Columns.Add("definitionLink_xlink:role", typeof(string));
                    ds.Tables["link_definitionLink"].Columns.Add("loc_xlink:href", typeof(string));
                    ds.Tables["link_definitionLink"].Columns.Add("loc_xlink:label", typeof(string));
                    ds.Tables["link_definitionLink"].Columns.Add("loc_xlink:type", typeof(string));
                    ds.Tables["link_definitionLink"].Columns.Add("defArc_xlink:type", typeof(string));
                    ds.Tables["link_definitionLink"].Columns.Add("defArc_xlink:arcrole", typeof(string));
                    ds.Tables["link_definitionLink"].Columns.Add("defArc_xlink:from", typeof(string));
                    ds.Tables["link_definitionLink"].Columns.Add("defArc_xlink:to", typeof(string));
                    ds.Tables["link_definitionLink"].Columns.Add("defArc_priority", typeof(string));
                    ds.Tables["link_definitionLink"].Columns.Add("defArc_order", typeof(string));
                    ds.Tables["link_definitionLink"].Columns.Add("defArc_use", typeof(string));
                    #endregion =======================================================================
                    break;

            }
            return ds;
        }


        

        /// <summary>
        /// DataSet에 데이터 Insert
        /// </summary>
        /// <param name="fe">파일 타입</param>
        /// <param name="root">root 요소</param>
        /// <param name="ds">데이터 추가할 DataSet</param>
        /// <param name="i">하위노드 순번</param>
        private void InsertRow(FileType ft, XmlElement root, DataSet ds, int i)
        {
            XmlNode childNode = root.ChildNodes[i];
            string nodeName = string.Empty;
            string sheetName = string.Empty;
            int strIndex = 0;

            

            DataRow dr;
            switch (ft)
            {
                case FileType.XBRL:
                    #region XBRL
                    // 1. 최상위 노드들을 각 Excel Sheet명으로 지정해주기 위한 작업(ex. dart-gcd:Amendment >> dart-gcd, dart-gcd:AuthorName >> dart-gcd...)
                    nodeName = childNode.Name == "#text" ? childNode.ParentNode.Name : childNode.Name;
                    strIndex = nodeName.IndexOf(':') == -1 ? nodeName.Length : nodeName.IndexOf(':');
                    sheetName = nodeName.Substring(0, strIndex);

                    // 2. 각 시트(테이블)에 노드별 데이터 추가
                    dr = ds.Tables[sheetName].Rows.Add();
                    switch (sheetName)
                    {
                        case "link":
                            break;

                        case "context":
                            Nodes_XBRL.Context context = new Nodes_XBRL.Context(childNode);
                            dr["id"] = context.Context_id;
                            dr["entity_identifier"] = context.Entity_identifier;
                            dr["period_startDate"] = context.Period_startDate;
                            dr["period_endDate"] = context.Period_endDate;
                            dr["period_instant"] = context.Period_instance;
                            dr["dimension_id1"] = context.Dimension_id[0];
                            dr["dimension_value1"] = context.Dimension_value[0];
                            dr["dimension_id2"] = context.Dimension_value[1];
                            dr["dimension_value2"] = context.Dimension_value[1];
                            break;

                        case "unit":
                            Nodes_XBRL.Unit unit = new Nodes_XBRL.Unit(childNode);
                            dr["unit_id"] = unit.Unit_Id;
                            dr["unit_value"] = unit.Unit_Value;
                            break;

                        case "dart-gcd":
                            Nodes_XBRL.Dart_gcd dart_gcd = new Nodes_XBRL.Dart_gcd(childNode);
                            dr["namespace"] = dart_gcd.DartGcd_Ns;
                            dr["contextRef"] = dart_gcd.DartGcd_ConRef;
                            dr["xml:lang"] = dart_gcd.DartGcd_xmlLang;
                            dr["decimals"] = dart_gcd.DartGcd_decimals;
                            dr["unitRef"] = dart_gcd.DartGcd_unitRef;
                            dr["value"] = dart_gcd.DartGcd_value;
                            break;

                        case "dart":
                            Nodes_XBRL.Dart dart = new Nodes_XBRL.Dart(childNode);
                            dr["namespace"] = dart.Dart_Ns;
                            dr["contextRef"] = dart.Dart_conRef;
                            dr["decimals"] = dart.Dart_decimals;
                            dr["unitRef"] = dart.Dart_unitRef;
                            dr["value"] = dart.Dart_value;
                            break;

                        case "entity00126380":
                            Nodes_XBRL.Entity entity = new Nodes_XBRL.Entity(childNode);
                            dr["namespace"] = entity.Entity_Ns;
                            dr["contextRef"] = entity.Entity_conRef;
                            dr["decimals"] = entity.Entity_decimals;
                            dr["unitRef"] = entity.Entity_unitRef;
                            dr["value"] = entity.Entity_value;
                            break;

                        case "ifrs-full":
                            Nodes_XBRL.Ifrs_Full ifrs_full = new Nodes_XBRL.Ifrs_Full(childNode);
                            dr["namespace"] = ifrs_full.Ifrs_Full_Ns;
                            dr["contextRef"] = ifrs_full.Ifrs_Full_conRef;
                            dr["decimals"] = ifrs_full.Ifrs_Full_decimals;
                            dr["unitRef"] = ifrs_full.Ifrs_Full_unitRef;
                            dr["value"] = ifrs_full.Ifrs_Full_value;
                            break;
                    }
                    
                    break;
                    #endregion

                case FileType.LABEL_KO:
                    #region Label
                    nodeName = childNode.Name == "#text" ? childNode.ParentNode.Name : childNode.Name;
                    sheetName = nodeName.Replace(":", "_"); // 시트명에 ':' 추가 안됨...

                    switch(sheetName)
                    {
                        case "link_roleRef":
                            dr = ds.Tables[sheetName].Rows.Add();
                            Nodes_Label.RoleRef rolRef = new Nodes_Label.RoleRef(childNode);
                            dr["roleURI"] = rolRef.Role_Uri;
                            dr["xlink:type"] = rolRef.Type;
                            dr["xlink:href"] = rolRef.Href;
                            break;

                        case "link_labelLink":
                            Nodes_Label.LabelLink label = new Nodes_Label.LabelLink();
                            int ord = 0;
                            // 여기서 돌려서 각각 Loc, Label, LabelArc 만들어야겟다
                            for (int j = 0; j < childNode.ChildNodes.Count; j++)
                            {
                                XmlNode childNode2 = childNode.ChildNodes[j];
                                label.InitSturct(childNode2, j);

                                // 3개의 row를 하나의 row로 변환. 각 row마다 inner class로 구현함. 이해안되면 xbrl의 label 파일을 보쟈...
                                // if ((j != 0) && (j % 3 == 2))
                                if((j != 0) && (childNode2.Name == "link:labelArc"))
                                {
                                    ds.Tables[sheetName].Rows.Add();
                                    ds.Tables[sheetName].Rows[ord]["loc_xlink:href"] = label.lb.loc.Loc_xlinkHref;
                                    ds.Tables[sheetName].Rows[ord]["loc_xlink:label"] = label.lb.loc.Loc_xlinkLabel;
                                    ds.Tables[sheetName].Rows[ord]["loc_xlink:hrefVal"] = label.Loc_HrefVal;

                                    ds.Tables[sheetName].Rows[ord]["label_xlink:role"] = label.lb.label.Label_xlinkRole;
                                    ds.Tables[sheetName].Rows[ord]["label_xlink:label"] = label.lb.label.Label_xlinkLabel;
                                    ds.Tables[sheetName].Rows[ord]["label_xlink:lang"] = label.lb.label.Label_xlinkLang;
                                    ds.Tables[sheetName].Rows[ord]["label_id"] = label.lb.label.Label_Id;
                                    ds.Tables[sheetName].Rows[ord]["label_value"] = label.lb.label.Label_Value;

                                    ds.Tables[sheetName].Rows[ord]["labelArc_xlink:from"] = label.lb.labelArc.Arc_xLinkFrom;
                                    ds.Tables[sheetName].Rows[ord]["labelArc_xlink:to"] = label.lb.labelArc.Arc_xLinkTo;

                                    ds.Tables[sheetName].Rows[ord]["Loc_HrefVal"] = label.Loc_HrefVal;
                                    ds.Tables[sheetName].Rows[ord]["Xbrl_Namespace"] = label.Xbrl_Namespace;
                                    ds.Tables[sheetName].Rows[ord]["Xbrl_ItemCode"] = label.Xbrl_ItemCode;

                                    ord++;
                                }

                            }
                            ord = 0;
                            break;
                    }

                    break;
                #endregion

                case FileType.LINK_PRE:
                    #region Link Pre
                    nodeName = childNode.Name == "#text" ? childNode.ParentNode.Name : childNode.Name;
                    sheetName = nodeName.Replace(":", "_"); // 시트명에 ':' 추가 안됨...
                    switch (sheetName)
                    {
                        case "link_roleRef":
                            dr = ds.Tables[sheetName].Rows.Add();
                            Nodes_Link.RoleRef rolRef = new Nodes_Link.RoleRef(childNode);
                            dr["roleURI"] = rolRef.Role_Uri;
                            dr["xlink:type"] = rolRef.Type;
                            dr["xlink:href"] = rolRef.Href;
                            break;

                        case "link_presentationLink":
                            Nodes_Link.PresentationArc pa = new Nodes_Link.PresentationArc();
                            for (int j = 0; j < childNode.ChildNodes.Count; j++)
                            {   
                                XmlNode childNode2 = childNode.ChildNodes[j];
                                string sPresentationLink = childNode.Attributes["xlink:role"].Value;
                                pa.InitSturct(childNode2, j);

                                // if (childNode2.Name == "link:loc")
                                if(j % 2 == 0)
                                {
                                    ds.Tables[sheetName].Rows.Add();

                                    ds.Tables[sheetName].Rows[ord_Pre]["presentationLink_xlink:role"] = sPresentationLink;
                                    ds.Tables[sheetName].Rows[ord_Pre]["loc_xlink:href"] = pa.ps.loc.Loc_Href;
                                    ds.Tables[sheetName].Rows[ord_Pre]["loc_xlink:label"] = pa.ps.loc.Loc_Label;
                                    ds.Tables[sheetName].Rows[ord_Pre]["loc_xlink:type"] = pa.ps.loc.Loc_Type;

                                    ds.Tables[sheetName].Rows[ord_Pre]["preArc_xlink:type"] = pa.ps.pa.PA_Type;
                                    ds.Tables[sheetName].Rows[ord_Pre]["preArc_xlink:arcRole"] = pa.ps.pa.PA_ArcRole;
                                    ds.Tables[sheetName].Rows[ord_Pre]["preArc_xlink:from"] = pa.ps.pa.PA_From;
                                    ds.Tables[sheetName].Rows[ord_Pre]["preArc_xlink:to"] = pa.ps.pa.PA_To;
                                    ds.Tables[sheetName].Rows[ord_Pre]["preArc_priority"] = pa.ps.pa.PA_Priority;
                                    ds.Tables[sheetName].Rows[ord_Pre]["preArc_order"] = pa.ps.pa.PA_Order;
                                    ds.Tables[sheetName].Rows[ord_Pre]["preArc_use"] = pa.ps.pa.PA_Use;

                                    ord_Pre++;
                                }   
                            }
                            break;
                    }

                    break;
                #endregion

                case FileType.LINK_DIM:
                    #region Link Dim
                    nodeName = childNode.Name == "#text" ? childNode.ParentNode.Name : childNode.Name;
                    sheetName = nodeName.Replace(":", "_");
                    switch (sheetName)
                    {
                        case "link_arcroleRef":
                            dr = ds.Tables[sheetName].Rows.Add();
                            Nodes_Link.ArcRoleRef arRef = new Nodes_Link.ArcRoleRef(childNode);
                            dr["arcroleURI"] = arRef.Arcrole_Uri;
                            dr["xlink:type"] = arRef.Type;
                            dr["xlink:href"] = arRef.Href;
                            break;

                        case "link_roleRef":
                            dr = ds.Tables[sheetName].Rows.Add();
                            Nodes_Link.RoleRef rolRef = new Nodes_Link.RoleRef(childNode);
                            dr["roleURI"] = rolRef.Role_Uri;
                            dr["xlink:type"] = rolRef.Type;
                            dr["xlink:href"] = rolRef.Href;
                            break;

                        case "link_definitionLink":
                            Nodes_Link.DefinitionLink da = new Nodes_Link.DefinitionLink();
                            for (int j = 0; j < childNode.ChildNodes.Count; j++)
                            {
                                XmlNode childNode2 = childNode.ChildNodes[j];
                                string sDefinitionLink = childNode.Attributes["xlink:role"].Value;
                                da.InitSturct(childNode2, j);

                                if (j % 2 == 0)
                                {
                                    ds.Tables[sheetName].Rows.Add();

                                    ds.Tables[sheetName].Rows[ord_Def]["definitionLink_xlink:role"] = sDefinitionLink;
                                    ds.Tables[sheetName].Rows[ord_Def]["loc_xlink:href"] = da.ds.loc.Loc_Href;
                                    ds.Tables[sheetName].Rows[ord_Def]["loc_xlink:label"] = da.ds.loc.Loc_Label;
                                    ds.Tables[sheetName].Rows[ord_Def]["loc_xlink:type"] = da.ds.loc.Loc_Type;

                                    ds.Tables[sheetName].Rows[ord_Def]["defArc_xlink:type"] = da.ds.da.DA_Type;
                                    ds.Tables[sheetName].Rows[ord_Def]["defArc_xlink:arcRole"] = da.ds.da.DA_ArcRole;
                                    ds.Tables[sheetName].Rows[ord_Def]["defArc_xlink:from"] = da.ds.da.DA_From;
                                    ds.Tables[sheetName].Rows[ord_Def]["defArc_xlink:to"] = da.ds.da.DA_To;
                                    ds.Tables[sheetName].Rows[ord_Def]["defArc_priority"] = da.ds.da.DA_Priority;
                                    ds.Tables[sheetName].Rows[ord_Def]["defArc_order"] = da.ds.da.DA_Order;
                                    ds.Tables[sheetName].Rows[ord_Def]["defArc_use"] = da.ds.da.DA_Use;

                                    ord_Def++;
                                }
                            }
                            break;
                    }
                    #endregion
                    break;

                case FileType.LINK_CAL:
                    #region Link Cal
                    #endregion
                    break;
            }
            
        }



        /// <summary>
        /// 테슽흐 버튼2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Test2_Click(object sender, EventArgs e)
        {
            /* 예제 */
            DataSet ds_xbrl = GetDataSetXbrl(FileType.XBRL, @"D:\Project\XBRLAnalysis-master\삼성전자_2021_사업보고서_XBRL\00126380_2011-04-30.xbrl");
            DataSet ds_label_ko = GetDataSetXbrl(FileType.LABEL_KO, @"D:\Project\XBRLAnalysis-master\삼성전자_2021_사업보고서_XBRL\labels\lab_00126380-ko_2011-04-30.xml");
            DataSet ds_label_en = GetDataSetXbrl(FileType.LABEL_KO, @"D:\Project\XBRLAnalysis-master\삼성전자_2021_사업보고서_XBRL\labels\lab_00126380-en_2011-04-30.xml");

            DataSet ds_result = ds_xbrl.Clone();            // 결과 담을 result DataSet

            // 3. key값으로 매핑 후 LINQ 이용하여 결과셋에 담기
            for (int i = 0; i < ds_result.Tables.Count; i++)
            {
                if (ds_xbrl.Tables[i].TableName == "dart" || ds_xbrl.Tables[i].TableName.Contains("entity") || ds_xbrl.Tables[i].TableName == "ifrs-full")
                {
                    #region 재무제표에 해당하는 시트
                    ds_result.Tables[i].Columns.Add("Item_Category", typeof(string));
                    ds_result.Tables[i].Columns.Add("ItemName_KO", typeof(string));
                    ds_result.Tables[i].Columns.Add("ItemName_EN", typeof(string));        // 라벨 명칭 추가할 새로운 Column

                    var qry = from tb_xbrl in ds_xbrl.Tables[i].AsEnumerable()

                              join tb_label_ko in ds_label_ko.Tables[1].AsEnumerable() on tb_xbrl.Field<string>("namespace") equals tb_label_ko.Field<string>("Xbrl_ItemCode") into dataKey
                              from lblKoRslt in dataKey.DefaultIfEmpty()

                              join tb_label_en in ds_label_en.Tables[1].AsEnumerable() on tb_xbrl.Field<string>("namespace") equals tb_label_en.Field<string>("Xbrl_ItemCode") into dataKey2
                              from lblEnRslt in dataKey2.DefaultIfEmpty()

                              select new
                              {
                                  Namespace = tb_xbrl.Field<string>("namespace"),
                                  ContextRef = tb_xbrl.Field<string>("contextRef"),
                                  Decimals = tb_xbrl.Field<string>("decimals"),
                                  UnitRef = tb_xbrl.Field<string>("unitRef"),
                                  Value = tb_xbrl.Field<double?>("value"),
                                  Item_Category = (lblKoRslt == null) ? ((lblEnRslt == null) ? "" : lblEnRslt.Field<string>("Xbrl_Namespace")) : lblKoRslt.Field<string>("Xbrl_Namespace"),
                                  ItemName_KO = (lblKoRslt == null) ? "" : lblKoRslt.Field<string>("label_value"),      // LINQ로 left outer join 구현할 때 꼭 null 처리 해주자...
                                  ItemName_EN = (lblEnRslt == null) ? "" : lblEnRslt.Field<string>("label_value")
                              };

                    foreach (var row in qry)
                    {
                        ds_result.Tables[i].Rows.Add(row.Namespace, row.ContextRef, row.Decimals, row.UnitRef, row.Value, row.Item_Category, row.ItemName_KO, row.ItemName_EN);
                    }
                    #endregion
                }
                else
                {
                    #region 재무제표에 해당하지 않는 시트(그대로 결과셋에 추가)
                    foreach (DataRow dr in ds_xbrl.Tables[i].Rows)
                    {
                        ds_result.Tables[i].ImportRow(dr);
                    }
                    #endregion

                }

            }


            DataTable dt_ItemList = new DataTable("T_MST_ITEM");
            dt_ItemList.Columns.Add("ITEM_CD", typeof(string));
            dt_ItemList.Columns.Add("ITEM_NM_KO", typeof(string));
            dt_ItemList.Columns.Add("ITEM_NM_EN", typeof(string));
            dt_ItemList.Columns.Add("ITEM_CTG", typeof(string));
            dt_ItemList.Columns.Add("LVL", typeof(int));
            dt_ItemList.Columns.Add("ITEM_CD_FNG", typeof(string));

            for(int i = 0; i < ds_result.Tables.Count; i++)
            {
                if(ds_result.Tables[i].TableName == "dart" || ds_result.Tables[i].TableName == "ifrs-full" || ds_result.Tables[i].TableName.Contains("entity"))
                {
                   for(int j = 0; j < ds_result.Tables[i].Rows.Count; j++)
                   {
                        DataRow dr = ds_result.Tables[i].Rows[j];
                        dt_ItemList.Rows.Add(dr[0], dr[6], dr[7], dr[5], 1);
                   }
                }
            }

            DataView dv = dt_ItemList.DefaultView;
            dt_ItemList = dv.ToTable(true, new string[] { "ITEM_CD", "ITEM_NM_KO", "ITEM_NM_EN", "ITEM_CTG", "LVL", "ITEM_CD_FNG" });

            // 4. Excel파일 열기 및 결과 셋 출력
            string sFileName = ConfigurationManager.AppSettings["Path_XbrlTemplatePath"] + ConfigurationManager.AppSettings["File_XbrlInstance"];
            Microsoft.Office.Interop.Excel._Application XL = XLM_Simple.GetActiveExcel();
            try
            {
                XLM_Simple.New(XL);
                XL = XLM_Simple.GetActiveExcel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel 파일 열기에 실패하였습니다." + Environment.NewLine + ex.Message);
                return;
            }

            // 5. 컬럼명 / 데이터 출력
            for(int i = 0; i < dt_ItemList.Columns.Count; i++)
            {
                XLM_Simple.SetDataOnCell(XL, "Sheet1", 3, i + 2, dt_ItemList.Columns[i].ColumnName);
            }
            XLM_Simple.SetDataOnCell(XL, "Sheet1", iRow, iCol, dt_ItemList);

            // 6. 다른 이름으로 저장
            string sNewFileName = sFileName.Split('\\')[sFileName.Split('\\').Length - 2] + "_1";
            XLM_Simple.OpenSaveDialog(XL, sNewFileName);

            if (XL != null)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(XL.Worksheets);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(XL.Workbooks);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(XL);

                XL = null;
            }
            System.Windows.Forms.Application.DoEvents();

        }


        /// <summary>
        /// 테슽흐 버튼 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Test_Click(object sender, EventArgs e)
        {
            ODXBRL odx = new OpenDartXBRL.Instance.XBRL_Instance();
            DataSet ds = odx.MakeDataSet();
        }


    }
}
