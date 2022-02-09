using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace LandRest.Blogs
{
    public class Blog: AuditedAggregateRoot<Guid>, ISoftDelete
    {
        public string SiteLink { get; set; }
        public string Name { get; set; }
        public string Secret { get; set; }
        
        public bool IsDeleted { get; set; }
        
        public List<BlogUser> Users { get; set; }

        public Blog( string pName, string pSiteLink)
        {
            SiteLink = pSiteLink;
            Name = pName;
            Users = new List<BlogUser>();
        }

        public Blog()
        {
            Users = new List<BlogUser>();
        }

        public Blog(string link)
        {
            SiteLink = link;
            Users = new List<BlogUser>();
        }

    }
}