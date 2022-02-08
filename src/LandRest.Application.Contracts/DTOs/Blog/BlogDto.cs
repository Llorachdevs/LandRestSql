using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LandRest.DTOs.BlogUser;
using Volo.Abp.Application.Dtos;

namespace LandRest.DTOs.Blog
{
    public class BlogDto: AuditedEntityDto<Guid>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SiteLink { get; set; }
        public string Secret { get; set; }
        public List<BlogUserDto> BlogUsers { get; set; }
    }
}