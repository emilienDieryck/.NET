using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TopPlaces
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PlaceData placeData = new PlaceData();
            this.listBoxPhotos.DataContext = placeData.PlacesList;
        }

        private void listBoxPhotos_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Place place = (Place)listBoxPhotos.SelectedItem;
            BitmapSource photo = BitmapFrame.Create(new Uri(place.Path));
            imagePhoto.Source = photo; // référence vers la balise image dans MainWindow.xaml
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Place place = (Place)listBoxPhotos.SelectedItem;
            place.Votes();
        }
    }
}