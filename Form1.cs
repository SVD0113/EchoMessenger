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
            // 입력된 메시지 변수에 저장
            string typed_msg = txtMS.Text;

            lbMS.Items.Add(typed_msg);

            txtMS.Clear();



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtMS_TextChanged(object sender, EventArgs e)
        {

        }
    }
}