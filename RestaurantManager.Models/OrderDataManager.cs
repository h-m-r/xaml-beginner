using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class OrderDataManager : DataManager
    {       
        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new List<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5]
            };

            OnPropertyChanged("MenuItems");
            OnPropertyChanged("CurrentlySelectedMenuItems");
        }

        public List<MenuItem> MenuItems { get; set; }

        public List<MenuItem> CurrentlySelectedMenuItems { get; set; }
    }
}
