using System;
using LandRest.Users;
using Microsoft.AspNetCore.Identity;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace LandRest.Blogs
{
    public class BlogArticleComment: AuditedAggregateRoot<Guid>, ISoftDelete
    {
        public string UserEmail { get; set; }
        public DateTime Published { get; set; }
        
        public Guid UserId { get; set; }
        
        public  AppUser User { get; set; }
        
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
        
        public string Comment { get; set; }
        
        public string IpAddress { get; set; }
        
        public bool IsDeleted { get; set; }

        public BlogArticleComment(DateTime pId,string pComment, DateTime pPublished)
        {
            Comment = pComment;
            Published = pPublished;
        }

        public BlogArticleComment()
        {
        }


    }
}