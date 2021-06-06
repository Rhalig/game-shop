using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApp5
{
    public partial class Form2 : Form
    {
        SqlCommand komut;
        SqlDataReader dr;
        public string yazı;
        Form3 callerForm;
        SqlConnection baglan = new SqlConnection("server=DESKTOP-3BV1UTR\\SQLEXPRESS; Initial Catalog=dbLogin;Integrated Security=SSPI");

        int Move;
        int Mouse_X;
        int Mouse_Y;

        public Form2(Form3 call)
        {
            callerForm = call;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = yazı;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            callerForm.Show();
            callerForm.label1.Text = yazı;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "Select * From tblGme where usre=@user AND games=@games";
            komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@user", label1.Text);
            komut.Parameters.AddWithValue("@games", label5.Text);
            baglan.Open();
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Oyununuz zaten kütüphanede mevcut!");
            }
            else
            {
                baglan.Close();
                baglan.Open();
                komut = new SqlCommand("insert into tblGme (usre,games) " + "values ('" + yazı + "','" + label5.Text + "')", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Satın Alımınız Başarılı! Oyununuz Kütüphaneye Eklenmiştir.");
            }
            baglan.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "Select * From tblGme where usre=@user AND games=@games";
            komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@user", label1.Text);
            komut.Parameters.AddWithValue("@games", label2.Text);
            baglan.Open();
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Oyununuz zaten kütüphanede mevcut!");
            }
            else
            {
                baglan.Close();
                baglan.Open();
                komut = new SqlCommand("insert into tblGme (usre,games) " + "values ('" + yazı + "','" + label2.Text + "')", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Satın Alımınız Başarılı! Oyununuz Kütüphaneye Eklenmiştir.");
            }
            baglan.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sorgu = "Select * From tblGme where usre=@user AND games=@games";
            komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@user", label1.Text);
            komut.Parameters.AddWithValue("@games", label3.Text);
            baglan.Open();
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Oyununuz zaten kütüphanede mevcut!");
            }
            else
            {
                baglan.Close();
                baglan.Open();
                komut = new SqlCommand("insert into tblGme (usre,games) " + "values ('" + yazı + "','" + label3.Text + "')", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Satın Alımınız Başarılı! Oyununuz Kütüphaneye Eklenmiştir.");
            }
            baglan.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string sorgu = "Select * From tblGme where usre=@user AND games=@games";
            komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@user", label1.Text);
            komut.Parameters.AddWithValue("@games", label4.Text);
            baglan.Open();
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Oyununuz zaten kütüphanede mevcut!");
            }
            else
            {
                baglan.Close();
                baglan.Open();
                komut = new SqlCommand("insert into tblGme (usre,games) " + "values ('" + yazı + "','" + label4.Text + "')", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Satın Alımınız Başarılı! Oyununuz Kütüphaneye Eklenmiştir.");
            }
            baglan.Close();
        } 
        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
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

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }
    }
}
