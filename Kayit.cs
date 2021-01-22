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
    public partial class Kayit : Form
    {
        public Kayit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            OracleConnection con = new OracleConnection("User Id=SYSTEM; Password=1234;Data Source=localhost:1521/XEPDB1;");
            try
            {
                
                con.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO KULLANICI(KUL_ADI,KUL_SIFRE, KUL_GAD, KUL_SAD,KUL_DT) values ('" + txtKulAdı.Text + "' ,'" + txtSifre.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "', '" + date + "') ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Üyeliğiniz oluşturulmuştur. Lütfen giriş yapmayı deneyin.");
                this.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show("Üyelik oluşturma işlemi sırasında bir sorun oluştu.");
                con.Close();
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
