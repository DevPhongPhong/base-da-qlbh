using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.FromCustomer
{
    public interface IFromCustomerService
    {
        IEnumerable<Feedback> GetFeedbacks();
        IEnumerable<Feedback> GetMessages();
        IEnumerable<Feedback> GetProductComments();
        IEnumerable<Feedback> GetNewsComments();
        IEnumerable<SubscribeEmail> GetSubscribeEmails();

        Feedback GetFeedback(int ID);

        bool AddFeedback(Feedback feedback);
        bool ChangeStatusFeedback(int ID);
        bool ChangeShowOnHomeFeedback(int ID);
        bool DeleteFeedBack(int ID);

        bool AddSubscribeEmail(SubscribeEmail subscribeEmail);
        bool DeleteSubscribeEmail(int ID);
        
    }
}
