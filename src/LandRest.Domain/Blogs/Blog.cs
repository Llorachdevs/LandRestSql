using System;
using System.Collections.Generic;
using LandRest.Users;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace LandRest.Blogs
{
    public class Blog: AuditedAggregateRoot<Guid>, ISoftDelete
    {
        public string SiteLink { get; set; }
        public string Name { get; set; }
        public string Secret { get; set; }
        
        public bool IsDeleted { get; set; }
        
        public List<AppUser> Users { get; set; }

        public Blog( string pName, string pSiteLink)
        {
            SiteLink = pSiteLink;
            Name = pName;
            Users = new List<AppUser>();
        }

        public Blog()
        {
            Users = new List<AppUser>();
        }

        public Blog(string link)
        {
            SiteLink = link;
            Users = new List<AppUser>();
        }

    }
}