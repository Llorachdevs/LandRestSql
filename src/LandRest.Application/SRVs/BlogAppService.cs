using System;
using System.Linq;
using System.Threading.Tasks;
using LandRest.Blogs;
using LandRest.DTOs.Blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace LandRest.SRVs;

public class BlogAppService : CrudAppService<
Blog,
BlogDto,
Guid,
PagedAndSortedResultRequestDto,
CreateUpdateBlogDto
>, IServiceBlog
{
    public BlogAppService(IRepository<Blog, Guid> repository) : base(repository)
    {
    }

    [HttpGet]
    public async Task<BlogDto> GetBlogByLink(string blogLink)
    {
        BlogDto result = null;
        if (!string.IsNullOrWhiteSpace(blogLink))
        {
            Blog blog = await Repository.GetAsync(e => e.SiteLink == blogLink);
            if (blog != null)
            {
                result = await this.MapToGetOutputDtoAsync(blog);
            }
        }

        return result;
    }
}