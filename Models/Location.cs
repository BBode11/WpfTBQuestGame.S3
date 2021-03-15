using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Location : ObservableObject
    {
        #region FIELDS
        private int _id;
        private string _name;
        private string _description;
        private int _modifyHealth;
        private ObservableCollection<GameItem> _gameItems;

       

        //private int _modifyLives;
        //private bool _accessible;



        private string _message;
        //add accessible for checkout?

        #endregion

        #region PROPERTIES
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        } 
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public int ModifyHealth
        {
            get { return _modifyHealth; }
            set { _modifyHealth = value; }
        }
        //public int ModifyLives
        //{
        //    get { return _modifyLives; }
        //    set { _modifyLives = value; }
        //}
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        //public bool Accessible
        //{
        //    get { return _accessible; }
        //    set { _accessible = value; }
        //}
        public ObservableCollection<GameItem> GameItems
        {
            get { return _gameItems; }
            set { _gameItems = value; }
        }


        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// Constructor to instantiate the observable list
        /// </summary>
        public Location()
        {
            _gameItems = new ObservableCollection<GameItem>();
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Recreate the observable collection and update the locations game items
        /// </summary>
        public void UpdatedLocationGameItems()
        {
            ObservableCollection<GameItem> updatedLocationGameItems = new ObservableCollection<GameItem>();
            
            foreach (GameItem GameItem in _gameItems)
            {
                updatedLocationGameItems.Add(GameItem);
            }

            GameItems.Clear();

            foreach (GameItem gameItem in updatedLocationGameItems)
            {
                GameItems.Add(gameItem);
            }
        }
        /// <summary>
        /// Add the selected items to the location
        /// </summary>
        /// <param name="selectedGameItem"></param>
        public void AddGameItemToLocation(GameItem selectedGameItem)
        {
            if (selectedGameItem == null)
            {
                _gameItems.Add(selectedGameItem);
            }

            UpdatedLocationGameItems();
        }
        /// <summary>
        /// Remove the selected items from the location
        /// </summary>
        /// <param name="selectedGameItem"></param>
        public void RemoveGameItemFromLocation(GameItem selectedGameItem)
        {
            if(selectedGameItem == null)
            {
                _gameItems.Remove(selectedGameItem);
            }
            //call UpdatedLocationGameItems to update location
            UpdatedLocationGameItems();
        }

        #endregion
    }
}
