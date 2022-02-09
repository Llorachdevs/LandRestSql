using System;
using Volo.Abp.Identity;

namespace LandRest.DTOs.AppUser;

public class AppUserDto : IdentityUserDto
{
    public string SecondName { get; set; }

    public string SecondSurname { get; set; }

    public string SiteLink { get; set; }
    
    public string CvLink { get; set; }
    
    public Guid BlogId { get; set; }
}