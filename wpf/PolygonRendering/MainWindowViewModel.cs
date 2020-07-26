using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PolygonRendering
{
    public class MainWindowViewModel : ObservableObject
    {
        public ObservableCollection<DrawObject> CanvasSource { get; set; }
        public ICommand AddCommand { get; set; }

        public class DrawObject
        {
            public string name { get; set; }
            public PathGeometry shape { get; set; }
            public Brush color { get; set; }
            public double thickness { get; set; }
        }

        public MainWindowViewModel()
        {
            CanvasSource = new ObservableCollection<DrawObject>();
            AddCommand = new RelayCommand(Add);
        }


        private void Add(object parameter)
        {
            var shape1 = new PathGeometry();
            shape1.Figures.Add((new PathFigure(
                new Point(100, 100),
                new List<LineSegment>()
                {
                    new LineSegment(new Point(100, 200), true),
                    new LineSegment(new Point(200, 300), true),
                    new LineSegment(new Point(300, 400), true),
                    new LineSegment(new Point(400, 100), true),
                }, true)));

            CanvasSource.Add(new DrawObject { color = new SolidColorBrush(Colors.Red), shape = shape1, thickness = 1 });

            var shape2 = new PathGeometry();
           
            shape2.Figures.Add((new PathFigure(
                new Point(200, 100),
                new List<LineSegment>() { new LineSegment(new Point(100, 200), true) }, false)));

            CanvasSource.Add(new DrawObject { color = new SolidColorBrush(Colors.Blue), shape = shape2, thickness = 1 });
        }
    }
}
