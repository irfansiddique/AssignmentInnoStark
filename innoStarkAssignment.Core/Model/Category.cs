using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace innoStarkAssignment.Core.Model
{
    public class Category
    {
        public Category()
        {
            Blogs = new Collection<Blog>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}
