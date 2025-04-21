using GoonRunner.MVVM.View;
using System.Collections.ObjectModel;
using System.Data;
using System.Xml.Linq;

namespace GoonRunner.MVVM.ViewModel
{
    public class Khachhang
    {
        public string Makh { get; set; }
        public string Hotenkh { get; set; }
        public string Sdt { get; set; }
        public string Diachi { get; set; }
    }
    public class KhachHangViewModel
    {
        public ObservableCollection<Khachhang> khachhangs { get; set; }
        public KhachHangViewModel()
        {
            khachhangs = new ObservableCollection<Khachhang>();
            XDocument doc = XDocument.Load(@"Data\Khachhang.xml");
            foreach (var element in doc.Descendants("Khachhang"))
            {
                khachhangs.Add(new Khachhang
                {
                    Makh = element.Element("Makh").Value,
                    Hotenkh = element.Element("Hotenkh").Value,
                    Sdt = element.Element("Sdt").Value,
                    Diachi = element.Element("Diachi").Value
                });
            }
        }
    }
}