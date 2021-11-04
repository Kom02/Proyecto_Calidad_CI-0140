using EmprendeUCR.Domain.Core.Entities;
using EmprendeUCR.Domain.Core.ValueObjects;
using System.ComponentModel.DataAnnotations;


namespace EmprendeUCR.Domain.Chats.Entities
{
    public partial class Chat
    {
        [Key]
        public int ID { get; private set; }

        public Chat(int id)
        {
            ID = id;
        }
        public Chat()
        {
            ID = 0;
        }
    }
}