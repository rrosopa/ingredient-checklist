namespace Data.Entities
{
	public class Ingredient : BaseEntity
    {
		public string Name { get; set; }
		public int RecipeId { get; set; }
		public bool IsChecked { get; set; }
    }
}
