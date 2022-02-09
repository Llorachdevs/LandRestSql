using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace LandRest.Blogs
{
    public class BlogArticleComment: AuditedAggregateRoot<Guid>, ISoftDelete
    {
        public string UserEmail { get; set; }
        public DateTime Published { get; set; }
        
        public Guid UserId { get; set; }
        
        public  BlogUser User { get; set; }
        
        public Guid ArticleId { get; set; }
        public BlogArticle Article { get; set; }
        
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