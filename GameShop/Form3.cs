using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form3 : Form
    {
        SqlConnection baglan;
        SqlCommand komut;
        SqlDataReader dr;
        public string yazı;

        int Move;
        int Mouse_X;
        int Mouse_Y;

        public Form3()
        {
            InitializeComponent();
        }

        private void oyungoruntule()
        {
            baglan = new SqlConnection("server=DESKTOP-3BV1UTR\\SQLEXPRESS; Initial Catalog=dbLogin;Integrated Security=SSPI");
            komut = new SqlCommand("Select * From tblGme where usre='"+ yazı +"'", baglan);
            baglan.Open();
            dr = komut.ExecuteReader();
            listView1.Items.Clear();
            while (dr.Read())
            {
                ListViewItem liste = new ListViewItem();
                liste.Text = dr["games"].ToString();
                listView1.Items.Add(liste);
            }
            baglan.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            oyungoruntule();
            label1.Text = yazı;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 ff = new Form2(this);
            ff.yazı = label1.Text;
            ff.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            oyungoruntule();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                label5.Text = item.SubItems[0].Text;
                if(File.Exists(@"C:\c#-application\" + label5.Text + ".txt"))
                {
                    button2.Text = "Oyunu Aç";
                }
                else
                {
                    button2.Text = "Oyunu İndir";
                }
            }

            try
            {
                System.IO.FileInfo dosya = new System.IO.FileInfo("C:\\c#-application\\" + label5.Text + ".txt");
                label9.Text = dosya.Length.ToString() + " byte";
            }
            catch
            {
                label9.Text = "";
            }
            if (button2.Text == "Oyunu İndir")
            {
                label10.Text = "";
            }
            else
            {
                try
                {
                    label10.Text = System.IO.Directory.GetCreationTime("C:\\c#-application\\" + label5.Text + ".txt").ToString();
                }
                catch
                {
                    label10.Text = "";
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label5.Text == "")
            {
                MessageBox.Show("Lütfen bir oyun seçiniz");
            }
            else
            {
                if (button2.Text == "Oyunu İndir")
                {
                    FileStream fs = File.Create(@"C:\c#-application\" + label5.Text + ".txt");
                    fs.Close();
                    MessageBox.Show("Oyununuz İndirildi.");
                    button2.Text = "Oyunu Aç";

                }
                else if (button2.Text == "Oyunu Aç")
                {
                    string myPath = @"C:\c#-application\" + label5.Text + ".txt";
                    System.Diagnostics.Process islem = new System.Diagnostics.Process();
                    islem.StartInfo.FileName = myPath;
                    islem.Start();
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form3_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void Form3_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void panel5_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }
    }
}
