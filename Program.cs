using OOP_Project;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Default;
        User user = new User();
        while (true)
        {
            Console.WriteLine("1. Отримати рецепти");
            Console.WriteLine("2. Додати рецепт");
            Console.WriteLine("3. Видалити рецепт");
            Console.WriteLine("4. Редагувати рецепт");
            Console.WriteLine("5. Вихід");
            Console.Write("Введіть номер опції: ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    DisplayRecipes(user);
                    break;
                case "2":
                    AddRecipe(user);
                    break;
                case "3":
                    DeleteRecipe(user);
                    break;
                case "4":
                    EditRecipe(user);
                    break;
                case "5":
                    // Вихід
                    return;
                default:
                    Console.WriteLine("Невідома опція. Спробуйте ще раз.");
                    break;
            }
        }
    }

    static void DisplayRecipes(User user)
    {
        if (user.Recipes.Count == 0)
        {
            Console.WriteLine("У вас немає жодного рецепту.");
            return;
        }

        Console.WriteLine("Ваші рецепти:");
        foreach (var recipe in user.Recipes)
        {
            Console.WriteLine($"Назва рецепту: {recipe.GetRecipe()[0]}");
            Console.WriteLine("Інгредієнти:");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"- {ingredient.Name}: {ingredient.Quantity}");
            }
            Console.WriteLine("Інструкції:");
            for (int i = 1; i < recipe.GetRecipe().Count; i++)
            {
                Console.WriteLine($"{i}. {recipe.GetRecipe()[i]}");
            }
            Console.WriteLine();
        }
    }

    static void AddRecipe(User user)
    {
        user.CreateRecipe();
    }

    static void DeleteRecipe(User user)
    {
        Console.Write("Введіть назву рецепту для видалення: ");
        string recipeToDelete = Console.ReadLine();
        Recipe recipeToRemove = user.Recipes.Find(r => r.GetRecipe()[0] == recipeToDelete);
        if (recipeToRemove == null)
        {
            Console.WriteLine("Рецепт не знайдено.");
            return;
        }
        user.Recipes.Remove(recipeToRemove);
        Console.WriteLine($"Рецепт '{recipeToDelete}' було успішно видалено.");
    }

    static void EditRecipe(User user)
    {
        Console.Write("Введіть назву рецепту для редагування: ");
        string recipeToEdit = Console.ReadLine();
        Recipe recipeToChange = user.Recipes.Find(r => r.GetRecipe()[0] == recipeToEdit);
        if (recipeToChange == null)
        {
            Console.WriteLine("Рецепт не знайдено.");
            return;
        }

        Console.Write("Введіть нову назву рецепту: ");
        string newRecipeName = Console.ReadLine();
        Console.Write("Скільки інгредієнтів ви хочете додати до рецепту? ");
        int newIngredientCount = int.Parse(Console.ReadLine());
        List<Ingredient> newIngredients = new List<Ingredient>();
        for (int i = 0; i < newIngredientCount; i++)
        {
            Console.Write("Введіть назву інгредієнта: ");
            string newIngredientName = Console.ReadLine();
            Console.Write("Введіть кількість інгредієнта: ");
            int newIngredientQuantity = int.Parse(Console.ReadLine());
            Ingredient newIngredient = new Ingredient { Name = newIngredientName, Quantity = newIngredientQuantity };
            newIngredients.Add(newIngredient);
        }
        recipeToChange.Instructions = new List<string> { newRecipeName };
        recipeToChange.Ingredients = newIngredients;
        Console.WriteLine($"Рецепт '{recipeToEdit}' було успішно відредаговано.");
    }

}
