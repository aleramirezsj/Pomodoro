﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pomodoro2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pomodoro2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<NotificationObject>(this,"GotoConfiguration",(a) =>
            {
                Detail = new NavigationPage(ConfigurationPage());
                IsPresented = false;
            });
        }

        //private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var item = e.SelectedItem as RootPageMenuItem;
        //    if (item == null)
        //        return;

        //    var page = (Page)Activator.CreateInstance(item.TargetType);
        //    page.Title = item.Title;

        //    Detail = new NavigationPage(page);
        //    IsPresented = false;

        //    //MasterPage.ListView.SelectedItem = null;
        //}
    }
}