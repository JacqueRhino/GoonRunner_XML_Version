using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using SharpVectors.Converters;
using SharpVectors.Runtime;

namespace GoonRunner.Core
{
    public class SvgViewboxEx : SvgViewbox
    {
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(string), typeof(SvgViewboxEx));
        
        public static readonly DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(Brush), typeof(SvgViewboxEx), new PropertyMetadata(Brushes.BlueViolet));

        public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register("Stroke", typeof(Brush), typeof(SvgViewboxEx), new PropertyMetadata(Brushes.DarkViolet));

        public string Source
        {
            get => (string) GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }
        public Brush Fill
        {
            get => (Brush) GetValue(FillProperty);
            set => SetValue(FillProperty, value);
        }

        public Brush Stroke
        {
            get => (Brush) GetValue(StrokeProperty);
            set => SetValue(StrokeProperty, value);
        }

        protected override void OnSettingsChanged()
        {
            base.OnSettingsChanged();

            var drawings = ((SvgDrawingCanvas) Child).DrawObjects;

            foreach (var drawing in drawings)
            {
                if (drawing is GeometryDrawing geometryDrawing)
                {
                    // svg fill color - translated to a geometry.Brush
                    var brush = new Binding(nameof(Fill))
                                    {
                                        Source = this,
                                        Mode = BindingMode.OneWay
                                    };
                    BindingOperations.SetBinding(geometryDrawing, GeometryDrawing.BrushProperty, brush);

                    // svg stroke color - translated to a geometry.Pen.Brush
                    if (geometryDrawing.Pen != null)
                    {
                        var stroke = new Binding(nameof(Stroke))
                                         {
                                             Source = this,
                                             Mode = BindingMode.OneWay
                                         };
                        BindingOperations.SetBinding(geometryDrawing.Pen, Pen.BrushProperty, stroke);
                    }
                }
            }
        }
    }}