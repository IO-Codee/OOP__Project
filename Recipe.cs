using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum CuisineType
{
    Italian,
    French,
    Ukrainian
}

namespace OOP_Project
{
    public class Recipe : IRecipe
    {
        public CuisineType Cuisine { get; set; }
        public List<string> Instructions { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Instructions = new List<string>();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }

        public void RemoveIngredient(Ingredient ingredient)
        {
            Ingredients.Remove(ingredient);
        }


        public void ChangeRecipe(List<string> newInstructions)
        {
            Instructions = newInstructions;
        }

        // Повертає рецепт
        public List<string> GetRecipe()
        {
            return Instructions;
        }
    }
}
