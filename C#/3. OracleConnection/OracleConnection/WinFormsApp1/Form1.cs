using System.Data;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private OraConn ora;
        private bool bTest;
        private string MsgCaption = "오라클 테스트";

        public Form1()
        {
            bTest = false;
            InitializeComponent();
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            string connID = txtBox_oraID.Text;
            string connPW = txtBox_oraPW.Text;
            if(connID == string.Empty || connPW == string.Empty)
            {
                MessageBox.Show("아이디, 패스워드를 입력하세요.", MsgCaption);
                return;
            }

            ora = new OraConn(connID, connPW);

            if(ora.bState == true)
            {
                lbl_conState.Text = "[연결성공]";
                lbl_ServiceName.Text = "데이터베이스 : " + ora.Database;
                lbl_Version.Text = "버전 : " + ora.Version;

                tssl_oraID.Text = connID;
                bTest = true;

                richTxt_sql.Enabled = true;
                richTxt_sql.Focus();
            }
            else
            {
                bTest = false;
            }
            
        }

        private void btn_RunSQL_Click(object sender, EventArgs e)
        {
            if (bTest == false)
            {
                MessageBox.Show("쿼리 실행 전 접속 테스트를 먼저 진행하세요.", MsgCaption);
                return;
            }

            if(richTxt_sql.Text == string.Empty)
            {
                MessageBox.Show("실행할 쿼리를 입력하세요.", MsgCaption);
                return;
            }


            string query = richTxt_sql.Text.Replace(";", "");

            DataSet ds = ora.ExecuteQuery(query);
            gridView_result.DataSource = ds.Tables[0];
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(ora.ConnectionState == ConnectionState.Open)
            {
                ora.OracleClose();
            }
        }



    }
}