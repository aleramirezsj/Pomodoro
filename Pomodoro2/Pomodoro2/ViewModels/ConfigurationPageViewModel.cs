﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pomodoro2.ViewModels
{
    public class ConfigurationPageViewModel : NotificationObject
    {
        private ObservableCollection<int> pomodoroDurations;

        public ObservableCollection<int> PomodoroDurations
        {
            get { return pomodoroDurations; }
            set
            {
                pomodoroDurations = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<int> breakDurations;

        public ObservableCollection<int> BreakDurations
        {
            get { return breakDurations; }
            set
            {
                breakDurations = value;
                OnPropertyChanged();
            }
        }

        private int selectedPomodoroDuration;

        public int SelectedPomodoroDuration
        {
            get { return selectedPomodoroDuration; }
            set
            {
                selectedPomodoroDuration = value;
                OnPropertyChanged();
            }
        }

        private int selectedBreakDuration;

        public int SelectedBreakDuration
        {
            get { return selectedBreakDuration; }
            set
            {
                selectedBreakDuration = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; set; }

        public ConfigurationPageViewModel()
        {
            LoadPomodorDurations();
            LoadBreakDurations();
            SaveCommand = new Command(SaveCommandExecute);
        }

        private void LoadBreakDurations()
        {
            PomodoroDurations = new ObservableCollection<int>();
            PomodoroDurations.Add(1);
            PomodoroDurations.Add(5);
            PomodoroDurations.Add(10);
            PomodoroDurations.Add(25);
        }

        private void LoadPomodorDurations()
        {
            BreakDurations = new ObservableCollection<int>();
            BreakDurations.Add(1);
            BreakDurations.Add(5);
            BreakDurations.Add(10);
            BreakDurations.Add(25);
        }

        private async void SaveCommandExecute(object obj)
        {
            Application.Current.Properties["PomodoroDuration"] = SelectedPomodoroDuration;
            Application.Current.Properties["BreakDuration"] = SelectedBreakDuration;

            await Application.Current.SavePropertiesAsync();
        }
    }
}
