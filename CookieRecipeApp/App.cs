namespace CookieRecipeApp;

public class App
{
    public static List<Ingredient> IngredientOptions { get; set; } = new List<Ingredient>();
    public Recipe recipe;

    public App()
    {
        BootStrapIngredients();
        recipe = new Recipe();
    }

    public void Run()
    {
        Console.WriteLine("Create a new cookie recipe!");
        DisplayIngredients();
        Console.WriteLine("Add an ingredient by it's Id or type anything else if finished.");
        var selectedId = ConsoleInputHelper.GetIntegerInputInRange("Enter a valid Id", 0, IngredientOptions.Count);
        recipe.Ingredients.Add(IngredientOptions.First(ingredient => ingredient.Id == selectedId));
        Console.WriteLine(recipe);
    }

    public void DisplayIngredients()
    {
        foreach (var ingredient in IngredientOptions)
        {
            Console.WriteLine(ingredient);
        }
    }
    
    private void BootStrapIngredients()
    {
        IngredientOptions.Add(new Ingredient("Wheat flour", ""));
        IngredientOptions.Add(new Ingredient("Coconut flour", ""));
        IngredientOptions.Add(new Ingredient("Butter", ""));
        IngredientOptions.Add(new Ingredient("Chocolate", ""));
        IngredientOptions.Add(new Ingredient("Sugar", ""));
        IngredientOptions.Add(new Ingredient("Cardamom", ""));
        IngredientOptions.Add(new Ingredient("Cinnamon", ""));
        IngredientOptions.Add(new Ingredient("Cocoa powder", ""));
    }
}