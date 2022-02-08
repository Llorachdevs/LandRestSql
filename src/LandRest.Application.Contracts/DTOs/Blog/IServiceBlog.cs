using System;
using LandRest.DTOs.Blog;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LandRest.DTOs.Blog;

public interface IServiceBlog:
    ICrudAppService<
        BlogDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateBlogDto>
{
    
}