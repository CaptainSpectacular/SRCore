using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarRealmsCore.Data
{
    public class TradeCard
    {
        public int Id { get; set; }
        public int TradeRowId { get; set; }
        public TradeRow TradeRow { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}
