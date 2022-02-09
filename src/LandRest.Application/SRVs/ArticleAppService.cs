using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LandRest.Articles;
using LandRest.Blogs;
using LandRest.DTOs.BlogArticle;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace LandRest.SRVs;

public class ArticleAppService : CrudAppService<
    Article,
    BlogArticleDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateUpdateBlogArticleDto>, IServiceArticle
{
    public ArticleAppService(IRepository<Article, Guid> repository) : base(repository)
    {
        /*async Task<ActionResult<List<BlogArticle>>> GetArticlesByLala()
        {
            return new OkObjectResult(new List<BlogArticle>());
        }*/
    }
    
    [HttpGet]
    public async Task<IEnumerable<BlogArticleDto>> GetArticlesFromUser([FromHeader]string userEmail)
    {
        var queryable = await Repository.WithDetailsAsync(e => e.User.Email == userEmail);
        List<Article> blogArticles = queryable.ToList();
        return await this.MapToGetListOutputDtosAsync(blogArticles);
    }
    
    
}

