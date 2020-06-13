using CollApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTermPage : ContentPage
    {
        public static string Start { get; set; }
        public static string End { get; set; }

        public AddTermPage()
        {
            InitializeComponent();
        }

        private void TStartDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            Start = e.NewDate.ToString();
        }

        private void TEndDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            End = e.NewDate.ToString();
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            Term tm = new Term()
            {
                TermName = tbTermName.Text,

            };
        }
    }
}
