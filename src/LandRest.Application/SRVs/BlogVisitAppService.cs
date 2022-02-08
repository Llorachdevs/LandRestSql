using System;
using System.Threading.Tasks;
using LandRest.Blogs;
using LandRest.DTOs.BlogVisit;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace LandRest.SRVs;

public class BlogVisitAppService: CrudAppService<
BlogVisit,
BlogVisitDto,
Guid,
PagedAndSortedResultRequestDto,
CreateBlogVisitDto
>, IBlogVisit
{
    public BlogVisitAppService(IRepository<BlogVisit, Guid> repository) : base(repository)
    {
    }

    [RemoteService(false)]
    public override Task<BlogVisitDto> UpdateAsync(Guid id, CreateBlogVisitDto input)
    {
        return base.UpdateAsync(id, input);
    }
}