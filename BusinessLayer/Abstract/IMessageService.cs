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
        void MessageAddBL(Message message);
        Category GetByID(int id);
        void MessageDeleteBL(Message message);
        void MessageUpdateBL(Message message);
    }
}
