using System;
using LandRest.DTOs.BlogUser;
using Volo.Abp.Application.Dtos;

namespace LandRest.DTOs.BlogSession
{
    public class DtoBlogSession: AuditedEntityDto<Guid>
    {
        public BlogUserDto User { get; set; }
        public DateTime Date { get; set; }

    }
}