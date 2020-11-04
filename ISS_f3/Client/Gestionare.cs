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
    public partial class Gestionare : Form
    {
        private ClientController ctr;
        private readonly IList<Users> useri;
        public Gestionare(ClientController ctr)
        {
            InitializeComponent();
            this.ctr = ctr;
            useri = new BindingList<Users>((List<Users>)ctr.getUsers());
            dataGridView1.DataSource = useri;
        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            int sal, stare;
            if(Int32.TryParse(textSalariu.Text, out sal) && Int32.TryParse(textStare.Text, out stare))
            {
                try
                {
                    Users us = new Users(0, textUser.Text, textParola.Text, textIntrebuintare.Text, textNume.Text, textPrenume.Text, sal, textAdresa.Text, stare);
                    ctr.adauga(us);
                    IList<Users> useri1 = new BindingList<Users>((List<Users>)ctr.getUsers());
                    dataGridView1.DataSource = useri1;
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Nu s-a putut face adaugarea");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            DataGridViewRow selRow = dataGridView1.Rows[index];
            textID.Text = selRow.Cells[0].Value.ToString();
            textUser.Text = selRow.Cells[1].Value.ToString();
            textParola.Text = selRow.Cells[2].Value.ToString();
            textIntrebuintare.Text = selRow.Cells[3].Value.ToString();
            textNume.Text = selRow.Cells[4].Value.ToString();
            textPrenume.Text = selRow.Cells[5].Value.ToString();
            textSalariu.Text = selRow.Cells[6].Value.ToString();
            textAdresa.Text = selRow.Cells[7].Value.ToString();
            textStare.Text = selRow.Cells[8].Value.ToString();
        }

        private void btnSterge_Click(object sender, EventArgs e)
        {
            int sal, stare,id;
            if (Int32.TryParse(textSalariu.Text, out sal) && Int32.TryParse(textStare.Text, out stare) &&Int32.TryParse(textID.Text,out id))
            {
                try
                {
                    Users us = new Users(id, textUser.Text, textParola.Text, textIntrebuintare.Text, textNume.Text, textPrenume.Text, sal, textAdresa.Text, stare);
                    ctr.sterge(us);
                    IList<Users> useri1 = new BindingList<Users>((List<Users>)ctr.getUsers());
                    dataGridView1.DataSource = useri1;
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Nu s-a putut face stergerea");
                }
            }
            
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            int sal, stare, id;
            if (Int32.TryParse(textSalariu.Text, out sal) && Int32.TryParse(textStare.Text, out stare) && Int32.TryParse(textID.Text, out id))
            {
                try
                {
                    Users us = new Users(id, textUser.Text, textParola.Text, textIntrebuintare.Text, textNume.Text, textPrenume.Text, sal, textAdresa.Text, stare);
                    ctr.modifica(us);
                    IList<Users> useri1 = new BindingList<Users>((List<Users>)ctr.getUsers());
                    dataGridView1.DataSource = useri1;
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Nu s-a putut face modificarea");
                }
            }
        }
    }
}
