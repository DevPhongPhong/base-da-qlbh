using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.FromCustomer
{
    public class FromCustomerService : IFromCustomerService
    {
        private readonly CMS_DBContext context;
        public FromCustomerService(CMS_DBContext _context)
        {
            this.context = _context;
        }

        public IEnumerable<Feedback> GetFeedbacks()
        {
            try
            {
                var objs = context.Feedbacks;
                return objs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }    
        public IEnumerable<Feedback> GetMessages()
        {
            try
            {
                var objs = context.Feedbacks.Where(x => x.Type == 1);
                if (objs != null) return objs;
                else throw new Exception("Không tìm thấy ID!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Feedback> GetProductComments()
        {
            try
            {
                var objs = context.Feedbacks.Where(x => x.Type == 2);
                if (objs != null) return objs;
                else throw new Exception("Không tìm thấy ID!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Feedback> GetNewsComments()
        {
            try
            {
                var objs = context.Feedbacks.Where(x => x.Type == 3);
                if (objs != null) return objs;
                else throw new Exception("Không tìm thấy ID!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<SubscribeEmail> GetSubscribeEmails()
        {
            try
            {
                var objs = context.SubscribeEmails;
                if (objs != null) return objs;
                else throw new Exception("Không tìm thấy ID!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Feedback GetFeedback(int ID)
        {
            try
            {
                var obj = context.Feedbacks.Find(ID);
                if (obj != null) return obj;
                else throw new Exception("Không tìm thấy ID!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddFeedback(Feedback feedback)
        {
            try
            {
                var sub = new SubscribeEmail { Email = feedback.Email , CreateDate = DateTime.Now};
                var addEmail = AddSubscribeEmail(sub);

                if(feedback.Avatar==null || feedback.Avatar.Length<=0) feedback.Avatar = "Upload/user-avatar.png";

                context.Feedbacks.Add(feedback);
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ChangeStatusFeedback(int ID)
        {
            try
            {
                var obj = context.Feedbacks.Find(ID);
                if (obj != null)
                {
                    bool oldstatus = obj.Status;
                    obj.Status = !oldstatus;
                    return context.SaveChanges() > 0;
                }
                else throw new Exception("Không tìm thấy ID!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ChangeShowOnHomeFeedback(int ID)
        {
            try
            {
                var obj = context.Feedbacks.Find(ID);
                if (obj != null)
                {
                    bool showOnHome = obj.ShowOnHome;
                    obj.ShowOnHome = !showOnHome;
                    return context.SaveChanges() > 0;
                }
                else throw new Exception("Không tìm thấy ID!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteFeedBack(int ID)
        {
            try
            {
                var obj = context.Feedbacks.Find(ID);
                if (obj != null)
                {
                    context.Feedbacks.Remove(obj);
                    return context.SaveChanges() > 0;
                }
                else throw new Exception("Không tìm thấy ID!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddSubscribeEmail(SubscribeEmail subscribeEmail)
        {
            try
            {
                var objs = context.SubscribeEmails.Where(x => x.Email == subscribeEmail.Email).ToList();
                if (objs.Count > 0) return true;
                context.SubscribeEmails.Add(subscribeEmail);
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteSubscribeEmail(int ID)
        {
            try
            {
                var obj = context.SubscribeEmails.Find(ID);
                if (obj != null)
                {
                    context.SubscribeEmails.Remove(obj);
                    return context.SaveChanges() > 0;
                }
                else throw new Exception("Không tìm thấy ID!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
