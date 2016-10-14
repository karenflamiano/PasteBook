using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Entities
{
    public class Like
    {
        public int L_ID { get; set; }
        public int L_PostID { get; set; }
        public int L_LikedBy { get; set; }
    }
}
