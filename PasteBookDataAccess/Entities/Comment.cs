using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Entities
{
   public class Comment
    {
        public int ID { get; set; }
        public int POST_ID { get; set; }
        public int POSTER_ID { get; set; }
        public string CONTENT { get; set; }
        public DateTime DATE_CREATED { get; set; }

    }
}
