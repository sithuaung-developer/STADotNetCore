using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STADotNetCore.ConsoleApp.Dtos
{
    [Table("Tbl_Blog")] // mapping class and Table (BlogDto mapping Tbl_Blog)
    public class BlogDto
    {
        [Key] //primay key declare
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
    }
    //public record BlogEntity(int BlogId, string BlogTitle, string BlogAuthor, string BlogContent);
}
