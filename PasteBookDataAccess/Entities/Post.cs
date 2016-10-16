using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Entities
{
    public class Post
    {
        public int ID { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string CONTENT { get; set; }
        public int PROFILE_OWNER_ID { get; set; }
        public int POSTER_ID { get; set; }
    }
}
