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
    public partial class AssessmentView : ContentPage
    {
        public AssessmentView()
        {
            InitializeComponent();
        }

        private void ADDASSESSMENT_Clicked(object sender, EventArgs e)
        {

        }

        private void EDITASSESSMENT_Clicked(object sender, EventArgs e)
        {

        }

        private void DROPASSESSMENT_Clicked(object sender, EventArgs e)
        {

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.CreateTable<Assessment>();
                var Assess = con.Table<Assessment>().ToList();

                AssessmentLV.ItemsSource = Assess;

            }

        }
    }
}