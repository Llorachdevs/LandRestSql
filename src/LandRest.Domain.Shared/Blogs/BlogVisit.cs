using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace LandRest.Blogs
{
    public class BlogVisit: AuditedAggregateRoot<Guid>, ISoftDelete
    {
        public string IpAddress { get; set; }
        public DateTime VisitDate { get; set; }

        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string VisitedResource { get; set; }
        public bool IsDeleted { get; set; }

        public BlogVisit(int blogVisitId, string ipAddress, DateTime visitDate)
        {
            IpAddress = ipAddress;
            VisitDate = visitDate;
        }

        public BlogVisit()
        {
        }


    }
}