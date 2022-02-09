using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LandRest.Articles;
using LandRest.Blogs;
using LandRest.Comments;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Users;

namespace LandRest.Users;

public class AppUser : FullAuditedAggregateRoot<Guid>, IUser
{
    #region Base properties

    /* These properties are shared with the IdentityUser entity of the Identity module.
     * Do not change these properties through this class. Instead, use Identity module
     * services (like IdentityUserManager) to change them.
     * So, this properties are designed as read only!
     */
    public Guid? TenantId { get; }
    public string UserName { get; }
    public string Email { get; }
    public string Name { get; }
    public string Surname { get; }
    public bool EmailConfirmed { get; }
    public string PhoneNumber { get; }
    public bool PhoneNumberConfirmed { get; }

    #endregion

    #region Custom properties

    public string SecondName { get; set; }

    public string SecondSurname { get; set; }

    public string SiteLink { get; set; }
    
    public string CvLink { get; set; }
    
    public Guid BlogId { get; set; }
    public Blog Blog { get; set; }
    
    public List<Article> Articles { get; set; }
        
    public List<Comment> Comments { get; set; }

    #endregion
}