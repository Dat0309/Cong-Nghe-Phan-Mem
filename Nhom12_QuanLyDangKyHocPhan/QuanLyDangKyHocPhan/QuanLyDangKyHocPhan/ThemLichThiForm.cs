using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDangKyHocPhan
{
    public partial class ThemLichThiForm : Form
    {
        List<ChiTietDangKy> listCTDK;
        ChiTietDKBL ctdkBL = ChiTietDKBL.getInstance();
        HocPhan hocPhanCurrent;
        LichThiBL lichThiBL = LichThiBL.Instance();
        string currentYear = DateTime.Now.Year.ToString() + " - " + (DateTime.Now.Year + 1).ToString();
        List<LichThi> listLichThi;
        LichThi lichThi;

        public ThemLichThiForm()
        {
            InitializeComponent();
        }
        private void LoadItemToLV(string namHoc, int hocKy)
        {
            lvLichThi.Items.Clear();
            SqlDataReader reader = lichThiBL.LoadLichThi(namHoc, hocKy);
            while (reader.Read())
            {
                ListViewItem item = lvLichThi.Items.Add(reader["MaHP"].ToString());
                item.SubItems.Add(reader["TenHP"].ToString());
                item.SubItems.Add(reader["Khoa"].ToString());
                item.SubItems.Add(reader["STC"].ToString());
                item.SubItems.Add(reader["sldk"].ToString());
                item.SubItems.Add(reader["NgayThi"].ToString());
                item.SubItems.Add(reader["GioThi"].ToString());
                item.SubItems.Add(reader["PhongThi"].ToString());
                item.SubItems.Add(reader["ThoiLuong"].ToString());
                item.SubItems.Add(reader["DiaDiem"].ToString());
                item.SubItems.Add(reader["GhiChu"].ToString());

            }
        }

        private void LoadHPTheoHKVaNam(string namHoc, int hocKy)
        {
            lvLichThi.Items.Clear();
            SqlDataReader reader = lichThiBL.LoadLichThi(namHoc, hocKy);

            while (reader.Read())
            {
                ListViewItem item = lvLichThi.Items.Add(reader["MaHP"].ToString());
                item.SubItems.Add(reader["TenHP"].ToString());
                item.SubItems.Add(reader["Khoa"].ToString());
                item.SubItems.Add(reader["STC"].ToString());
                item.SubItems.Add(reader["sldk"].ToString());
                item.SubItems.Add(reader["NgayThi"].ToString());
                item.SubItems.Add(reader["GioThi"].ToString());
                item.SubItems.Add(reader["PhongThi"].ToString());
                item.SubItems.Add(reader["ThoiLuong"].ToString());
                item.SubItems.Add(reader["DiaDiem"].ToString());
                item.SubItems.Add(reader["GhiChu"].ToString());
            }
        }

        private void ThemLichThiForm_Load(object sender, EventArgs e)
        {
            LoadLichThiToLV();
            LoadItemToLV(currentYear, int.Parse(cbbHocKy.Text == "" ? "0" : cbbHocKy.Text));
            txtNamHoc.Text = currentYear;

        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            int hocKy = int.Parse(cbbHocKy.Text == "" ? "0" : cbbHocKy.Text);
            LoadHPTheoHKVaNam(currentYear, hocKy);
        }
        private void LoadLichThiToLV()
        {
            lvLichThi.Items.Clear();
            listLichThi = lichThiBL.GetAll();
            SqlDataReader reader = ctdkBL.QLChiTietHP();
            foreach (var lichThi in listLichThi)
            {
                ListViewItem item1 = lvLichThi.Items.Add(lichThi.MaHP);
                item1.SubItems.Add(lichThi.NgayThi);
                item1.SubItems.Add(lichThi.GioThi);
                item1.SubItems.Add(lichThi.PhongThi);
                item1.SubItems.Add(lichThi.ThoiLuong.ToString());
                item1.SubItems.Add(lichThi.GhiChu);
            }
        }
        private void xemDanhSáchSinhViênĐăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string maHP;
            if (lvLichThi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn môn học để xem số lượng sinh viên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ListViewItem item = lvLichThi.SelectedItems[0];
                maHP = item.SubItems[0].Text;
                ChiTietDangKyHocPhan frm = new ChiTietDangKyHocPhan(maHP);
                frm.ShowDialog();
            }
        }
        private void thêmLịchThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvLichThi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn môn học để thêm lịch thi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var lichThiInfo = new LichThiInfo();
                hocPhanCurrent = new HocPhan();
                ListViewItem item = lvLichThi.SelectedItems[0];
                hocPhanCurrent.MaHP = item.SubItems[0].Text;
                hocPhanCurrent.TenHP = item.SubItems[1].Text;
                lichThiInfo.LoadHocPhan(hocPhanCurrent,currentYear, int.Parse(cbbHocKy.Text));
                lichThiInfo.LoadStatusAdd();
                if (lichThiInfo.ShowDialog() == DialogResult.OK)
                {
                    LoadItemToLV(currentYear, int.Parse(cbbHocKy.Text));
                }
            }
        }
    }
}
