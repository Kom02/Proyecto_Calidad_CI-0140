namespace EmprendeUCR.Domain.Core.CoreEntities
{
    public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? ParentId { get; set; }

        public string Description { get; set; }

    }
}
