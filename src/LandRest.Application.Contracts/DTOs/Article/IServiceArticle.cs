using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LandRest.DTOs.BlogArticle;

public interface IServiceArticle:
    ICrudAppService<
        ArticleDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateArticleDto>
{
    
}