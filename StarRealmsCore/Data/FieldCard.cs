using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarRealmsCore.Data
{
    public class FieldCard
    {
        public int FieldId { get; set; }
        public Field Field { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}
