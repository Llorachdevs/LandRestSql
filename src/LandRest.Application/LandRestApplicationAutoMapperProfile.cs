using AutoMapper;
using LandRest.Articles;
using LandRest.Blogs;
using LandRest.Comments;
using LandRest.DTOs.AppUser;
using LandRest.DTOs.Blog;
using LandRest.DTOs.BlogArticle;
using LandRest.DTOs.Comment;
using LandRest.Users;
using Volo.Abp.AutoMapper;

namespace LandRest
{
    public class LandRestApplicationAutoMapperProfile : Profile
    {
        public LandRestApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            
            CreateMap<ArticleDto, Article>();
            CreateMap<Article, ArticleDto>();

            CreateMap<BlogDto, Blog>();
            CreateMap<Blog, BlogDto>();

            CreateMap<CommentDto, Comment>();
            CreateMap<Comment, CommentDto>();
            
            CreateMap<AppUser, AppUserDto>().Ignore(x=>x.ExtraProperties);
        }
    }
}
