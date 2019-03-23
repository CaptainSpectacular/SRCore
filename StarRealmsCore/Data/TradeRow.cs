using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarRealmsCore.Data
{
    public class TradeRow
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public ICollection<TradeCard> TradeCards { get; set; }
    }
}
