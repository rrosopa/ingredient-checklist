using System.Collections.Generic;

namespace Data.Entities
{
	public class Recipe : BaseEntity
	{
		public string Name { get; set; }
		public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
