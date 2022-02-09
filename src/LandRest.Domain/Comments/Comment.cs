using System;
using LandRest.Articles;
using LandRest.Blogs;
using LandRest.Users;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace LandRest.Comments
{
    public class Comment: AuditedAggregateRoot<Guid>, ISoftDelete
    {
        public string UserEmail { get; set; }
        public DateTime Published { get; set; }
        
        public Guid UserId { get; set; }
        
        public  AppUser User { get; set; }
        
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
        
        public string Text { get; set; }
        
        public string IpAddress { get; set; }
        
        public bool IsDeleted { get; set; }

        public Comment(DateTime pId,string pText, DateTime pPublished)
        {
            Text = pText;
            Published = pPublished;
        }

        public Comment()
        {
        }


    }
}