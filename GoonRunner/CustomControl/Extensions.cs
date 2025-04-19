using System.Windows;

namespace GoonRunner.CustomControl
{
    internal class Extensions
    {
        public static readonly DependencyProperty Header =
            DependencyProperty.RegisterAttached("Header", typeof(string), typeof(Extensions), new PropertyMetadata(default(string)));

        public static void SetHeader(UIElement element, string value)
        {
            element.SetValue(Header, value);
        }


        public static string GetHeader(UIElement element)
        {
            return (string)element.GetValue(Header);
        }
        
    }
}