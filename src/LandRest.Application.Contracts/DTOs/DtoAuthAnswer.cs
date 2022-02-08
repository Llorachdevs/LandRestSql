using System;
using Volo.Abp.Application.Dtos;

namespace LandRest.DTOs
{
    public class DtoAuthAnswer: AuditedEntityDto<Guid>
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}