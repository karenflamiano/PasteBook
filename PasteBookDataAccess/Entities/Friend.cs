using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Entities
{
    public class Friend
    {
        public int F_ID { get; set; }
        public int F_UserID { get; set; }
        public int F_FriendID { get; set; }
        public char F_Request { get; set; }
        public char F_Blocked { get; set; }
        public DateTime F_CreatedDate { get; set; }
    }
}
