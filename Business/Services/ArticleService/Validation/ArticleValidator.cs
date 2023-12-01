using Entity.Entities;
using FluentValidation;

namespace Business.Services.ArticleService.Validation;
public class ArticleValidator : AbstractValidator<Article>
{
    public ArticleValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3)
            .MaximumLength(150)
            .WithName("Başlık");

        RuleFor(x => x.Content)
            .NotEmpty()
            .NotNull()
            .WithName("İçerik");
    }
}
