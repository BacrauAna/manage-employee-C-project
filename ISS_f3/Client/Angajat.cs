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
    public partial class Angajat : Form
    {
        private ClientController ctr;
        private String usr;
        private readonly IList<Stari> starile;
        private readonly IList<Sarcini> sarcinile;
        public Angajat(ClientController ctr, String usr)
        {
            InitializeComponent();
            this.ctr = ctr;
            this.usr = usr;
            starile = new BindingList<Stari>((List<Stari>)ctr.getStari());
            //sarcinile = new BindingList<Sarcini>((List<Sarcini>)ctr.getSarcini());
            sarcinile = new BindingList<Sarcini>((IList<Sarcini>)ctr.getSarciniUser(usr));
            dataGridView1.DataSource = sarcinile;
            dataGridView2.DataSource = starile;
        }

        //private string Usr { get { return usr; } set { usr = value; } }

        private void btnPreiaS_Click(object sender, EventArgs e)
        {
            int ida;
            if(Int32.TryParse(textId.Text, out ida))
            {
                try
                {
                    Sarcini sar = new Sarcini(ida, "", 0, "", "", "");
                    ctr.preluata(sar);
                    IList<Sarcini> sarcinile2 = new BindingList<Sarcini>((IList<Sarcini>)ctr.getSarciniUser(this.usr));
                    dataGridView1.DataSource = sarcinile2;
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Nu s-a putut face preluarea");
                }
            }
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            try
            {
                ctr.logout();
                this.Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, "Logout Error" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnSarcininoi_Click(object sender, EventArgs e)
        {
            IList<Sarcini> sarcinile2 = new BindingList<Sarcini>((IList<Sarcini>)ctr.getSarciniUser(this.usr));
            dataGridView1.DataSource = sarcinile2;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            DataGridViewRow selRow = dataGridView1.Rows[index];
            textId.Text = selRow.Cells[0].Value.ToString();
        }

        private void btnUpdS_Click(object sender, EventArgs e)
        {
            int ida;
            if (Int32.TryParse(textId.Text, out ida))
            {
                try
                {
                    Sarcini sar = new Sarcini(ida, "", 0, "", "", "");
                    ctr.progresata(sar);
                    IList<Sarcini> sarcinile2 = new BindingList<Sarcini>((IList<Sarcini>)ctr.getSarciniUser(this.usr));
                    dataGridView1.DataSource = sarcinile2;
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Nu s-a putut face progresul");
                }
            }
        }

        private void btnTrimiteS_Click(object sender, EventArgs e)
        {
            int ida;
            if (Int32.TryParse(textId.Text, out ida))
            {
                try
                {
                    Sarcini sar = new Sarcini(ida, "", 0, "", "", "");
                    ctr.finalizata(sar);
                    IList<Sarcini> sarcinile2 = new BindingList<Sarcini>((IList<Sarcini>)ctr.getSarciniUser(this.usr));
                    dataGridView1.DataSource = sarcinile2;
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Nu s-a putut face finalizarea");
                }
            }
        }
    }
}
