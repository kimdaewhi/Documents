using System.Data;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private OraConn ora;
        private bool bTest;
        private string MsgCaption = "����Ŭ �׽�Ʈ";

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
                MessageBox.Show("���̵�, �н����带 �Է��ϼ���.", MsgCaption);
                return;
            }

            ora = new OraConn(connID, connPW);

            if(ora.bState == true)
            {
                lbl_conState.Text = "[���Ἲ��]";
                lbl_ServiceName.Text = "�����ͺ��̽� : " + ora.Database;
                lbl_Version.Text = "���� : " + ora.Version;

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
                MessageBox.Show("���� ���� �� ���� �׽�Ʈ�� ���� �����ϼ���.", MsgCaption);
                return;
            }

            if(richTxt_sql.Text == string.Empty)
            {
                MessageBox.Show("������ ������ �Է��ϼ���.", MsgCaption);
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