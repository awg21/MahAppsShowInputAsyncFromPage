using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for PageAdditional.xaml
    /// </summary>
    public partial class PageAdditional : Page
    {
        public delegate void MessageShowHandler(object sender, EventArgs e);
        public event MessageShowHandler OnMessageShow;
        public AutoResetEvent OnMessageReceived = new AutoResetEvent(false);

        public PageAdditional()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Implementation of event handler to show Metro mindow inside main window with message
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="buttons"></param>
        private void MessageShow(string title, string message, string buttons)
        {
            // Make sure someone is listening to event
            if (OnMessageShow == null) return;

            EventArgs args = null;
            OnMessageShow(this, args);
        }

        public void MessageReceived(object sender, EventArgs e)
        {
            try
            {
                if (e.ToString() == "Cancel")
                {
                    throw new Exception("Exception of parsing of hours");
                }
            }
            catch 
            {
                // TODO log it
            }
            this.OnMessageReceived.Set();
        }

        private void butPage_Click(object sender, RoutedEventArgs e)
        {
            MessageShow("Additional information", "How much time will this SuperProcess take?", "HOURS");

            OnMessageReceived.WaitOne();
            OnMessageReceived.Reset();
        }
    }
}
