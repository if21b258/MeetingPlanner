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
using System.Windows.Shapes;
using TourPlannerUI.ViewModel;

namespace TourPlannerUI.View
{
    /// <summary>
    /// Interaction logic for EditTourLogWindow.xaml
    /// </summary>
    public partial class EditTourLogWindow : Window
    {
        public EditTourLogWindow()
        {
            InitializeComponent();

            var context = this.DataContext as EditTourLogViewModel;
            context.CloseEvent += (value) => this.DialogResult = value;
        }
    }
}
