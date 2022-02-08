using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace LandRest.Blogs;

public class BlogUser: AuditedAggregateRoot<Guid>
{
    public IdentityUser IdentityUser { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string FirstLastName { get; set; }
    public string SecondLastName { get; set; }
    public string UserName { get; set; }
    public DateTime BornDate { get; set; }
    public string PasswordHash { get; set; }
    public string PhoneNumber { get; set; }
    public int AccessFailedCount { get; set; }

    public string SiteLink { get; set; }
    public Blog Blog { get; set; }

    public string CvLink { get; set; }
        
    public int RoleId { get; set; }

    public List<BlogArticle> Articles { get; set; }
        
    public List<BlogArticleComment> Comments { get; set; }
    

    public BlogUser( string firstName, string secondName, string firstLastName, string secondLastName, string userName, string email, DateTime bornDate, string passwordHash, string phoneNumber, Blog blog)
    {
        FirstName = firstName;
        SecondName = secondName;
        FirstLastName = firstLastName;
        SecondLastName = secondLastName;
        UserName = userName;
        Email = email;
        BornDate = bornDate;
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(passwordHash);
        PhoneNumber = phoneNumber;
        AccessFailedCount = 0;
        Blog = blog;
        Articles = new List<BlogArticle>();
    }

    public BlogUser()
    {
    }
}