using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarRealmsCore.Models.Cards;

namespace StarRealmsCore.Models.Decks
{
    public class DeckViewModel
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public int Type { get; set; }
        public ICollection<CardViewModel> Cards { get; set; }
    }
}
