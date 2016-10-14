using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Entities
{
   public class Comment
    {
        public int C_ID { get; set; }
        public int C_PostID { get; set; }
        public int C_PosterID { get; set; }
        public string C_Content { get; set; }
        public DateTime C_DateCreated { get; set; }

    }
}
