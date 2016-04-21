using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Entities
{
    public enum CuisineType
    {
        None,
        Italian,
        Frensh,
        Greek
    }

    public class Restaurant
    {
        public int Id { get; set; }

        [Display(Name = "Restaraunt Name"),Required,MaxLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
