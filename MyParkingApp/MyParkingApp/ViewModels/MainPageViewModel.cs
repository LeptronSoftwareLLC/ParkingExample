using MyParkingApp.Data.Remote;
using MyParkingApp.Data.Remote.APIObjects;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyParkingApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        IParkingServiceAPI _api;
        List<Location> _locations;
        public List<Location> Locations {
            get {
                return _locations;
                    }
            set {
                _locations = value;
                RaisePropertyChanged(nameof(Locations));
            } 
        }
        public MainPageViewModel(INavigationService navigationService, IParkingServiceAPI api)
            : base(navigationService)
        {
            Title = "Main Page";
            _api = api;
        }
        

        public override async void Initialize(INavigationParameters parameters)
        {                     
            Locations = await _api.GetAll();           
        }

        private Location _itemLocation;
        public  Location ItemLocation { 
            get {
                return _itemLocation;
            } 
            set {
                _itemLocation = value;
                StatusMessage = GetMessage(_itemLocation);
                RaisePropertyChanged(nameof(ItemLocation));
            } 
        }
        private string GetMessage(Location location)
        {
            //AppResources located in common project would be added here for hard coded strings
            return $"{location.Description} has {CalculateRemaining(location)} spaces remaining.";
        }
        private int CalculateRemaining(Location location)
        {
            return location.MaxSpaces - location.Count;
        }

        private string _message;
        public string StatusMessage { 
            get => _message;
            set { 
                _message = value;
                RaisePropertyChanged(nameof(StatusMessage));
            } 
        }

  

        private string _spaceId;
        public string SpaceID { get => _spaceId; set => _spaceId = value; }

        public DelegateCommand AddCommand => new DelegateCommand(async () => await AddCar());

        private async Task AddCar()
        {
          
            var list  = await _api.AddCar(_itemLocation.LocationID, _spaceId);
            SetNewMessage(list);

        }
        public DelegateCommand RemoveCommand => new DelegateCommand(async () => await RemoveCar());
       

        private async Task RemoveCar()
        {
         
            var list = await _api.RemoveCar(_itemLocation.LocationID, _spaceId);
            SetNewMessage(list);

        }
        private void SetNewMessage(List<Location> list)
        {
            var location = list.Find(l => l.LocationID == _itemLocation.LocationID);
            StatusMessage = GetMessage(location);
        }

    }
}
