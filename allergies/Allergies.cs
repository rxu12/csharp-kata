using System;
using System.Linq;

public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies
{
    private int _mask;
    public Allergies(int mask)
    {
        _mask = mask;
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        string _allergen = Convert.ToString((int)allergen, 2);
        string _maskBin = Convert.ToString(_mask, 2);
        if (_maskBin.Length < _allergen.Length) return false;
        return _maskBin.Substring(_maskBin.Length - _allergen.Length)[0] == '1';
    }

    public Allergen[] List()
    {
        return Enum.GetValues(typeof(Allergen))
        .Cast<Allergen>()
        .Where(IsAllergicTo)
        .ToArray();
    }
}