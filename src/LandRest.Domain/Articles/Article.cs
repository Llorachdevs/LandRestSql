using System;
using System.Collections.Generic;
using LandRest.Users;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace LandRest.Blogs
{
    public class Article: AuditedAggregateRoot<Guid>, ISoftDelete
    {
        public string ArticleLink { get; set; }
        public DateTime PublishDate { get; set; }
        public string Tittle { get; set; }
        public string Image { get; set; }
        public int Likes { get; set; }
        public int VisitCount { get; set; }
        
        public bool IsDeleted { get; set; }

        public string UserEmail { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        
        public List<BlogArticleComment> Comments { get; set; }
        
        public Article( string pArticleLink, string pImage, AppUser pUser)
        {
            Image = pImage;
            ArticleLink = pArticleLink;
            Likes = 0;
            VisitCount = 0;
            User = pUser;
            Comments = new List<BlogArticleComment>();
        }

        public Article()
        {
            Comments = new List<BlogArticleComment>();
        }
        
        public Article( string pArticleLink, string pImage, AppUser pUser, string pTittle)
        {
            Image = pImage;
            ArticleLink = pArticleLink;
            Likes = 0;
            VisitCount = 0;
            User = pUser;
            Tittle = pTittle;
            Comments = new List<BlogArticleComment>();
        }
    }
}