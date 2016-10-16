using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Entities
{
    public class Notification
    {
        public int RECEIVER_ID { get; set; }
        public char NOTIF_TYPE { get; set; }
        public int SENDER_ID { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public int COMMENT_ID { get; set; }
        public int POST_ID { get; set; }
        public int ID { get; set; }
        public string SEEN { get; set; }
    }
}
