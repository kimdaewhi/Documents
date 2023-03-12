using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPASample
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        private enum WindowState
        {
            SW_SHOWNORMAL = 1,
            SW_SHOWMINIMIZED = 2,
            SW_SHOWMAXIMIZED = 3
        };

        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = FindWindow(null, txtBox_processName.Text);

            if (hWnd == IntPtr.Zero)
            {
                MessageBox.Show("프로세스가 실행 중이 아닙니다.");
                return;
            }
            else
            {
                // 윈도우가 최소화 되어 있다면 활성화 시킨다
                ShowWindowAsync(hWnd, Convert.ToInt32(WindowState.SW_SHOWNORMAL));

                // 윈도우에 포커스를 줘서 최상위로 만든다
                SetForegroundWindow(hWnd);
            }



        }


        

        


    }
}
