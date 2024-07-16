namespace ServerManagement.Components.Models;

public static class CityRepository
{
    public static List<string> Cities = new List<string>()
    {
        "Toronto",
        "Montreal",
        "Halifax",
        "Calgary",
        "Ottawa"
    };

    public static List<string> GetCities()
    {
        return Cities;
    }
}
