using System;
using System.Collections.Generic;
using LandRest.DTOs.BlogArticleComment;
using LandRest.DTOs.BlogUser;
using Volo.Abp.Application.Dtos;

namespace LandRest.DTOs.BlogArticle
{
    public class BlogArticleDto: AuditedEntityDto<Guid>
    {
        // public DTO_Blog_User User { get; set; }
        //public int Blog_User_ID { get; set; }
        public string ArticleLink { get; set; }
        public DateTime PublishDate { get; set; }
        public string Tittle { get; set; }
        public string Image { get; set; }
        public int Likes { get; set; }
        public int VisitCount { get;set; }
        // public List<DTO_Blog_Visit> Visits { get; set; }
        public List<BlogArticleCommentDto> Comments { get; set; }
        public BlogUserDto User { get; set; }


        public BlogArticleDto()
        {
            Comments = new List<BlogArticleCommentDto>();
        }
    }
    
    
}