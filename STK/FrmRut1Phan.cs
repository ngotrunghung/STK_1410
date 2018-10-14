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
    public partial class FrmRut1Phan : Form
    {
        public FrmRut1Phan()
        {
            InitializeComponent();
        }

        private void FrmRut1Phan_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            
        }
        private void txtTienRut_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        public SqlConnection Kn()
        {
            return new SqlConnection(@"Data Source = DESKTOP-C213M68\SQLEXPRESS;Initial Catalog = db_Money; Integrated Security = True; Context Connection = False; MultiSubnetFailover=True");
        }
        public string GKey { get; set; }


        int t;
        public bool compareMoney()
        {
            t = int.Parse(txtTienRut.Text);
            SqlConnection cnn = Kn();
            string sql = "SELECT SoTienGui FROM TheTietKiem WHERE ID = '" + GKey + "'";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                int a = int.Parse(dr[0].ToString());
                if (t > a)
                {
                    return false;
                }
            }
            return true;
        }
        public bool timeSpan()
        {
            DateTime Time1, Time2;
            TimeSpan time;
            SqlConnection cnn = Kn();
            cnn.Open();
            string sql = "SELECT NgayGui FROM TheTietKiem WHERE ID = '" + GKey + "'";
            SqlCommand cm = new SqlCommand(sql, cnn);
            SqlDataReader dr = cm.ExecuteReader(); ;

            if (dr.Read())
            {
                Time1 = Convert.ToDateTime(dr[0].ToString());
                int a = Time1.Month;
                Time2 = Convert.ToDateTime(DateTime.Now.ToString());
                time = Time2.Subtract(Time1);
                int day = time.Days;
                if (day < 15)
                {
                    return false;
                }
            }
            cnn.Close();
            return true;
        }
        public int gMonth()
        {
            DateTime Time1, Time2;
            TimeSpan time;
            SqlConnection cnn = Kn();
            cnn.Open();
            string sql = "SELECT NgayGui FROM TheTietKiem WHERE ID = '" + GKey + "'";
            SqlCommand cm = new SqlCommand(sql, cnn);
            SqlDataReader dr = cm.ExecuteReader(); ;

            if (dr.Read())
            {
                Time1 = Convert.ToDateTime(dr[0].ToString());
                int a = Time1.Month;
                Time2 = Convert.ToDateTime(DateTime.Now.ToString());
                time = Time2.Subtract(Time1);
                int day = time.Days;
                int thang = day / 30;
                {
                    return thang;
                }
            }
            cnn.Close();
            return 0;
        }
        public string getKyHan()
        {
            string s;
            SqlConnection cnn = Kn();
            string sql = "SELECT KyHan FROM TheTietKiem WHERE ID = '" + GKey + "'";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return s = dr[0].ToString();
            }
            return "";
        }
        public bool true0KyHan()
        {
            if (getKyHan() == "Không kỳ hạn")
                return true;
            return false;
        }
        public int kiemTraKyHan()
        {
            SqlConnection cnn = Kn();
            string sql = "SELECT KyHan FROM TheTietKiem WHERE ID = '" + GKey + "'";
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
        int a, b;
        public void Rut()
        {

            try
            {
                SqlConnection cnn = Kn();
                string sql1 = "SELECT SoTienGui FROM TheTietKiem WHERE ID ='" + GKey + "'";
                cnn.Open();
                SqlCommand com = new SqlCommand(sql1, cnn);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    a = int.Parse(dr[0].ToString());
                    b = a - int.Parse(txtTienRut.Text);
                }
                cnn.Close();
                string sql2 = "UPDATE TheTietKiem SET SoTienGui=@soTienGui Where ID ='" + GKey + "'";
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sql2, cnn);
                cmd.Parameters.AddWithValue("@soTienGui", float.Parse(b.ToString()));
                cmd.ExecuteNonQuery();
                cnn.Close();

                DialogResult T;
                T = MessageBox.Show("Rút tiền thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (T == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Rút tiền thất bại !");
            }
        }
        int x, y, z;
        public void denHan()
        {
            DateTime Time1, Time2;
            TimeSpan time;
            SqlConnection cnn = Kn();
            cnn.Open();
            string sql = "SELECT NgayGui FROM TheTietKiem WHERE ID = '" + GKey + "'";
            SqlCommand cm = new SqlCommand(sql, cnn);
            SqlDataReader dr = cm.ExecuteReader(); ;

            if (dr.Read())
            {
                Time1 = Convert.ToDateTime(dr[0].ToString());
                int a = Time1.Month;
                Time2 = Convert.ToDateTime(DateTime.Now.ToString());
                time = Time2.Subtract(Time1);
                int day = time.Days;

            }
            cnn.Close();
        }
        private void txtTienRut_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        public void RutTruocKyHan()
        {
            try
            {
                SqlConnection cnn = Kn();
                string sql1 = "SELECT SoTienGui ,LaiKhongKyHan FROM TheTietKiem WHERE ID ='" + GKey + "'";
                cnn.Open();
                SqlCommand com = new SqlCommand(sql1, cnn);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    z = int.Parse(dr[1].ToString());
                    x = int.Parse(dr[0].ToString());
                    y = x - (int.Parse(txtTienRut.Text) * z);
                }
                cnn.Close();
                string sql2 = "UPDATE TheTietKiem SET SoTienGui=@soTienGui Where ID ='" + GKey + "'";
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sql2, cnn);
                cmd.Parameters.AddWithValue("@soTienGui", float.Parse(y.ToString()));
                cmd.ExecuteNonQuery();
                cnn.Close();

                DialogResult T;
                T = MessageBox.Show("Rút tiền thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (T == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Rút tiền thất bại !");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (compareMoney() == true)
            {
                if (true0KyHan() == true)
                {
                    #region a
                    if (timeSpan() == false)
                    {
                        MessageBox.Show("Bạn chưa rút được đâu !");
                    }
                    else
                    {
                        Rut();
                    }
                    #endregion
                }
                else
                {
                    if (gMonth() < kiemTraKyHan())
                    {
                        var fx = GKey;
                        fmrXN f = new fmrXN() {xKey = fx.ToString() };
                        f.Show();
                    }
                    else
                    {
                        Rut();
                    }
                }

            }
            else
            {
                MessageBox.Show("Có đủ tiền đâu mà rút !");
            }
            this.Close();
        }

        public void den_Han()
        {
            
         
        }
    }
}
