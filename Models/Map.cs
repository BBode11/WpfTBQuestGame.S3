using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQuestGame.Models
{
    public class Map : ObservableObject
    {
        #region FIELDS
        //create map location array
        private Location[] _mapLocations;
        private Location _currentLocation;
        private int _currentLocationId;
        private List<GameItem> _standardGameItems;

        #endregion

        #region PROPERTIES
        public Location[] MapLocations
        {
            get { return _mapLocations; }
            set { _mapLocations = value; }
        }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set 
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
            }
        }
        public int CurrentLocationId
        {
            get { return _currentLocationId; }
            set 
            {
                _currentLocationId = value;
                OnPropertyChanged(nameof(_currentLocationId));
            }
        }
        public List<GameItem> StandardGameItems
        {
            get { return _standardGameItems; }
            set { _standardGameItems = value; }
        }


        #endregion

        #region CONSTRUCTORS

        public Map()
        {
            //Initialize the location
        }

        #endregion

        #region METHODS
       
        #endregion
    }
}
