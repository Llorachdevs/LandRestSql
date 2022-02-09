using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using LandRest.Blogs;
using LandRest.Comments;
using LandRest.DTOs.BlogArticle;
using LandRest.DTOs.BlogArticleComment;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace LandRest.SRVs;

public class ArticleCommentAppService: CrudAppService<
Comment,
BlogArticleCommentDto,
Guid,
PagedAndSortedResultRequestDto,
CreateUpdateBlogArticleCommentDto
>, IServiceBlogArticleComment
{
    public ArticleCommentAppService(IRepository<Comment, Guid> repository) : base(repository)
    {

    }
    
    public async Task<List<BlogArticleCommentDto>> GetCommentsByArticleId(Guid articleId)
    {
        List<BlogArticleCommentDto> result = null;
        if (articleId != Guid.Empty)
        {
            List<Comment> comments = await Repository.GetListAsync(e => e.ArticleId == articleId);
            if (comments != null)
            {
                result = await this.MapToGetListOutputDtosAsync(comments);                
            }
        }

        return result;
    }
}