using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin_PickerBorderOutlined
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void StandardPickerOutlined_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picker.SelectedIndex > -1)
            {
                var d = 0d;
            }
        }
    }
}
