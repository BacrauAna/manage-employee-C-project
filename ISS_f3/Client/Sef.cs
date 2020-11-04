using Domain;
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
    public partial class Sef : Form
    {
        private ClientController ctr;
        private readonly IList<Sarcini> sarcini;
        private readonly IList<Users> activi;
        public Sef(ClientController ctr)
        {
            InitializeComponent();
            this.ctr = ctr;
            sarcini = new BindingList<Sarcini>((List<Sarcini>)ctr.getSarcini());
            activi = new BindingList<Users>((List<Users>)ctr.getActive());
            dataGridView2.DataSource = sarcini;
            dataGridView1.DataSource = activi;
        }

        private void btnGest_Click(object sender, EventArgs e)
        {
            Gestionare gest = new Gestionare(ctr);
            gest.Show();
        }

        private void btnActualiz_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            IList<Users> actual = new BindingList<Users>((List<Users>)ctr.getActive());
            dataGridView1.DataSource = actual;
        }

        private void btnActSar_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            IList<Sarcini> actual = new BindingList<Sarcini>((List<Sarcini>)ctr.getSarcini());
            dataGridView2.DataSource = actual;
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            try
            {
                ctr.logout();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Logout Error" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnEmite_Click(object sender, EventArgs e)
        {
            int ids;
            if(Int32.TryParse(sarcinaText.Text, out ids))
            {
                try
                {
                    Cont cnt = new Cont(anguserText.Text, "", "", 0);
                    Sarcini src = new Sarcini(ids, "", 0, "", "", "");
                    ctr.modificaSrc(src, cnt);
                    IList<Sarcini> actual = new BindingList<Sarcini>((List<Sarcini>)ctr.getSarcini());
                    dataGridView2.DataSource = actual;
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Nu s-a putut face modificarea");
                }
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            DataGridViewRow selRow = dataGridView1.Rows[index];
            anguserText.Text = selRow.Cells[1].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            DataGridViewRow selRow = dataGridView2.Rows[index];
            sarcinaText.Text = selRow.Cells[0].Value.ToString();
        }
    }
}
