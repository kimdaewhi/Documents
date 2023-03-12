using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;

namespace WinFormsApp1
{
    class OraConn
    {
        private OracleConnection conn;
        // private bool bState;

        /// <summary>
        /// 접속성공 여부(T : 접속성공 / F : 접속실패)
        /// </summary>
        public bool bState { get; set; }

        /// <summary>
        /// 현재 접속중인 데이터베이스 이름
        /// </summary>
        public string Database { get; set; }

        /// <summary>
        /// 현재 접속중인 데이터베이스 버전
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 데이터베이스 연결 상태
        /// </summary>
        public ConnectionState ConnectionState { get; set; }


        public OraConn(string oraID, string oraPW)
        {
            bState = false;
            Connect(oraID, oraPW);
        }


        /// <summary>
        /// Oracle 접속 함수
        /// </summary>
        /// <param name="oraID"></param>
        /// <param name="oraPW"></param>
        public void Connect(string oraID, string oraPW)
        {
            OracleConnect(oraID, oraPW);
        }

        /// <summary>
        /// Oracle Connection 열기
        /// </summary>
        /// <param name="connID">User ID</param>
        /// <param name="connPW">User Password</param>
        public void OracleConnect(string connID, string connPW)
        {
            string ConnStr = "Data Source = (DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = orcl))); " +
                "User Id = " + connID + "; Password = " + connPW + ";";
            try
            {
                conn = new Oracle.ManagedDataAccess.Client.OracleConnection(ConnStr);
                conn.Open();

                this.ConnectionState = ConnectionState.Open;
                this.Database = conn.DatabaseName;
                this.Version = conn.ServerVersion;
                bState = true;
                
            }
            catch
            {
                this.ConnectionState = ConnectionState.Closed;
                bState = false;
            }
        }


        /// <summary>
        /// Oracle Connection 닫기
        /// </summary>
        public void OracleClose()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Dispose();
                conn.Close();
                this.ConnectionState = ConnectionState.Closed;
            }
            else if (conn.State == ConnectionState.Closed)
            {
                return;
            }
        }


        /// <summary>
        /// Select Query 실행 후 결과 DataSet으로 반환
        /// </summary>
        /// <param name="sql">실행할 sql</param>
        /// <returns>실행 결과</returns>
        public DataSet ExecuteQuery(string sql)
        {
            if(conn.State == ConnectionState.Closed)
            {
                OracleConnect("c##mytest", "test");
            }

            OracleDataAdapter oda = new OracleDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            oda.Fill(ds);

            OracleClose();

            return ds;
        }

    }
}
