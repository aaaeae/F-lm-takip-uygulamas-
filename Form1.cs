using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Proje_Film_Uygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var posi = this.PointToScreen(panel1.Location);
            posi = pictureBox1.PointToClient(posi);
            panel1.Parent = pictureBox1;
            panel1.Location = posi;
            panel1.BackColor = Color.FromArgb(200, 0, 0, 0);

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Kayit kayit = new Kayit();
            kayit.Show();
        }

        private void txtKulAdi_TextChanged(object sender, EventArgs e)
        {
            lblKulAdi.Visible = false;
            txtKulAdi.Focus();
        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {
            lblSifre.Visible = false;
        }

        private void lblKulAdi_Click(object sender, EventArgs e)
        {
            lblKulAdi.Visible = false;
            txtKulAdi.Focus();
        }

        private void lblSifre_Click(object sender, EventArgs e)
        {
            lblSifre.Visible = false;
            txtSifre.Focus();
        }

        private void txtKulAdi_Click(object sender, EventArgs e)
        {
            lblKulAdi.Visible = false;
            
        }

        private void txtSifre_Enter(object sender, EventArgs e)
        {
            lblSifre.Visible = false;
        }

        private void txtKulAdi_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtSifre_Click(object sender, EventArgs e)
        {
            lblSifre.Visible = false;
        }

        private void btnAdminGiris_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox2.Visible = true;
            btnAdminGiris.Visible = false;
            btnUyeGiris.Visible = true;
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (btnAdminGiris.Visible == false)
            {
                OracleConnection con = new OracleConnection("User Id=SYSTEM; Password=1234;Data Source=localhost:1521/XEPDB1;");
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "select* from KULLANICI where KUL_ADI = '" + txtKulAdi.Text + "' and KUL_SIFRE = '" + txtSifre.Text + "' and KUL_AC = 1";
                OracleDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    AdminMenu adminMenu = new AdminMenu();
                    adminMenu.Show();
                    this.Hide();
                }
                else
                {
                    lblGirisHata.Visible = true;
                }
                con.Close();
            }

            else if (btnUyeGiris.Visible == false) {
            
                OracleConnection con = new OracleConnection("User Id=SYSTEM; Password=1234;Data Source=localhost:1521/XEPDB1;");
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "select* from KULLANICI where KUL_ADI = '"+txtKulAdi.Text+"' and KUL_SIFRE = '"+txtSifre.Text+"'";
                OracleDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    AnaMenu anaMenu = new AnaMenu();
                    anaMenu.kuladi = txtKulAdi.Text;


                    
                    anaMenu.Show();
                    this.Hide();
                }
                else
                {
                    lblGirisHata.Visible = true;
                }
                con.Close();
            }

            

        }

        private void btnUyeGiris_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox2.Visible = false;
            btnAdminGiris.Visible = true;
            btnUyeGiris.Visible = false;
        }
    }
}