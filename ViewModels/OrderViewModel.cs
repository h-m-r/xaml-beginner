using RestaurantManager.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using Windows.UI.Popups;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        public DelegateCommand<MenuItem> AddToCurrentSelection { get; private set; }
        public DelegateCommand<object> AddOrder { get; private set; }

        public OrderViewModel()
        {
            AddToCurrentSelection = new DelegateCommand<MenuItem>(addMenuItem);
            AddOrder = new DelegateCommand<object>(addOrder);
        }

        private async void addOrder(object param)
        {
            if (CurrentlySelectedMenuItems.Count > 0)
            {
                Order newOrder = new Order
                {
                    Complete = false,
                    Expedite = false,
                    Items = new List<MenuItem>(CurrentlySelectedMenuItems),
                    Table = base.Repository.Tables[0],
                    SpecialRequests = this.CurrentSpecialRequest
                };

                CurrentlySelectedMenuItems.Clear();
                CurrentSpecialRequest = String.Empty;
                NotifyPropertyChanged("CurrentlySelectedMenuItems");
                NotifyPropertyChanged("CurrentSpecialRequest");

                await new MessageDialog("Order was added").ShowAsync();

                base.Repository.Orders.Add(newOrder);
            }
        }

        private void addMenuItem(MenuItem item)
        {
            CurrentlySelectedMenuItems.Add(item);
            NotifyPropertyChanged("CurrentlySelectedMenuItems");
        }

        protected override void OnDataLoaded()
        {
            MenuItems = base.Repository.StandardMenuItems;
            CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>();
            CurrentSpecialRequest = String.Empty;

            NotifyPropertyChanged("MenuItems");
        }

        public List<MenuItem> MenuItems { get; set; }

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems { get; set; }

        public string CurrentSpecialRequest { get; set; }
    }
}
