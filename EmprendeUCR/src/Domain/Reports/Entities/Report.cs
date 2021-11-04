using System.ComponentModel.DataAnnotations;
using EmprendeUCR.Domain.Core.ValueObjects;

namespace EmprendeUCR.Domain.Reports.Entities
{
    public class Report
    {
        [Key]
        /**
        * @brief setter and getter of the Primary Key of Report
        */
        public int ID { get; set; }
        /**
        * @brief setter and getter of the Title of the Report
        */
        public string Title { get; set; }
        /**
        * @brief setter and getter of the description of a Report
        */
        public string Content { get; set; }

        public string User { get; set; }

        public Report(string title,string content,string user,int id){
            Title=title;
            Content=content;
            User=user;
            ID=id;
        }
        public Report()
        {
            ID=0;
            Title=null;
            Content=null;
            User = null;
        }
        public void ChangeContent(string content){
            Content = content;
        }
        public void ChangeTitle(string title){
            Title=title;
        }
        public void SetUser(string user){
            User=user;
        }
    }
}
