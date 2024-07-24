public static int LevenshteinDistance(string source, string target)
{
    if (string.IsNullOrEmpty(source))
    {
        return string.IsNullOrEmpty(target) ? 0 : target.Length;
    }

    if (string.IsNullOrEmpty(target))
    {
        return source.Length;
    }

    int sourceLength = source.Length;
    int targetLength = target.Length;

    int[,] distance = new int[sourceLength + 1, targetLength + 1];

    for (int i = 0; i <= sourceLength; distance[i, 0] = i++) { }
    for (int j = 0; j <= targetLength; distance[0, j] = j++) { }

    for (int i = 1; i <= sourceLength; i++)
    {
        for (int j = 1; j <= targetLength; j++)
        {
            int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;
            distance[i, j] = Math.Min(
                Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1),
                distance[i - 1, j - 1] + cost);
        }
    }

    return distance[sourceLength, targetLength];
}

public static double CalculateSimilarity(string source, string target)
{
    int distance = LevenshteinDistance(source, target);
    int maxLength = Math.Max(source.Length, target.Length);

    if (maxLength == 0)
    {
        return 1.0; // İki metin de boşsa tamamen benzerdir.
    }

    return (1.0 - (double)distance / maxLength) * 100.0;
}

// Using
double similarity = CalculateSimilarity("Araba", "Araba");
