using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        private ClientController ctr;
        public Form1(ClientController ctr)
        {
            InitializeComponent();
            passwordText.PasswordChar = '*';
            this.ctr = ctr;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String user = userText.Text;
            String pass = passwordText.Text;
            try
            {
                Console.WriteLine("Inainte de login");
                ctr.login(user, pass);
                Console.WriteLine("dupa login");
                if(user == "ana")
                {
                    Sef sef = new Sef(ctr);
                    sef.Show();
                    this.Hide();
                }
                else
                {
                    Angajat ang = new Angajat(ctr,user);
                    ang.Show();
                    this.Hide();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, "Login Error" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
