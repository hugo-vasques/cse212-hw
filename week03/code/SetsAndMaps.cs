using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        // Keeps track of the words we've already seen.
        // HashSet gives us O(1) lookups, so it's perfect for this.
        var seen = new HashSet<string>();

        // Stores the pairs we find in the format "word & reversed".
        var pairs = new List<string>();

        // We only loop once through the list.
        foreach (var word in words)
        {
            // Reverse the word.
            // Since every word has exactly 2 letters, we can just swap them.
            var reversed = $"{word[1]}{word[0]}";

            // Check if we've already seen the reversed version.
            if (seen.Contains(reversed))
            {
                // If yes, we found a pair.
                // Example: "ab" & "ba"
                pairs.Add($"{word} & {reversed}");
            }
            else
            {
                // If not, we save this word so its pair can find it later.
                // For "aa", this will be added once, but never matched again
                // because there are no duplicates.
                seen.Add(word);
            }

            return pairs.ToArray();
        }

        return [];
    }

    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            // 1. Get the degree from the 4th column (index 3).
            // We use Trim() just in case there are extra spaces.
            var degree = fields[3].Trim();

            // 2. Check if this degree is already in the dictionary.
            if (degrees.ContainsKey(degree))
            {
                // If we've seen it before, just increase the count.
                degrees[degree]++;
            }
            else
            {
                // First time seeing this degree, add it with a count of 1.
                degrees[degree] = 1;
            }

        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // 1. Preprocessing: remove spaces and convert to lowercase
        var w1 = word1.Replace(" ", "").ToLower();
        var w2 = word2.Replace(" ", "").ToLower();

        // 2. If lengths are different, they can't be anagrams
        if (w1.Length != w2.Length)
            return false;

        // 3. Count letters from the first word
        var letterCounts = new Dictionary<char, int>();

        foreach (var c in w1)
        {
            if (letterCounts.ContainsKey(c))
                letterCounts[c]++;
            else
                letterCounts[c] = 1;
        }

        // 4. Subtract letters using the second word
        foreach (var c in w2)
        {
            // If a letter doesn't exist in the first word, it's not an anagram
            if (!letterCounts.ContainsKey(c))
                return false;

            letterCounts[c]--;

            // If count goes below zero, w2 has this letter too many times
            if (letterCounts[c] < 0)
                return false;
        }

        // If we made it this far, the words are exact anagrams
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}