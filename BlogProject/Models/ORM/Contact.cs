using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models.ORM
{
    public class Contact : BaseEntity
    {
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
