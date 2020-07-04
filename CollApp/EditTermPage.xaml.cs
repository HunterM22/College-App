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
    public partial class EditTermPage : ContentPage
    {
        public static string TStart { get; set; }
        public static string TEnd { get; set; }

        public static DateTime strt { get; set; }
        public static DateTime nd { get; set; }

        public EditTermPage(Term SelectedTerm)
        {
            InitializeComponent();

            Globals.SelectedTerm = SelectedTerm;

            etbTermName.Text = SelectedTerm.TermName;
            Start.Date = Convert.ToDateTime(SelectedTerm.Start);
            End.Date = Convert.ToDateTime(SelectedTerm.End);
        }

       
        public void eTStartDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            TStart = e.NewDate.ToString();
            strt = e.NewDate;
        }

        public void eTEndDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            TEnd = e.NewDate.ToString();
            nd = e.NewDate;
        }

        public void ETSaveButton_Clicked(object sender, EventArgs e)
        {
            Globals.SelectedTerm.TermName = etbTermName.Text;
            Globals.SelectedTerm.Start = Convert.ToDateTime(TStart);
            Globals.SelectedTerm.End = Convert.ToDateTime(TEnd);

            if (strt > nd)
            {
                DisplayAlert("Alert", "Term start date must be prior to term end date", "OK");
                return;
            }

            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.CreateTable<Term>();
                int rows = con.Update(Globals.SelectedTerm);

                if (rows > 0)
                    DisplayAlert("Success", "Term Updated", "Ok");
                else
                    DisplayAlert("Failed", "Term Not Updated", "Ok");
            }

            Navigation.PushAsync(new MainPage());
        }
    }
}