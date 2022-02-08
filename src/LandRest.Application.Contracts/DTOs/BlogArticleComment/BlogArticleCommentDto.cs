using System;
using Volo.Abp.Application.Dtos;

namespace LandRest.DTOs.BlogArticleComment
{
    public class BlogArticleCommentDto: AuditedEntityDto<Guid>
    {
        //public int Article_Id { get; set; }
        //public DTO_Blog_Article Article { get; set; }
        public string Comment { get; set; }
        public DateTime Published { get; set; }
        public string IpAddress { get; set; }
    }
}