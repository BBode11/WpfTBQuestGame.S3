using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using TBQuestGame;
using System.Windows.Data;

namespace TBQuestGame.Models
{
    /// <summary>
    /// Player class with inheritance from character class
    /// </summary>
    public class Player: Character
    {
        #region FIELDS
        //attributes of player
        private int _health;
        private int _lives;
        private int _currency;

        private List<Location> _locationsVisited;
        private ObservableCollection<GameItem> _inventory;
        private ObservableCollection<GameItem> _weapons;
        private ObservableCollection<GameItem> _buildMaterials;

        #endregion

        #region PROPERTIES
        public List<Location> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }
        public int Currency
        {
            get { return _currency; }
            set 
            { 
                _currency = value;
                OnPropertyChanged(nameof(Currency));
            }
        }

        public int Lives
        {
            get { return _lives; }
            set 
            { 
                _lives = value;
                OnPropertyChanged(nameof(Lives));
            }
        }

        public int Health
        {
            get { return _health; }
            set 
            {
                _health = value;
                if (_health > 100)
                {
                    _health = 100;
                }
                else if (_health <= 0)
                {
                    _health = 100;
                    _lives--;
                }
                OnPropertyChanged(nameof(Health));
            }
        } 
        public ObservableCollection<GameItem> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
        public ObservableCollection<GameItem> Weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
        }
        public ObservableCollection<GameItem> BuildMaterials
        {
            get { return _buildMaterials; }
            set { _buildMaterials = value; }
        }
        #endregion
        #region CONSTRUCTORS
        /// <summary>
        /// constructor for instantiating each observable collection
        /// </summary>
        public Player()
        {
            _locationsVisited = new List<Location>();
            _weapons = new ObservableCollection<GameItem>();
            _buildMaterials = new ObservableCollection<GameItem>();
        }
        #endregion
        #region METHODS
        

        /// <summary>
        /// Method for updating the observable collection of the derived game items
        /// </summary>
        public void UpdateInventoryCategories()
        {
            Weapons.Clear();
            BuildMaterials.Clear();
          
            foreach (var gameItem in _inventory)
            {
                if (gameItem is Weapon) Weapons.Add(gameItem);
                if (gameItem is BuildMaterial) BuildMaterials.Add(gameItem);
            }
        }
        /// <summary>
        /// Add selected GameItem to inventory
        /// </summary>
        /// <param name="selectedGameItem"></param>
        public void AddGameItemToInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _inventory.Add(selectedGameItem);
            }
        }
        /// <summary>
        /// Method for removing game item from inventory
        /// </summary>
        /// <param name="selectedGameItem"></param>
        public void RemoveGameItemFromInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _inventory.Remove(selectedGameItem);
            }
        }
        /// <summary>
        /// Method used for locations user has been
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool HasVisited(Location location)
        {
            return _locationsVisited.Contains(location);
        }
        public override string DefaultPlayerGreeting()
        {
            return $"Hello my name is {_name} and I am looking for materials.";
        }

        #endregion
    }
}
