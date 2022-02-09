using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using LandRest.Blogs;
using LandRest.Comments;
using LandRest.DTOs.BlogArticle;
using LandRest.DTOs.BlogArticleComment;
using LandRest.DTOs.Comment;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace LandRest.SRVs;

public class CommentsAppService: CrudAppService<
Comment,
CommentDto,
Guid,
PagedAndSortedResultRequestDto,
CreateUpdateCommentDto
>, IServiceBlogArticleComment
{
    public CommentsAppService(IRepository<Comment, Guid> repository) : base(repository)
    {

    }
    
    public async Task<List<CommentDto>> GetCommentsByArticleId(Guid articleId)
    {
        List<CommentDto> result = null;
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