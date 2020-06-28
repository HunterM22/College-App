using CollApp.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CollApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        private void ADDTERM_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddTermPage());
        }

        private void EDITTERM_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditTermPage(Globals.SelectedTerm));
        }

        private void DROPTERM_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                try
                {
                    con.CreateTable<Term>();
                    int rows = con.Delete(Globals.SelectedTerm);

                    if (rows > 0)
                        DisplayAlert("Success", "Term Deleted", "Ok");
                    else
                        DisplayAlert("Failed", "Term Not Deleted", "Ok");
                }
                catch
                {
                    return;
                }
            }
            Navigation.PushAsync(new MainPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.CreateTable<Term>();
                var Terms = con.Table<Term>().ToList();

                TermLV.ItemsSource = Terms;             
                
            }
            

        }

        //public async void lvItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    var myListView = (ListView)sender;
        //    var myItem = myListView.SelectedItem;

        //}

        private void VIEWCOURSES_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new CourseView());
            }
            catch
            {
                DisplayAlert("Alert", "Please select a term", "OK");
                Navigation.PushAsync(new MainPage());
            }
        }

        //private void TermLV_Tapped(object sender, EventArgs e)
        //{
        //    Globals.TermLVTapped = TermLV.SelectedItem.ToString();
        //}

        public void TermLV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Globals.SelectedTerm = TermLV.SelectedItem as Term;
            var SelectedTerm = TermLV.SelectedItem as Term;
        }
    }
}
