using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model.DTO
{
    public class BasicCategory
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }
    }
}
