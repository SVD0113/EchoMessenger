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
        string placeholderText = "     <입력창>     *여러줄 선택: Control+클릭 ";

        public Form1()
        {
            InitializeComponent();

            txtMS.Text = placeholderText;
            txtMS.ForeColor = Color.Gray;


            // *** enter로 포커스 이동하면 (여기에 입력하세요)가 사라지지않는 문제 해결1
            this.ActiveControl = lbTitle;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // 메시지 빈칸 전송 X
            if (string.IsNullOrWhiteSpace(txtMS.Text) || txtMS.Text == placeholderText)
            {
                return;
            }

            // 글자 수 제한 (50자)
            if (txtMS.Text.Length > 50)
            {
                MessageBox.Show("메시지는 50자 미만으로 제한합니다");
                return;
            }

            // 입력된 메시지 변수에 저장
            string typed_msg = txtMS.Text.Trim();

            // 타임스탬프 추가
            string final_msg = $"[{DateTime.Now:HH:mm:ss}] {typed_msg}";

            // lbMS에 변수에 저장된 메시지 추가
            lbMS.Items.Add(final_msg);

            // 메시지 카운팅
            lbTitle.Text = $"현재 대화: {lbMS.Items.Count}개";

            // 보낸 tetMS 초기화
            txtMS.Text = "";

            // 전송하면 다시 txtMS로 포커스 이동
            txtMS.Focus();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtMS_TextChanged(object sender, EventArgs e)
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

        private void lbMS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            lbMS.Items.Clear();

            // 카운팅 반영
            lbTitle.Text = $"현재 대화: {lbMS.Items.Count}개";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            /*  // 메시지 선택하면 삭제, 없으면 경고
            if (lbMS.SelectedIndex.c)
            {
                lbMS.Items.RemoveAt(lbMS.SelectedIndex);
                lbTitle.Text = $"현재 대화: {lbMS.Items.Count}개";
            }
            else
            {
                MessageBox.Show("삭제할 메시지를 클릭해주세요");
            } */



            // lbMS.SelectedItems.Count는 '현재 파란색으로 선택된 항목의 개수'입니다.
            // 즉, 1개 이상 선택했다면 삭제를 진행하고, 0개면 경고창을 띄웁니다.
            if (lbMS.SelectedItems.Count > 0)
            {
                // [핵심 로직] 선택된 항목이 0개가 될 때까지 계속 반복해서 지웁니다.
                // (반복문 while을 사용하면 여러 개를 한 번에 안전하게 싹 지울 수 있습니다)
                while (lbMS.SelectedItems.Count > 0)
                {
                    // 선택된 것들 중 제일 첫 번째(0번)를 리스트박스에서 완전히 지워버립니다.
                    lbMS.Items.Remove(lbMS.SelectedItems[0]);
                }

                // 다 지웠으니 메시지 개수(카운팅)를 다시 새로고침 해줍니다.
                lbTitle.Text = $"현재 대화: {lbMS.Items.Count}개";
            }
            else
            {
                // 아무것도 선택 안 하고 삭제 버튼을 눌렀을 때
                MessageBox.Show("삭제할 메시지를 먼저 클릭해주세요");
            }
        }

        private void txtMS_Enter(object sender, EventArgs e)
        {
            if (txtMS.Text == placeholderText)
            {
                txtMS.Text = "";
                txtMS.ForeColor = Color.White;
            }
        }

        private void txtMS_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMS.Text))
            {
                txtMS.Text = placeholderText;
                txtMS.ForeColor = Color.Gray;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
