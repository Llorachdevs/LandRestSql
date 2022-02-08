using System;
using Volo.Abp.Application.Dtos;

namespace LandRest.DTOs.BlogVisit;

public class CreateBlogVisitDto : EntityDto<Guid>
{
    public string IpAddr { get; set; }
    public DateTime VisitDate { get; set; }

    public string Country { get; set; }
    public string CountryCode { get; set; }
    public string VisitedResource { get; set; }
}