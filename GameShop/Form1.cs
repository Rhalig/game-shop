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
    public partial class Form1 : Form
    {

        SqlCommand komut;
        SqlDataReader dr;
        SqlConnection baglan = new SqlConnection("server=DESKTOP-3BV1UTR\\SQLEXPRESS; Initial Catalog=dbLogin;Integrated Security=SSPI");


        int Move;
        int Mouse_X;
        int Mouse_Y;

        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void login()
        {
            string sorgu = "Select * From tblUser where usr=@user AND pwd=@pass";
            komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@user", txtUser.Text);
            komut.Parameters.AddWithValue("@pass", txtPass.Text);
            baglan.Open();
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Başarılı bir şekilde giriş yapıldı.");
                this.Hide();
                Form3 frm = new Form3();
                frm.yazı = txtUser.Text;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Kullanıcı adınızı veya şifreniz yanlış!");
            }
            baglan.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "Select * From tblUser where usr=@usr";
            komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@usr", txtUser.Text);
            baglan.Open();
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Böyle bir kullanıcı adı mevcut! Lütfen farklı bir kullanıcı adı giriniz.");
            }
            else
            {
                baglan.Close();
                baglan.Open();
                komut = new SqlCommand("insert into tblUser (usr,pwd) " + "values ('" + txtUser.Text + "','" + txtPass.Text + "')", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Başarıyla kayıt olunmuştur!");
            }
            baglan.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
