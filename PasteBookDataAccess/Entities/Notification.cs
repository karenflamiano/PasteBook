using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Entities
{
    public class Notification
    {
        public int N_ReceiverID { get; set; }
        public char N_NotifType { get; set; }
        public int N_SenderID { get; set; }
        public DateTime N_CreatedDate { get; set; }
        public int N_CommentID { get; set; }
        public int N_PostID { get; set; }
        public int N_ID { get; set; }
        public string Seen { get; set; }
    }
}
