namespace SandwichShop.DB;

public record Sandwich
{
public int Id { get; set; }
public string ? Name { get; set; }
}

public class SandwichDB
{
    private static List<Sandwich> _sandwiches = new List<Sandwich>()
    {
        new Sandwich {Id=1, Name="Tuna on Rye"},
        new Sandwich {Id=2, Name="Hot Pastrami"},
        new Sandwich {Id=3, Name="Ham and Cheese"},
        new Sandwich {Id=4, Name="Turkey Avocado"},
        new Sandwich {Id=5, Name="Roast Beef"},
        new Sandwich {Id=6, Name="B.L.T."}
    };

    public static List<Sandwich> GetSandwiches()
    {
        return _sandwiches;
    }

    public static Sandwich ? GetSandwich(int id)
    {
        return _sandwiches.SingleOrDefault(sandy => sandy.Id == id);
    }

    public static Sandwich CreateSandwich(Sandwich sandy) 
    {
        _sandwiches.Add(sandy);
        return sandy;
    }

    public static Sandwich UpdateSandwich(Sandwich update) 
    {
        _sandwiches = _sandwiches.Select(sandy =>
        {
            if(sandy.Id == update.Id)
            {
                sandy.Name = update.Name;
            }
            return sandy;
        }).ToList();
        return update;
    }

    public static void RemoveSandwich(int id)
    {
        _sandwiches = _sandwiches.FindAll(sandy => sandy.Id != id).ToList();
    }
}