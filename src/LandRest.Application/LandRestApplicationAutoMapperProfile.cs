using AutoMapper;
using LandRest.Blogs;
using LandRest.DTOs.Blog;
using LandRest.DTOs.BlogArticle;
using LandRest.DTOs.BlogArticleComment;
using LandRest.DTOs.BlogVisit;

namespace LandRest
{
    public class LandRestApplicationAutoMapperProfile : Profile
    {
        public LandRestApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            
            CreateMap<BlogArticleDto, BlogArticle>();
            CreateMap<BlogArticle, BlogArticleDto>();

            CreateMap<BlogDto, Blog>();
            CreateMap<Blog, BlogDto>();

            CreateMap<BlogArticleCommentDto, BlogArticleComment>();
            CreateMap<BlogArticleComment, BlogArticleCommentDto>();

            CreateMap<BlogVisitDto, BlogVisit>();
            CreateMap<BlogVisit, BlogVisitDto>();
        }
    }
}
