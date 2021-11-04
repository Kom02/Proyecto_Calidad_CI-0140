using EmprendeUCR.Domain.Core.Entities;
using EmprendeUCR.Domain.Core.ValueObjects;
using EmprendeUCR.Domain.Chats.Entities;
//agregar el path para USER para extraer los emails
using System.ComponentModel.DataAnnotations;
using System;


namespace EmprendeUCR.Domain.Chats.Entities
{
    public partial class Message
    {
        public Chat Chat;
        [Key]
        public int Chat_ID { get; private set; }
        [Key]
        public DateTimeOffset? Message_Date { get; private set; }
        public string? Writer_User_Email { get; private set; }
        public string? Reader_User_Email { get; private set; }
        public string? Content { get; private set; }
        public int Seen { get; private set; }

        public Message(int chatID, string writerUserEmail, string readerUserEmail, string content)
        {
            Chat_ID = chatID;
            Message_Date = DateTimeOffset.Now;
            Writer_User_Email = writerUserEmail;
            Reader_User_Email = readerUserEmail;
            Content = content;
            Seen = 0;
        }
        public Message()
        {
            Chat_ID = 0;
            Message_Date = null;
            Writer_User_Email = null;
            Reader_User_Email = null;
            Content = null;
            Seen = 0;
        }
        public void AssignChat(Chat chat)
        {
            Chat = chat;
        }
    }
}
