﻿using CollApp.Classes;
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
        public static DateTime TStart { get; set; }
        public static DateTime TEnd { get; set; }
        public static DateTime strt { get; set; }
        public static DateTime nd { get; set; }

        public AddTermPage()
        {
            InitializeComponent();
            TEnd = DateTime.Today;
            TEnd = DateTime.Today;
            strt = DateTime.Today;
            nd = DateTime.Today;
        }

        private void TStartDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            TStart = e.NewDate;
            strt = e.NewDate;
        }

        private void TEndDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            TEnd = e.NewDate;
            nd = e.NewDate;
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (strt > nd)
            {
                DisplayAlert("Alert", "Term start date must be prior to term end date", "OK");
                return;
            }

            Term tm = new Term()
            {
                TermName = tbTermName.Text,
                Start = TStart,
                End = TEnd, 
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
