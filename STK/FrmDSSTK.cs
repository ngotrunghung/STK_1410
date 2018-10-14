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
    public partial class FrmDSSTK : Form
    {
        public FrmDSSTK()
        {
            InitializeComponent();
        }
        private string gEmail;
        public string GEmail
        {
            get { return gEmail; }
            set { gEmail = value; }
        }
        private string key;
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        public SqlConnection Kn()
        {
            return new SqlConnection(@"Data Source = DESKTOP-C213M68\SQLEXPRESS;Initial Catalog = db_Money; Integrated Security = True; Context Connection = False; MultiSubnetFailover=True");
        }
        public void KetNoiCSDL()
        {
            SqlConnection cnn = Kn();
            string sql1 = "SELECT ID , MaSo , SoTienGui ,KyHan,NgayGui, LaiSuat FROM TheTietKiem Where Email = '" + lbnGetEmail.Text + "'and TatToan = 'False'  ";
            cnn.Open();
            SqlCommand com = new SqlCommand(sql1, cnn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            dataGridView1.DataSource = dt;
        }
        public void KetNoiCSDLTatToan()
        {
            List<NganHang> list = new List<NganHang>();
            SqlConnection cnn = Kn();
            string sql1 = "SELECT t.ID , t.MaSo , t.SoTienGui ,t.KyHan,t.NgayGui, t.LaiSuat, n.TenNganHang, n.MaNganHang FROM TheTietKiem t, NganHang n Where Email = '" + lbnGetEmail.Text + 
                "' and TatToan = 1 and t.MaNganHang = n.MaNganHang";
            cnn.Open();
            SqlCommand com = new SqlCommand(sql1, cnn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            dataGridView2.DataSource = dt;
            
            //var dr = com.ExecuteReader();
            //var listResult = new List<dynamic>();
            //while (dr.Read())
            //{
            //    listResult.Add(new
            //    {
            //        MaNganHang = dr.GetString(dr.GetOrdinal("MaNganHang")),
            //        TenNganHang = dr.GetString(dr.GetOrdinal("TenNganHang")),
            //        ID = dr.GetInt32(dr.GetOrdinal("ID")),
            //        SoTienGui = dr.GetDouble(dr.GetOrdinal("SoTienGui")),
            //    });
            //}
            //var listNganHang = listResult
            //    .GroupBy(x => x.MaNganHang)
            //    .Select(x=>x.FirstOrDefault());
            //foreach(var item in listNganHang)
            //{
            //    list.Add(new NganHang
            //    {
            //        MaNganHang = item.MaNganHang,
            //        TenNganHang = item.TenNganHang,
            //        ListSoTK = listResult
            //            .Where(x => x.MaNganHang == item.MaNganHang)
            //            .Select(x=> new SoTK {
            //                ID = x.ID,
            //                SoTienGui = x.SoTienGui
            //            }).ToList()
            //    });
            //}
        }
        private void FrmDSSTK_Load(object sender, EventArgs e)
        {
            //lbnGetEmail.Text = gEmail;
            lbnGetEmail.Text = "dev01@gmail.com";
            lbnKey.Text = Key;
            MaximizeBox = false;
            MinimizeBox = false;// do data vao datagitbiew ak
            KetNoiCSDL();
            KetNoiCSDLTatToan();
            TongTien();



            //if (dr.Read())
            //{
            //    cnn.Close();
            //    this.Hide();
            //    FrmDSSTK ds = new FrmDSSTK();
            //    ds.GEmail = textBox1.Text;
            //    ds.Show();
            //}

        }

        private void FrmDSSTK_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult TL;
            TL = MessageBox.Show("Bạn thật sự muốn thoát ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (TL == DialogResult.No)
            {
                e.Cancel = true;
                Application.Exit();
                Application.ExitThread();
                this.Close();

            }
        }

        private void picPlusSTK_Click(object sender, EventArgs e)
        {
            FRMThemSTK stk = new FRMThemSTK();
            stk.G_Email = lbnGetEmail.Text;
            stk.Show();

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView1.Rows[e.RowIndex];
            lbnKey.Text = row.Cells[0].Value.ToString();
            lbnKyHan.Text = row.Cells[3].Value.ToString();
            if (lbnKyHan.Text=="Không kỳ hạn")
            {
                lbnIntKyHan.Text = "0";
            }
            else if (lbnKyHan.Text == "1 tháng")
            {
                lbnIntKyHan.Text = "1";
            }
            else if (lbnKyHan.Text == "3 tháng")
            {
                lbnIntKyHan.Text = "3";
            }
            else if (lbnKyHan.Text == "6 tháng")
            {
                lbnIntKyHan.Text = "6";
            }
            else if (lbnKyHan.Text == "12 tháng")
            {
                lbnIntKyHan.Text = "12";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var key = dataGridView1.SelectedRows[0].Cells[0].Value;
            var email = GEmail;
            FrmAddEditSTK f = new FrmAddEditSTK() { Key = key.ToString() };
            f.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            KetNoiCSDL();
            KetNoiCSDLTatToan();
            TongTien();


        }
        public void TongTien()
        {

            SqlConnection cnn = Kn();
            string sql1 = "SELECT SUM(SoTienGui)  FROM TheTietKiem WHERE Email='" + lbnGetEmail.Text + "' and TatToan = 0";
            cnn.Open();
            SqlCommand com = new SqlCommand(sql1, cnn);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                string f = dr[0].ToString();
                string ff = String.Format("{0:0,0}", dr[0].ToString());
                lbnTongTien.Text= ff;                
            }
            
        }

        private void btnGuiThem_Click(object sender, EventArgs e)
        {
            var key = dataGridView1.SelectedRows[0].Cells[0].Value;
            FrmGuiThem f = new FrmGuiThem() { Key = key.ToString() };         
            f.Show();
        }
        public bool getMonth()
        {
            int month;
            DateTime Time1, Time2;
            TimeSpan time;
            var k = dataGridView1.SelectedRows[0].Cells[0].Value;
            SqlConnection cnn = Kn();
            cnn.Open();
            string sql = "SELECT NgayGui FROM TheTietKiem WHERE ID = '" + k + "'";
            SqlCommand cm = new SqlCommand(sql, cnn);
            SqlDataReader dr = cm.ExecuteReader(); ;

            if(dr.Read())
            {
                Time1 = Convert.ToDateTime(dr[0].ToString());
                int a = Time1.Month;
                Time2 = Convert.ToDateTime(DateTime.Now.ToString());
                time = Time2.Subtract(Time1);
                int day = time.Days;
                month = day / 30;
                if(month < a)
                {
                    return false;
                }
            }
            cnn.Close();
            return true;
        }
        string KH;
        private void btnTatToan_Click(object sender, EventArgs e)
        {
            //testMonth.Text = getMonth().ToString();
            //var prm = new SqlParameter[] {
            //    new SqlParameter("@ngaynGui", dateTimePicker1.Value),
            //    new SqlParameter("@soTienGui",txtSoTienGui.Text),
            //    new SqlParameter("@laiSuat",txtLaiSuat.Text),
            //    new SqlParameter("@khiDenHan",cbbKhiDenHan.SelectedText),
            //    new SqlParameter("@traLai",cbbTraLai.SelectedText),
            //    new SqlParameter("@kyHan",cbbKyHan.SelectedText),
            //    new SqlParameter("@laiKhongKyHan",txtLKKH)
            //};
            if (getMonth() == true)
            {
                try
                {
                    var k = dataGridView1.SelectedRows[0].Cells[0].Value;
                    SqlConnection cnn = Kn();
                    string sql = "SELECT SoTienGui,LaiSuat,KyHan FROM TheTietKiem WHERE ID = '" + k + "'";
                    cnn.Open();
                    SqlCommand cm = new SqlCommand(sql, cnn);
                    SqlDataReader dr = cm.ExecuteReader();
                    if (dr.Read())
                    {
                        double STG = double.Parse(dr[0].ToString());
                        var LS = double.Parse(dr[1].ToString());

                        KH = dr[2].ToString();
                        if (KH == "Không kỳ hạn")
                        {
                            lbnIntKH.Text = "0";
                        }
                        else if (KH == "1 tháng")
                        {
                            lbnIntKH.Text = "1";
                        }
                        else if (KH == "3 tháng")
                        {
                            lbnIntKH.Text = "3";
                        }
                        else if (KH == "6 tháng")
                        {
                            lbnIntKH.Text = "6";
                        }
                        else if (KH == "12 tháng")
                        {
                            lbnIntKH.Text = "12";
                        }

                        cnn.Close();
                        var KyH = double.Parse(lbnIntKH.Text);
                        var tongLai = STG * LS * (KyH / 12);
                        string sql2 = "UPDATE TheTietKiem SET TatToan = 0 , TienLai ='" + tongLai + "' Where ID = '" + k + "' ";
                        cnn.Open();
                        SqlCommand cmd = new SqlCommand(sql2, cnn);
                        cmd.ExecuteNonQuery();
                        cnn.Close();

                        DialogResult T;
                        T = MessageBox.Show("Tất toán sổ thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }


                catch
                {
                    MessageBox.Show("Không tất toán được !");
                }
            }
            else
            {
                try
                {
                    var k = dataGridView1.SelectedRows[0].Cells[0].Value;
                    SqlConnection cnn = Kn();
                    string sql = "SELECT SoTienGui,LaiKhongKyHan,KyHan FROM TheTietKiem WHERE ID = '" + k + "'";
                    cnn.Open();
                    SqlCommand cm = new SqlCommand(sql, cnn);
                    SqlDataReader dr = cm.ExecuteReader();
                    if (dr.Read())
                    {
                        double STG = double.Parse(dr[0].ToString());
                        var LKKH = double.Parse(dr[1].ToString());

                        KH = dr[2].ToString();
                        if (KH == "Không kỳ hạn")
                        {
                            lbnIntKH.Text = "0";
                        }
                        else if (KH == "1 tháng")
                        {
                            lbnIntKH.Text = "1";
                        }
                        else if (KH == "3 tháng")
                        {
                            lbnIntKH.Text = "3";
                        }
                        else if (KH == "6 tháng")
                        {
                            lbnIntKH.Text = "6";
                        }
                        else if (KH == "12 tháng")
                        {
                            lbnIntKH.Text = "12";
                        }

                        cnn.Close();
                        var KyH = double.Parse(lbnIntKH.Text);
                        var tongLai = STG * LKKH * (KyH / 12);
                        string sql2 = "UPDATE TheTietKiem SET TatToan = 0 , TienLai ='" + tongLai + "' Where ID = '" + k + "' ";
                        cnn.Open();
                        SqlCommand cmd = new SqlCommand(sql2, cnn);
                        cmd.ExecuteNonQuery();
                        cnn.Close();

                        DialogResult T;
                        T = MessageBox.Show("Tất toán sổ thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }


                catch
                {
                    MessageBox.Show("Không tất toán được !");
                }
            }
        }
        public int MyProperty { get; set; }

        private void btnRut1Phan_Click(object sender, EventArgs e)
        {
            var k = dataGridView1.SelectedRows[0].Cells[0].Value;
            FrmRut1Phan r = new FrmRut1Phan() { GKey = k.ToString()};          
            r.Show();
        }
    }
}
