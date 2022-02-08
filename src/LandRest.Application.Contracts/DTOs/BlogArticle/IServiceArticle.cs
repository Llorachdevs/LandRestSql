using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LandRest.DTOs.BlogArticle;

public interface IServiceArticle:
    ICrudAppService<
        BlogArticleDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateBlogArticleDto>
{
    
}