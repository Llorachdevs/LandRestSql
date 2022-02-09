using System;
using System.Collections.Generic;
using LandRest.DTOs.AppUser;
using LandRest.DTOs.Comment;
using Volo.Abp.Application.Dtos;

namespace LandRest.DTOs.BlogArticle
{
    public class ArticleDto: AuditedEntityDto<Guid>
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
        public List<CommentDto> Comments { get; set; }
        public AppUserDto User { get; set; }


        public ArticleDto()
        {
            Comments = new List<CommentDto>();
        }
    }
    
    
}