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
    public partial class FrmDangNhap : Form
    {
        List<string> rawData = new List<string>();
        List<BankAccount> lstBankAccount = new List<BankAccount>();

        private void LoadData()
        {
            rawData = File.ReadAllLines(HelperClass.GetDirectory("/Data/account-lists.txt")).ToList();

            foreach (string data in rawData)
            {
                var arr = data.Split(',');

                BankAccount account = new BankAccount(arr[0], arr[1], double.Parse(arr[2]));
                lstBankAccount.Add(account);
            }
        }

        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private BankAccount AccoutLogin(string username, string password)
        {
            try
            {
                return lstBankAccount.Find(t => t.Username.Equals(username) && t.Password.Equals(password));
            }
            catch (ArgumentNullException)
            {
                return null;
                // throw;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            BankAccount account = AccoutLogin(txtTaiKhoan.Text, txtMatKhau.Text);

            if (account == null)
            {
                MessageBox.Show("Vui lòng kiểm tra lại tài khoản và mật khẩu!");
            }
            else
            {
                FrmChucNang frmChucNang = new FrmChucNang(account);
                this.Hide();
                frmChucNang.Show();
            }
        }

        private void FrmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }
    }
}
