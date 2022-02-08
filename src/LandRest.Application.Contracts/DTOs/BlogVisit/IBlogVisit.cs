using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LandRest.DTOs.BlogVisit;

public interface IBlogVisit: ICrudAppService< 
    BlogVisitDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateBlogVisitDto>
{
    
}