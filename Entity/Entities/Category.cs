using Core.Entities;

namespace Entity.Entities;

public class Category : EntityBase
{
    public string Name { get; set; }
    public ICollection<Article> Articles { get; set; }
}

