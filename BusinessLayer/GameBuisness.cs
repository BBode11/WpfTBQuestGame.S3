using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using TBQuestGame.DataLayer;
using TBQuestGame.PresentationLayer;
using System.Collections.ObjectModel;

namespace TBQuestGame.BusinessLayer
{
    public class GameBuisness
    {
        bool _newPlayer = true;
        PlayerSetupView _playerSetupView;
        GameSessionViewModel _gameSessionViewModel;

        Player _player = new Player();
        List<string> _messages;
        Map _map;



        /// <summary>
        /// This method starts and runs the game
        /// </summary>
        public GameBuisness()
        {
            SetupPlayer();
            InitializeDataSet();
            InstantiateAndShowView();
        }


        /// <summary>
        /// Sets up the new player and sets player properties
        /// </summary>
        private void SetupPlayer()
        {
            if (_newPlayer)
            {
                _playerSetupView = new PlayerSetupView(_player);
                _playerSetupView.ShowDialog();

                //setup game based player properties
                _player.Health = 100;
                _player.Lives = 3;
                _player.Currency = 125;
            }
            else
            {
                _player = GameData.PlayerData();
            }
        }

        /// <summary>
        /// Create view model with data set
        /// </summary>
        private void InstantiateAndShowView()
        {
            //INSTANTIATE the view model and INITIALIZE the data set
            _gameSessionViewModel = new GameSessionViewModel(_player, _messages, _map);
            GameSessionView gameSessionView = new GameSessionView(_gameSessionViewModel);

            gameSessionView.DataContext = _gameSessionViewModel;

            gameSessionView.Show();

            _playerSetupView.Close();
        }

        /// <summary>
        /// Initialize the data set and game map
        /// </summary>
        private void InitializeDataSet()
        {
            //added _player
           // _player = GameData.PlayerData();
            _messages = GameData.StartUpMessage();
            _map = GameData.MapData();
        }
    }
}
