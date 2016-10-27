using PasteBookDataAccess;
using PasteBookDataAccess.Manager;
using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookBusinessLogic
{
    public class BLCommentManager
    {
        CommentManager finalComment = new CommentManager();
        NotificationManager notificationManager = new NotificationManager();

        public int AddComment(COMMENT comment)
        {
            int result = 0;
            result = finalComment.AddCommentToDB(comment);
            return result;
        }

        public List<COMMENT> ListOfComments(int ID)
        {
            return finalComment.ListOfComment(ID);
        }

    }
}
