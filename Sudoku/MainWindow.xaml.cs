using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Sudoku
{
    public partial class MainWindow : Window
    {
        private const int InnerWidth = 3;
        private const int OuterWidth = InnerWidth * InnerWidth;

        private const int Thin = 1;
        private const int Thick = 3;

        public MainWindow()
        {
            InitializeComponent();
            InitializeSudokuTable();
        }

        private void InitializeSudokuTable()
        {
            var grid = new UniformGrid
            {
                Rows = OuterWidth,
                Columns = OuterWidth
            };

            for (var i = 0; i < OuterWidth; i++)
            {
                for (var j = 0; j < OuterWidth; j++)
                {
                    var left = j % InnerWidth == 0 ? Thick : Thin;
                    var top = i % InnerWidth == 0 ? Thick : Thin;
                    var right = j == OuterWidth - 1 ? Thick : 0;
                    var bottom = i == OuterWidth - 1 ? Thick : 0;

                    var border = new Border
                    {
                        BorderThickness = new Thickness(left, top, right, bottom),
                        BorderBrush = Brushes.Black
                    };

                    grid.Children.Add(border);
                }
            }

            SudokuTable.Child = grid;
        }
    }
}
