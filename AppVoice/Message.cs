using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppVoice
{
    public class Message
    {
        private string messageFrom, messageTo, messageText;
        private bool isRead;
        private int messageId;

        public Message(int messageId, string messageFrom, string messageTo, string messageText, bool isRead)
        {
            this.messageId = messageId;
            this.messageFrom = messageFrom;
            this.messageTo = messageTo;
            this.messageText = messageText;
            this.isRead = isRead;
        }


        public int MessageId
        {
            set
            {
                messageId = value;
            }
            get
            {
                return messageId;
            }
        }
        public string MessageFrom
        {
            set
            {
                messageFrom = value;
            }
            get
            {
                return messageFrom;
            }
        }
        public string MessageTo
        {
            set
            {
                messageTo = value;
            }
            get
            {
                return messageTo;
            }
        }
        public string MessageText
        {
            set
            {
                messageText = value;
            }
            get
            {
                return messageText;
            }
        }
        public bool IsRead
        {
            set
            {
                isRead = value;
            }
            get
            {
                return isRead;
            }
        }
    }
}