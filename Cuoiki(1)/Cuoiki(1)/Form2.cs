using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cuoiki_1_
{
    public partial class Form2 : Form
    {
        // Giả sử bạn có một danh sách các xe để tìm kiếm
        private List<Vehicle> vehicles = new List<Vehicle>
        {
            new Vehicle { MaXe = "MX001", TenXe = "SH", LoaiXe = "Xe tay ga", GiaThanh = 150000000, PhanKhoi = 150, HangXe = "Honda" },
            new Vehicle { MaXe = "MX002", TenXe = "Winner X", LoaiXe = "Xe tay côn", GiaThanh = 46160000, PhanKhoi = 150, HangXe = "Honda" },
            new Vehicle { MaXe = "MX003", TenXe = "Wave", LoaiXe = "Xe máy", GiaThanh = 30000000, PhanKhoi = 110, HangXe = "Honda" },
            new Vehicle { MaXe = "MX004", TenXe = "Vision", LoaiXe = "Xe tay ga", GiaThanh = 31690000, PhanKhoi = 110, HangXe = "Honda" },
            new Vehicle { MaXe = "MX005", TenXe = "Exciter", LoaiXe = "Xe tay côn", GiaThanh = 47000000, PhanKhoi = 150, HangXe = "Yamaha" },
            new Vehicle { MaXe = "MX006", TenXe = "Grande", LoaiXe = "Xe tay ga", GiaThanh = 45000000, PhanKhoi = 125, HangXe = "Yamaha" },
            new Vehicle { MaXe = "MX007", TenXe = "Attila", LoaiXe = "Xe tay ga", GiaThanh = 35000000, PhanKhoi = 125, HangXe = "SYM" },
            new Vehicle { MaXe = "MX008", TenXe = "Klara", LoaiXe = "Xe tay ga", GiaThanh = 50000000, PhanKhoi = 125, HangXe = "Vinfast" }
        };

        public Form2()
        {
            InitializeComponent();
            // Thêm các giá trị vào ComboBox khi Form được khởi tạo
            AddItemsToComboBoxes();
            // Thêm danh sách xe vào ListView
            PopulateListView();
        }
        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void AddItemsToComboBoxes()
        {
            // Thêm các giá trị vào ComboBox hãng xe
            cbbHangXe.Items.AddRange(new string[] { "Yamaha", "Honda", "SYM", "Suzuki", "Vinfast" });

            // Thêm các giá trị vào ComboBox loại xe
            cbbLoaiXe.Items.AddRange(new string[] { "Xe tay ga", "Xe tay côn", "Xe máy", "Xe điện" });
        }

        private void PopulateListView()
        {
            // Thiết lập các cột cho ListView
            listViewXe.Columns.Add("Mã Xe", 100);
            listViewXe.Columns.Add("Tên Xe", 100);
            listViewXe.Columns.Add("Loại Xe", 100);
            listViewXe.Columns.Add("Giá Thành", 100);
            listViewXe.Columns.Add("Phân Khối", 100);
            listViewXe.Columns.Add("Hãng Xe", 100);

            // Thêm các xe vào ListView
            foreach (var vehicle in vehicles)
            {
                var item = new ListViewItem(new string[]
                {
                    vehicle.MaXe,
                    vehicle.TenXe,
                    vehicle.LoaiXe,
                    vehicle.GiaThanh.ToString(),
                    vehicle.PhanKhoi.ToString(),
                    vehicle.HangXe
                });
                listViewXe.Items.Add(item);
            }
        }

        private void btnTimXe_Click(object sender, EventArgs e)
        {
            string maXe = txtMaXe.Text;
            string tenXe = txtTenXe.Text;
            string loaiXe = cbbLoaiXe.SelectedItem?.ToString();
            string hangXe = cbbHangXe.SelectedItem?.ToString();
            int.TryParse(txtGiaThanh.Text, out int giaThanh);
            int.TryParse(txtPhanKhoi.Text, out int phanKhoi);

            // Tìm kiếm xe dựa trên các tiêu chí
            var results = vehicles.FindAll(v =>
                (string.IsNullOrEmpty(maXe) || v.MaXe.Contains(maXe)) &&
                (string.IsNullOrEmpty(tenXe) || v.TenXe.Contains(tenXe)) &&
                (string.IsNullOrEmpty(loaiXe) || v.LoaiXe == loaiXe) &&
                (string.IsNullOrEmpty(hangXe) || v.HangXe == hangXe) &&
                (giaThanh == 0 || v.GiaThanh <= giaThanh) &&
                (phanKhoi == 0 || v.PhanKhoi <= phanKhoi)
            );

            // Hiển thị kết quả tìm kiếm trong ListView
            listViewXe.Items.Clear();
            foreach (var vehicle in results)
            {
                var item = new ListViewItem(new string[]
                {
                    vehicle.MaXe,
                    vehicle.TenXe,
                    vehicle.LoaiXe,
                    vehicle.GiaThanh.ToString(),
                    vehicle.PhanKhoi.ToString(),
                    vehicle.HangXe
                });
                listViewXe.Items.Add(item);
            }

            if (results.Count == 0)
            {
                MessageBox.Show("Không tìm thấy xe nào phù hợp.");
            }
        }
    }

    // Lớp Vehicle để lưu trữ thông tin xe
    public class Vehicle
    {
        public string MaXe { get; set; }
        public string TenXe { get; set; }
        public string LoaiXe { get; set; }
        public int GiaThanh { get; set; }
        public int PhanKhoi { get; set; }
        public string HangXe { get; set; }
    }
}
