using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Film_Uygulaması
{
    public partial class Profil : Form
    {
        public Profil()
        {
            InitializeComponent();
        }
        public String kuladi;
        public String kulad;
        public String kulsoyad;

        private void button1_Click(object sender, EventArgs e)
        {
            BilgiGuncelle bilgiGuncelle = new BilgiGuncelle();
            bilgiGuncelle.kuladi = kuladi;
            bilgiGuncelle.Show();
        }

        private void Profil_Load(object sender, EventArgs e)
        {
            label1.Text = kuladi;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AnaMenu anaMenu = new AnaMenu();
            anaMenu.kuladi = kuladi;
            anaMenu.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnaMenu anaMenu = new AnaMenu();
            anaMenu.kuladi = kuladi;
            anaMenu.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
