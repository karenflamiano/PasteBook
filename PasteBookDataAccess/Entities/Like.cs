using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Entities
{
    public class Like
    {
        public int ID { get; set; }
        public int POST_ID { get; set; }
        public int LIKED_BY { get; set; }
    }
}
