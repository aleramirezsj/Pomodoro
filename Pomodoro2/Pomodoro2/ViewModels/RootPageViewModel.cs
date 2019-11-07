using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Pomodoro2.ViewModels
{
    public class RootPageViewModel : NotificationObject
    {
        private ObservableCollection<string> menuItems;

        public ObservableCollection<string> MenuItems
        {
            get { return menuItems; }
            set
            {
                menuItems = value;
                OnPropertyChanged();
            }
        }
        private string selectedMenuItem;

        public string SelectedMenuItem
        {
            get { return selectedMenuItem; }
            set
            {
                selectedMenuItem = value;
                OnPropertyChanged();
            }
        }

        public RootPageViewModel()
        {
            MenuItems = new ObservableCollection<string>();
            MenuItems.Add("Pomodoro");
            MenuItems.Add("Histórico");
            MenuItems.Add("Configuración");

            PropertyChanged += RootPageViewModel_PropertChanged;
        }

        private void RootPageViewModel_PropertChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName==nameof(SelectedMenuItem))
            {
                if (SelectedMenuItem=="Configuración")
                {
                    MessagingCenter.Send(this, "GotoConfiguration");
                }
            }
        }
    }
}
