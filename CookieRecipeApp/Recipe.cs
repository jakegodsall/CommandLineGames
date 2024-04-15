namespace CookieRecipeApp;

public class Recipe
{
    public static int Id { get; set; }
    public List<Ingredient> Ingredients { get; set; }

    public Recipe()
    {
        Ingredients = new List<Ingredient>();
    }

    public override string ToString()
    {
        var repr = "[\n";
        foreach (var ingredient in Ingredients)
        {
            repr += "    ( " + ingredient + " ),\n";
        }

        repr += "]";
        return repr;
    } 
}