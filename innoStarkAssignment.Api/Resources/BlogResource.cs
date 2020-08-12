using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace innoStarkAssignment.Api.Resources
{
    public class BlogResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryResource Category { get; set; }
    }
}
