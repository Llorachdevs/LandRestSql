using System;
using Volo.Abp.Application.Dtos;

namespace LandRest.DTOs.BlogArticle;

public class CreateUpdateArticleDto: EntityDto<Guid>
{
    public string ArticleLink { get; set; }
    public DateTime PublishDate { get; set; }
    public string Tittle { get; set; }
    public string Image { get; set; }
    public int Likes { get; set; }
    public int VisitCount { get;set; }
}