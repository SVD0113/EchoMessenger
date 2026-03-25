using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EchoMessenger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtMS.Text))
            {
                return;
            }

            // 입력된 메시지 변수에 저장
            string typed_msg = txtMS.Text;

            // lbMS에 변수에 저장된 메시지 추가
            lbMS.Items.Add(typed_msg);

            // 보낸 tetMS 초기화
            txtMS.Clear();




            // 전송하면 다시 txtMS로 포커스 이동
            txtMS.Focus();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtMS_KeyDown(object sender, KeyEventArgs e)
        {
            // Enter 키 눌리면 메시지 전송
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSend.PerformClick();
            }
        }
    }
}