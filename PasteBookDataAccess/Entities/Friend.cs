﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Entities
{
    public class Friend
    {
        public int ID { get; set; }
        public int FRIEND_ID { get; set; }
        public int USER_ID { get; set; }
        public char REQUEST { get; set; }
        public char BLOCKED { get; set; }
        public DateTime CREATED_DATE { get; set; }
    }
}
