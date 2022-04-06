using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankProject
{
    public partial class FrmChucNang : Form
    {
        public BankAccount Account { get; set; }

        public FrmChucNang(BankAccount account)
        {
            Account = account;
            InitializeComponent();
        }

        private void FrmChucNang_Load(object sender, EventArgs e)
        {
            lblUsername.Text = "Xin chào " + Account.Username;
            lblBalance.Text = "Số dư " + Account.Balance;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            FrmDangNhap frmDangNhap = new FrmDangNhap();
            this.Hide();
            frmDangNhap.Show();
        }

        private void UpdateAccount(double curBal, double newBal)
        {
            string filePath = HelperClass.GetDirectory("/Data/account-lists.txt");
            if (!File.Exists(filePath))
            {
                // using (StreamWriter sw = File.CreateText(filePath))
                // {
                //    sw.WriteLine("" + Account.Username + "," + Account.Password + "," + Account.Balance + "");
                // }
                // Bug cho~ nay` ne` b
            }
            else
            {
                string raw = File.ReadAllText(filePath);
                raw = raw.Replace(curBal.ToString(), newBal.ToString());
                File.WriteAllText(filePath, raw);
            }
        }

        private void btnCredit_Click(object sender, EventArgs e)
        {
            if (txtSoTien.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền!");
            }

            double curBal = Account.Balance;
            Account.Credit(double.Parse(txtSoTien.Text));

            UpdateAccount(curBal, Account.Balance);
            lblBalance.Text = "Số dư " + Account.Balance;
        }

        private void btnDebit_Click(object sender, EventArgs e)
        {
            if (txtSoTien.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền!");
            }

            double curBal = Account.Balance;
            Account.Debit(double.Parse(txtSoTien.Text));

            UpdateAccount(curBal, Account.Balance);
            lblBalance.Text = "Số dư " + Account.Balance;
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void FrmChucNang_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }
    }
}
