namespace EmprendeUCR.Domain.Core.CoreEntities
{
    public class Canton
    {
        public string Name { get; set; }
        public string Province_Name { get; set; }

        public Canton(string name, string province)
        {
            Name = name;
            Province_Name = province;
        }

        public Canton() { 
        }
    }
}
