using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace STK
{
    public partial class fmrXN : Form
    {
        public fmrXN()
        {
            InitializeComponent();
        }
        public SqlConnection Kn()
        {
            return new SqlConnection(@"Data Source = DESKTOP-C213M68\SQLEXPRESS;Initial Catalog = db_Money; Integrated Security = True; Context Connection = False; MultiSubnetFailover=True");
        }
        public string xKey { get; set; }
        public int kiemTraKyHan()
        {
            SqlConnection cnn = Kn();
            string sql = "SELECT KyHan FROM TheTietKiem WHERE ID = '" + xKey + "'";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr[0].ToString() == "1 tháng")
                {
                    return 1;
                }
                else if (dr[0].ToString() == "3 tháng")
                {
                    return 3;
                }
                else if (dr[0].ToString() == "6 tháng")
                {
                    return 6;
                }
                else if (dr[0].ToString() == "12 tháng")
                {
                    return 12;
                }
            }
            return 0;
        }
        private void fmrXN_Load(object sender, EventArgs e)
        {
            lbnMaSo.Text = xKey.ToString();
            SqlConnection cnn = Kn();
            cnn.Open();
            string s = "SELECT NgayGui,KyHan,MaSo ,LaiKhongKyHan From TheTietKiem WHERE ID = '" + lbnMaSo.Text + "'";
            SqlCommand cmd = new SqlCommand(s, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lbnNgay.Text = dr[2].ToString();
                labLSKKH.Text = dr[3].ToString();
                DateTime t1 = Convert.ToDateTime(dr[0].ToString());
                int ngaydh = int.Parse(t1.Day.ToString());
                int thangdh = int.Parse(t1.Month.ToString());
                int namdh = int.Parse(t1.Year.ToString());


                int kh = kiemTraKyHan();
                int thangToiHan = thangdh + kh;
                if (thangToiHan > 12)
                {
                    thangdh = thangToiHan - 12;
                    namdh += 1;

                    txtNgay.Text = ngaydh.ToString();
                    txtThang.Text = thangdh.ToString();
                    txtNam.Text = namdh.ToString();
                }
                else
                {
                    thangdh = thangToiHan;

                    txtNgay.Text = ngaydh.ToString();
                    txtThang.Text = thangToiHan.ToString();
                    txtNam.Text = namdh.ToString();
                   
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
