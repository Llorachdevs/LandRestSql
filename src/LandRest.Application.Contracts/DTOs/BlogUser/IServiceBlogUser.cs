using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LandRest.DTOs.BlogUser;

public interface IServiceBlogUser: ICrudAppService< 
    BlogUserDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateUpdateBlogUserDto>
{
    
}