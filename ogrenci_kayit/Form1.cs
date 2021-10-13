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

namespace ogrenci_kayit
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;

        void griddoldur()
        {
            con = new SqlConnection("server =DESKTOP-2CRGQ7T; Initial Catalog = dbTest; Integrated Security = True");
            da = new SqlDataAdapter("Select * From tbl_ogrenci", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "tbl_ogrenci");
            dataGridView1.DataSource = ds.Tables["tbl_ogrenci"];
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into tbl_ogrenci(ogrenci_no,ogrenci_ad,ogrenci_soyad,ogrenci_sehir) values (" + txt_numara.Text + ",'" + txt_ad.Text + "','" + txt_soyad.Text + "','" + txt_sehir.Text + "')";
            cmd.ExecuteNonQuery(); 
            con.Close();
            griddoldur();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update tbl_ogrenci set ogrenci_ad='" + txt_ad.Text + "',ogrenci_soyad='" + txt_soyad.Text + "',ogrenci_sehir='" + txt_sehir.Text + "' where ogrenci_no=" + txt_numara.Text + "";
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "delete from tbl_ogrenci where ogrenci_no=" + txt_numara.Text + "";
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur();
        }
    }
}
