using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace LandRest.DTOs.BlogUser
{
    public class BlogUserDto: AuditedEntityDto<Guid>
    {

        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string BlogLink { get; set; }
        public string UserName { get; set; }
        
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        
        
        public DateTime BornDate { get; set; }
        public string PhoneNumber { get; set; }
        public int BlogUserRoleId { get; set; }
    }
}