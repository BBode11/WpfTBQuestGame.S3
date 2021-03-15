using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class GameItem
    {
        #region PROPERTIES
        //
        //auto implemented properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UseMessage { get; set; }

        public string Information
        {
            get
            {
                return InformationString();
            }
        }
        #endregion
        #region CONSTRUCTORS
        /// <summary>
        /// Constructor for GameItem 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="useMessage"></param>
        public GameItem(int id, string name, string description, string useMessage = "")
        {
            Id = id;
            Name = name;
            Description = description;
            UseMessage = useMessage;
        }
        #endregion
        #region METHODS
        public virtual string InformationString()
        {
            return $"{Name}: {Description}";
        }
        #endregion
    }
}
