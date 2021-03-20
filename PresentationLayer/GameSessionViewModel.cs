using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TBQuestGame.DataLayer;
using TBQuestGame.Models;
using System.Collections.ObjectModel;

namespace TBQuestGame.PresentationLayer
{
    public class GameSessionViewModel : ObservableObject
    {
        #region FIELDS

        private Player _player;
        private List<string> _messages;
        private Map _map;
        private Location _currentLocation;
        private GameItem _currentGameItem;
        

        


        #endregion
        #region PROPERTIES
        public Map Map
        {
            get { return _map; }
            set
            {
                _map = value;
                OnPropertyChanged(nameof(Map));
            }
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
        /// <summary>
        /// return the list of strings with new lines between each message
        /// </summary>
        public string MessageDisplay
        {
            get { return string.Join("\n\n", _messages); }
        }

        public Player Player
        {
            
            get { return _player; }
            set 
            { 
                _player = value;
                OnPropertyChanged(nameof(Player));            
            }
        }
        public GameItem CurrentGameItem
        {
            get { return _currentGameItem; }
            set { _currentGameItem = value; }
        }

        #endregion
        #region CONSTRUCTORS

        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(Player player, List<string> startUpMessage, Map map)
        {
            Player = GameData.PlayerData();
            Player.Name = player.Name;
            Player.Age = player.Age;
            _messages = startUpMessage;

            Map = map;
            Map.CurrentLocation = _map.MapLocations.FirstOrDefault(l => l.Id == _map.CurrentLocationId);
        }

        #endregion
        #region METHODS
        /// <summary>
        /// Method to move player back one in map
        /// </summary>
        internal void MoveToPreviousIsle()
        {
            if (Map.CurrentLocationId > 0)
            {
                _map.CurrentLocationId -= 1;
                Map.CurrentLocation = _map.MapLocations.FirstOrDefault(l => l.Id == _map.CurrentLocationId);
                InitializeView();
                //OnPlayerMove();
            }
        }
        /// <summary>
        /// Method to move player to the next map location
        /// </summary>
        public void MoveToNextIsle()
        {
            //take the maps current location Id and compare it to the location array length
            if (Map.CurrentLocationId < _map.MapLocations.Length - 1)
            {
                _map.CurrentLocationId += 1;
                Map.CurrentLocation = _map.MapLocations.FirstOrDefault(l => l.Id == _map.CurrentLocationId);
                //OnPlayerMove();
                ModifyHealth();
            }
        }
        /// <summary>
        /// ***Switch method to use observable objects for health***
        /// </summary>
        public void ModifyHealth()
        {
            if (Map.CurrentLocationId == 5)
            {
                Player.Health = Player.Health - 50;
            }
            //if (Player.Health == 0)
            //{
            //    Player.Lives--;
            //}
        }
        private void InitializeView()
        {
            _player.UpdateInventoryCategories();
        }
        /// <summary>
        /// player move event handler    *** Error **
        /// </summary>
        //private void OnPlayerMove()
        //{
        //    //
        //    // update player stats when in new location
        //    //
        //    if (!_player.HasVisited(location: Map.CurrentLocation))
        //    {
        //        //
        //        // add location to list of visited locations
        //        //
        //        _player.LocationsVisited.Add(_map.CurrentLocation);

        //        //
        //        // update health
        //        //
        //        _player.Health += _map.CurrentLocation.ModifyHealth;

        //        //
        //        // update lives
        //        //
        //        _player.Lives += _map.CurrentLocation.ModifyLives;

        //        //
        //        // display a new message if available
        //        //
        //        OnPropertyChanged(nameof(MessageDisplay));
        //    }
        //}

        /// <summary>
        /// Method to add to player inventory by taking item from current game map location
        /// </summary>
        public void AddItemToInventory()
        {
            //check to see if a game item is selected and is in the current location
            if (_currentGameItem != null && _map.CurrentLocation.GameItems.Contains(_currentGameItem))
            {
                // Cast selected game item
                GameItem selectedGameItem = _currentGameItem as GameItem;

                Map.CurrentLocation.RemoveGameItemFromLocation(selectedGameItem);
                _player.AddGameItemToInventory(selectedGameItem);

                //OnPlayerPickUp(selectedGameItem);
            }
        }
  
        //private void OnPlayerPickUp(GameItem selectedGameItem)
        //{
        //    _player.Currency -= GameItem.Price;
        //}

        /// <summary>
        /// method to remove items from player inventory and place back into location
        /// </summary>
        public void RemoveItemFromInventory()
        {
            //check to see if a game item is selected and is in the current location
            //subtract from inventory and add to current location
            if (_currentGameItem != null)
            {
                //cast selected game item
                GameItem selectedGameItem = _currentGameItem as GameItem;

                Map.CurrentLocation.AddGameItemToLocation(selectedGameItem);
                _player.RemoveGameItemFromInventory(selectedGameItem);

                //OnPlayerPutDown(selectedGameItem);
            }
        }
        //Add OnPlayerPutDown method
        //private void OnPlayerPutDown(GameItem gameItem)
        //{
        //    _player.Currency += //price of item
        //}


        /// <summary>
        /// A method for player death   ***USED IN LATER VERSION***
        /// </summary>
        /// <param name="message"></param>
        //private void OnPlayerDies(string message)
        //{
        //    string messageText = message + "\nWould you like to play again?";

        //    string titleText = "Death";
        //    MessageBoxButton button = MessageBoxButton.YesNo;
        //    MessageBoxResult result = MessageBox.Show(messageText, titleText, button);

        //    switch (result)
        //    {
        //        case MessageBoxResult.Yes:
        //            ResetPlayer();
        //            break;
        //        case MessageBoxResult.No:
        //            QuitApplication();
        //            break;
        //    }
        //}
        /// <summary>
        /// Method to quit the game
        /// </summary>
        //private void QuitApplication()
        //{
        //    Environment.Exit(0);
        //}
        ///// <summary>
        ///// Reset the game with the same player info
        ///// </summary>
        //private void ResetPlayer()
        //{
        //    //update to reset game with same player info
        //    Environment.Exit(0);
        //}
        #endregion

    }
}
