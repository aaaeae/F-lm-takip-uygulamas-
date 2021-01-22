using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Proje_Film_Uygulaması
{
    public partial class Filmler : Form
    {
        ChromiumWebBrowser chrome;
        public Filmler()
        {
            InitializeComponent();
        }
        String fragman;
        public String kuladi;

        private void button1_Click(object sender, EventArgs e)
        {
            fragman = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            chrome.Load(fragman);
        }

        private void Filmler_Load(object sender, EventArgs e)
        {
            CefSettings ayar = new CefSettings();
            if (Cef.IsInitialized == false)
            {
                Cef.Initialize(ayar);
                chrome = new ChromiumWebBrowser("");
                // chrome.Parent = this.panel1;
                chrome.Dock = DockStyle.Fill;
            }
            this.panel1.Controls.Add(chrome);


        }

        private void button5_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection("User Id=SYSTEM; Password=1234;Data Source=localhost:1521/XEPDB1;");
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select FILM_ADI,FILM_YILI,FILM_SURE,FILM_YON,FILM_TUR,FILM_PUAN,FILM_FRAGMAN from FILM";
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            con.Close();
            

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection("User Id=SYSTEM; Password=1234;Data Source=localhost:1521/XEPDB1;");
            con.Open();
            DataTable table = new DataTable();
            OracleCommand cmd = new OracleCommand("select FILM_ADI,FILM_YILI,FILM_SURE,FILM_YON,FILM_TUR,FILM_PUAN, FILM_FRAGMAN from FILM WHERE FILM_ADI LIKE '%" + textBox1.Text + "%' ", con);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(table);
            dataGridView1.DataSource = table;
            con.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            AnaMenu anaMenu = new AnaMenu();
            anaMenu.kuladi = kuladi;
            anaMenu.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int puan1 = int.Parse(txtPuan1.Text);
            int puan2 = int.Parse(txtPuan2.Text);
            int sure1 = int.Parse(txtSure1.Text);
            int sure2 = int.Parse(txtSure2.Text);
            int yil1 = int.Parse(txtYil1.Text);
            int yil2 = int.Parse(txtYil2.Text);

            


            OracleConnection con = new OracleConnection("User Id=SYSTEM; Password=1234;Data Source=localhost:1521/XEPDB1;");
            con.Open();
            DataTable table = new DataTable();
            OracleCommand cmd = new OracleCommand("select FILM_ADI,FILM_YILI,FILM_SURE,FILM_YON,FILM_TUR,FILM_PUAN ,FILM_FRAGMAN from FILM WHERE FILM_TUR = '"+comboBox1.Text+"' and (FILM_PUAN between '"+puan1+"' and '"+puan2+ "') and (FILM_YILI between '" + yil1 + "' and '" + yil2 + "')  ", con);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(table);
            dataGridView1.DataSource = table;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            String tFilmAdi = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string date = dateTimePicker1.Value.ToString("dd/MM/yyyy");


            OracleConnection con = new OracleConnection("User Id=SYSTEM; Password=1234;Data Source=localhost:1521/XEPDB1;");
            con.Open();
            OracleCommand cmd = new OracleCommand("INSERT INTO TAKVIM(KUL_ADI,FILM_ADI,TAKVIM_TARIH) values ('" + kuladi + "' ,'" + tFilmAdi + "','"+date+"') ", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt başarılı");

        }
    }
}
