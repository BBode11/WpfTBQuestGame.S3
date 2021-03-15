using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class BuildMaterial : GameItem
    {
        #region PROPERTIES
        // auto implemented properties
        public int Price { get; set; }
        #endregion
        #region CONSTRUCTORS
        /// <summary>
        /// Constructor for BuildMaterial inheriting from GameItem
        /// </summary>
        /// <param name="id"></param>
        /// <param name="price"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public BuildMaterial(int id, int price, string name, string description) : base(id, name, description)
        {
            Price = price;
        }
        #endregion
        #region METHODS

        public override string InformationString()
        {
            return $"{Name}: {Description}";
        }

        #endregion
    }
}
