using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GoonRunner.MVVM.ViewModel
{
    public class SidebarSanPhamViewModel : BaseViewModel
    {
        Sanpham sanphams;
        public int Masp {  get; set; }
        public string Tensp { get; set; }
        public string Loaisp { get; set; }
        public int Soluong { get; set; }
        public int Giasp { get; set; }
        public int Thoigianbaohanh { get; set; }
        public string Nhasx { get; set; }

        public ICommand AddSanPhamCommand { get; set; }
        private int _masp;
        public int MaSP { get => _masp; set { _masp = value; OnPropertyChanged(); } }
        private string _tensp;
        public string TenSP { get => _tensp; set { _tensp = value; OnPropertyChanged(); } }
        private string _loaisp;
        public string LoaiSP { get => _loaisp; set { _loaisp = value; OnPropertyChanged(); } }
        private int _soluong;
        public int SoLuong { get => _soluong; set { _soluong = value; OnPropertyChanged(); } }
        private int _gia;
        public int GiaSP { get => _gia; set { _gia = value; OnPropertyChanged(); } }
        private int _thoigianbaohanh;
        public int ThoiGianBaoHanh { get => _thoigianbaohanh; set { _thoigianbaohanh = value; OnPropertyChanged(); } }
        private string _nhasx;
        public string NhaSX { get => _nhasx; set { _nhasx = value; OnPropertyChanged(); } }

        public SidebarSanPhamViewModel() 
        {
            AddSanPhamCommand = new RelayCommand<Button>(p => 
            {
                sanphams = new Sanpham();
                sanphams.Masp = MaSP;
                sanphams.Tensp = TenSP;
                sanphams.Loaisp = LoaiSP;
                sanphams.Soluong = SoLuong;
                sanphams.Gia = GiaSP;
                sanphams.Thoigianbaohanh = ThoiGianBaoHanh;
                sanphams.Nhasx = NhaSX;
                MessageBox.Show("Yes");
            });    
        }
    }
}
