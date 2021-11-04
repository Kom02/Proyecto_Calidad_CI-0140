namespace EmprendeUCR.Domain.Core.CoreEntities
{
    public class Likes
    {
        public string Members_Email { get; set; }
        public int Category_Id { get; set; }

        public Likes(string memberEmail, int categoryId)
        {
            Members_Email = memberEmail;
            Category_Id = categoryId;
        }

        public Likes()
        {
            Category_Id = int.MinValue;
        }
    }

}
