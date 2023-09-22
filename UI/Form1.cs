using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BLLUser bll = new BLLUser();
        BEUser selectedUser = new BEUser();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BEUser user = new BEUser();
            user.Name = txtName.Text;
            bll.createUser(user);
            cargarGrilla();
        }
        private void cargarGrilla()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bll.getUsers();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            selectedUser.sumarPuntos(Convert.ToInt32(textBox1.Text));



            bll.updateUser(selectedUser);
            cargarGrilla();
            MessageBox.Show("Operación realizada con Éxito!");
            btnBeneficios.Visible = false;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedUser = (BEUser)dataGridView1.CurrentRow.DataBoundItem;
            txtName.Text = selectedUser.Name;
            btnBeneficios.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedUser.restarPuntos(Convert.ToInt32(textBox1.Text));


            bll.updateUser(selectedUser);
            cargarGrilla();
            MessageBox.Show("Operación realizada con Éxito!");
            btnBeneficios.Visible = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(selectedUser.Id  != 0)
            {
                MessageBox.Show(selectedUser.conocerBeneficios());

            }
            else
            {
                MessageBox.Show("Seleccione usuario");
            }
        }
    }
}
