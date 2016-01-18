using System.Collections.Generic;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        private bool _dataLoaded;

        protected override void OnDataLoaded()
        {
            _dataLoaded = true;
            NotifyPropertyChanged("OrderItems");
        }

        public List<Order> OrderItems
        {
            get
            {
                if (_dataLoaded) return base.Repository.Orders;
                else return null;
            }
        }
    }
}
