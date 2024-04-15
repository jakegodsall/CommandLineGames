namespace CookieRecipeApp;

public class Ingredient
{
    private static int NumberOfInstances { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public string PreparationInstructions { get; set; }

    public Ingredient(string name, string preparationInstructions)
    {
        NumberOfInstances++;
        Id = NumberOfInstances; 
        Name = name;
        PreparationInstructions = preparationInstructions;
    }

    public override string ToString()
    {
        return $"{Id}. {Name}";
    }
}