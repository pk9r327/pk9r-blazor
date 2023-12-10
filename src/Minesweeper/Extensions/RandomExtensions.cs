namespace Pk9r.Blazor.Minesweeper.Components.Extensions;
public static class RandomExtensions
{
    public static IEnumerable<T> TakeRandom<T>(this Random random, IEnumerable<T> source, int count)
    {
        var array = source.ToArray();

        int n = array.Length;

        if (count > n)
        {
            throw new ArgumentOutOfRangeException(nameof(count), 
                "Count cannot be greater than the number of elements in the collection.");
        }

        var result = new T[count];

        for (int i = 0; i < count; i++)
        {
            int r = random.Next(i, n);
            result[i] = array[r];
            array[r] = array[i];
        }

        return result;
    }
}
