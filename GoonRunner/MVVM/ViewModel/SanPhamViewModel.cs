using GoonRunner.MVVM.View;
using System.Collections.ObjectModel;
using System.Data;
using System.Xml.Linq;

namespace GoonRunner.MVVM.ViewModel
{
    public class Sanpham
    {
        public int Masp { get; set; }
        public string Tensp { get; set; }
        public string Loaisp { get; set; }
        public int Gia { get; set; }
        public int Soluong { get; set; }
        public int Thoigianbaohanh { get; set; }
        public string Nhasx { get; set; }
    }
    public class SanPhamViewModel
    {
        public ObservableCollection<Sanpham> sanphams { get; set; }
        public SanPhamViewModel()
        {
            sanphams = new ObservableCollection<Sanpham>();
            XDocument doc = XDocument.Load(@"Data\Sanpham.xml");
            foreach (var element in doc.Descendants("Sanpham"))
            {
                sanphams.Add(new Sanpham
                {
                    Masp = int.Parse(element.Element("Masp").Value),
                    Tensp = element.Element("Tensp").Value,
                    Loaisp = element.Element("Loaisp").Value,
                    Gia = int.Parse(element.Element("Gia").Value),
                    Thoigianbaohanh = int.Parse(element.Element("Thoigianbaohanh").Value),
                    Nhasx = element.Element("Nhasx").Value
                });
            }
        }
    }
}