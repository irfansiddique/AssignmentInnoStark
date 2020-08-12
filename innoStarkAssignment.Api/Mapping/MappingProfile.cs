using AutoMapper;
using innoStarkAssignment.Api.Resources;
using innoStarkAssignment.Core.Model;

namespace innoStarkAssignment.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Blog, BlogResource>();
            CreateMap<Category, CategoryResource>();

            // Resource to Domain
            CreateMap<BlogResource, Blog>();
            CreateMap<CategoryResource, Category>();

            CreateMap<SaveBlogResource, Blog>();
            CreateMap<SaveCategoryResource, Category>();
        }
    }
}
