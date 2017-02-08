using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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

namespace WpfShowInputAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // it isn't working
        private async void P_OnMessageShow(object sender, EventArgs e)
        {
            var result = await this.ShowInputAsync("Test", "Test message isn't showing");

            this.ShowModalMessageExternal("Test", "Message from page was showed");

            PageAdditional p = (PageAdditional)pageWithButton.Content;
            if (p == null)
            { return; }
            p.MessageReceived(this, e);
        }

        // it is working correctly
        private async void butMainWindow_Click(object sender, RoutedEventArgs e)
        {
            var result = await this.ShowInputAsync("Test", "Test message is showing");
        }
        
        private void MetroWindow_ContentRendered(object sender, EventArgs e)
        {
            PageAdditional p = (PageAdditional)pageWithButton.Content;
            if (p == null)
            { return; }
            p.OnMessageShow += P_OnMessageShow;
        }
    }
}
