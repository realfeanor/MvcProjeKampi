using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox();
        List<Message> GetListSendbox();
        List<Message> GetListDrafts();
        int GetUnreadMessagesInbox();
        void MessageAddBL(Message message);
        Message GetByID(int id);
        void MessageDeleteBL(Message message);
        void MessageUpdateBL(Message message);
    }
}
