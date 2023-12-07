namespace OOP_Project
{
    public class User
    {
        public List<Recipe> Recipes { get; set; }

        public User()
        {
            Recipes = new List<Recipe>();
        }

        public void CreateRecipe()
        {
            Console.Write("Введіть назву рецепту: ");
            string recipeName = Console.ReadLine();

            Console.Write("Виберіть тип кухні (0 - Italian, 1 - French, 2 - Ukrainian): ");
            CuisineType cuisine = (CuisineType)Enum.Parse(typeof(CuisineType), Console.ReadLine());

            List<Ingredient> ingredients = new List<Ingredient>();
            Console.Write("Скільки інгредієнтів ви хочете додати до рецепту? ");
            int ingredientCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < ingredientCount; i++)
            {
                Console.Write("Введіть назву інгредієнта: ");
                string ingredientName = Console.ReadLine();
                Console.Write("Введіть кількість інгредієнта: ");
                int ingredientQuantity = int.Parse(Console.ReadLine());
                Ingredient ingredient = new Ingredient { Name = ingredientName, Quantity = ingredientQuantity };
                ingredients.Add(ingredient);
            }

            List<string> instructions = new List<string>();
            Console.Write("Скільки кроків ви хочете додати до інструкцій? ");
            int instructionCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < instructionCount; i++)
            {
                Console.Write($"Введіть крок {i + 1} інструкції: ");
                string instruction = Console.ReadLine();
                instructions.Add(instruction);
            }

            var newRecipe = new Recipe
            {
                Cuisine = cuisine,
                Ingredients = ingredients,
                Instructions = instructions
            };

            
            Recipes.Add(newRecipe);

            Console.WriteLine($"Рецепт '{recipeName}' було успішно додано.");
        }



        public List<Recipe> GetRecipes()
            {

                return Recipes;
            }
        }
}
