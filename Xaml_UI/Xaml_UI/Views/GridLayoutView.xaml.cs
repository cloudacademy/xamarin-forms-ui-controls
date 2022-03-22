using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xaml_UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GridLayoutView : ContentView
    {
        private bool portrait;
        public GridLayoutView()
        {
            InitializeComponent();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width > 0)
            {
                ReconfigureLayout(height > width);
            }
        }

        private void ReconfigureLayout(bool _portrait)
        {
            portrait = _portrait;
            if (portrait)
            {
                // If we are in landscape mode
                if (LayoutGrid.ColumnDefinitions.Count == 4)
                {
                    // Remove the frames/boxes
                    LayoutGrid.Children.Remove(BottomRed);
                    LayoutGrid.Children.Remove(BottomYellow);
                    LayoutGrid.Children.Remove(BottomBlue);
                    // Remove the fourth column
                    LayoutGrid.ColumnDefinitions.Remove(LayoutGrid.ColumnDefinitions[3]);
                    // Add the bottom row back in
                    LayoutGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.7, GridUnitType.Star) });
                    // add the frames/boxes to the bottom row
                    LayoutGrid.Children.Add(BottomRed, 0, 3);
                    LayoutGrid.Children.Add(BottomYellow, 1, 3);
                    LayoutGrid.Children.Add(BottomBlue, 2, 3);
                    // Add the 3 empty rows to the grid
                    LayoutGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    LayoutGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    LayoutGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    // Adjust the margins
                    BottomRed.Margin = new Thickness(10, 10, 0, 0);
                    BottomYellow.Margin = new Thickness(0, 10, 0, 0);
                    BottomBlue.Margin = new Thickness(0, 10, 10, 0);
                }
            }
            else
            {
                // If we are in portrait mode configuration
                if (LayoutGrid.ColumnDefinitions.Count == 3)
                {
                    // Remove the bottom 3 unused rows
                    LayoutGrid.RowDefinitions.Remove(LayoutGrid.RowDefinitions[6]);
                    LayoutGrid.RowDefinitions.Remove(LayoutGrid.RowDefinitions[5]);
                    LayoutGrid.RowDefinitions.Remove(LayoutGrid.RowDefinitions[4]);
                    // add a fourth column
                    LayoutGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    //Remove the bottom 3 frames/boxes from the grid
                    LayoutGrid.Children.Remove(BottomRed);
                    LayoutGrid.Children.Remove(BottomYellow);
                    LayoutGrid.Children.Remove(BottomBlue);
                    // Remove the frames' row
                    LayoutGrid.RowDefinitions.Remove(LayoutGrid.RowDefinitions[3]);
                    // Add the frames/boxes to the fourth column
                    LayoutGrid.Children.Add(BottomRed, 3, 0);
                    LayoutGrid.Children.Add(BottomYellow, 3, 1);
                    LayoutGrid.Children.Add(BottomBlue, 3, 2);
                    // Adjust the margins
                    BottomRed.Margin = new Thickness(0, 10, 10, 10);
                    BottomYellow.Margin = new Thickness(0, 10, 10, 10);
                    BottomBlue.Margin = new Thickness(0, 0, 10, 0);

                }
            }
        }
    }
}