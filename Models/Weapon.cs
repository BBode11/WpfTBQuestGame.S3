using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Weapon : GameItem
    {
        #region PROPERTIES
        // auto implemented properties
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }
        #endregion
        #region CONSTRUCTORS
        /// <summary>
        /// Constructor to inculde damage and speed while inheriting from GameItem
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public Weapon(int id, string name, int minDamage, int maxDamage, string description) : base(id, name, description)
        {
            MinimumDamage = minDamage;
            MaximumDamage = maxDamage;

        }
        #endregion
        #region METHODS
        public override string InformationString()
        {
            return $"{Name}: {Description}\nDamage: {MinimumDamage}-{MaximumDamage}";
        }
        #endregion
    }
}
