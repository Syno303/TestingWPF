using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.Classes;

namespace WpfApp {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        internal List<Person> people = new List<Person>();
        public MainWindow() {
            InitializeComponent();
            people.Add(new Person {
                FirstName = "Koen",
                LastName = "P"
            }); people.Add(new Person {
                FirstName = "Sam",
                LastName = "B"
            }); people.Add(new Person {
                FirstName = "Okke",
                LastName = "R"
            });
           comboBox1.ItemsSource = people;

            
        }

        private void submitButton_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show($"Hello Horse {firstNameText.Text}");
        }
    }
}
