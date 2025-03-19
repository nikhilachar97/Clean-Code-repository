using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class NotificationService
    {
        INotifyingChannel myNotifyingChannel;
        public NotificationService(INotifyingChannel theNotificationChannel)
        {
            this.myNotifyingChannel = theNotificationChannel;
        }

        public void Notify()
        {   
            myNotifyingChannel.SendNotification();
        }

        public static void Main()
        {
            IContent aContent = new EmailContent("New Notification");
            INotifyingChannel aNotifyingChannel = new Email(aContent);
       
            NotificationService aNotificationService = new NotificationService(aNotifyingChannel);
            aNotificationService.Notify();
        }
    }

    public interface INotifyingChannel
    {
        void SendNotification();
    }

    public class Email : INotifyingChannel
    {
        IContent myContent;
        public Email(IContent thecontent) 
        {
            this.myContent = thecontent;
        }
        public void SendNotification()
        {
            //Notify myContent
        }
    }

    public class Push : INotifyingChannel
    {
        IContent myContent;
        public Push(IContent thecontent)
        {
            this.myContent = thecontent;
        }
        public void SendNotification()
        {
            //Notify myContent
        }
    }

    public class SMS : INotifyingChannel
    {
        IContent myContent;
        public SMS(IContent thecontent)
        {
            this.myContent = thecontent;
        }
        public void SendNotification()
        {
            //Notify myContent
        }
    }

    public class EmailContent : IContent
    {
        public EmailContent(string theMessage)
        {
            this.Message = theMessage;
        }

        public string Message { get; set; }
    }

    public class SMSContent : IContent
    {
        public SMSContent(string theMessage)
        {
            this.Message = theMessage;
        }

        public string Message { get; set; }
    }

    public class PushContent : IContent
    {
        public PushContent(string theMessage)
        {
            this.Message = theMessage;
        }

        public string Message { get; set; }
    }
    public interface IContent
    {
        public string Message { get; set; }
    }
}



