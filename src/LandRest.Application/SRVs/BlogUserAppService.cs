using System;
using LandRest.Blogs;
using LandRest.DTOs.BlogUser;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace LandRest.SRVs;

public class BlogUserAppService : CrudAppService<
BlogUser,
BlogUserDto,
Guid,
PagedAndSortedResultRequestDto,
CreateUpdateBlogUserDto>, IServiceBlogUser
{
    public BlogUserAppService(IRepository<BlogUser, Guid> repository) : base(repository)
    {
    }
}