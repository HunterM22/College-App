using CollApp.Classes;
using SQLite;
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
        public static string TStart { get; set; }
        public static string TEnd { get; set; }

        public AddTermPage()
        {
            InitializeComponent();
        }

        private void TStartDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            TStart = e.NewDate.ToString();
        }

        private void TEndDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            TEnd = e.NewDate.ToString();
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            Term tm = new Term()
            {
                TermName = tbTermName.Text,
                Start = TStart,
                End = TEnd 
            };

            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.CreateTable<Term>();
                int rowsAdded = con.Insert(tm);
            }

            Navigation.PushAsync(new MainPage());
        }
    }
}
