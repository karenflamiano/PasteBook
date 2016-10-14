using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Entities
{
    public class Post
    {
        public int P_ID { get; set; }
        public DateTime P_CreatedDate { get; set; }
        public string P_Content { get; set; }
        public int P_ProfileOwnerID { get; set; }
        public int P_PosterID { get; set; }
    }
}
