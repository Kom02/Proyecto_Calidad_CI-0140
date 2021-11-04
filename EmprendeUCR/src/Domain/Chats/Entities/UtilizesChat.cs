using EmprendeUCR.Domain.Core.Entities;
using EmprendeUCR.Domain.Core.ValueObjects;
using EmprendeUCR.Domain.Chats.Entities;
//agregar el path para USER para extraer los emails
using System.ComponentModel.DataAnnotations;


namespace EmprendeUCR.Domain.Chats.Entities
{
    public partial class UtilizesChat
    {
        public Chat Chat;
        [Key]
        public int Chat_ID { get; private set; }
        [Key]
        public string? User_Email { get; private set; }
        public UtilizesChat(int chatID, string userEmail)
        {
            Chat_ID = chatID;
            User_Email = userEmail;
        }
        public UtilizesChat()
        {
            Chat_ID = 0;
            User_Email = null;
        }
        public void AssignChat(Chat chat)
        {
            Chat = chat;
        }
    }
}
