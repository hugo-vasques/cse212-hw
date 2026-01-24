using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two-character
    /// words (lowercase, no duplicates). Using sets, find an O(n)
    /// solution that returns all symmetric word pairs.
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        // PROBLEM 1 SOLUTION
        var seen = new HashSet<string>();
        var pairs = new List<string>();

        foreach (var word in words)
        {
            // Reverse the word (example: "am" -> "ma")
            var reversed = $"{word[1]}{word[0]}";

            // If we've already seen the reversed word, it's a pair
            if (seen.Contains(reversed))
            {
                pairs.Add($"{word} & {reversed}");
            }
            else
            {
                // Otherwise, store the current word for future matches
                seen.Add(word);
            }
        }

        return pairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by the people listed in the file.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        // PROBLEM 2 SOLUTION
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            // Column 4 (index 3) contains the education degree
            if (fields.Length > 3)
            {
                var degree = fields[3].Trim();

                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    degrees[degree] = 1;
                }
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine whether 'word1' and 'word2' are anagrams.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // PROBLEM 3 SOLUTION (optimized for speed)
        var count1 = new Dictionary<char, int>();
        int len1 = 0;

        // Count letters from the first word
        foreach (char c in word1)
        {
            if (c == ' ') continue;
            char lower = char.ToLower(c);

            if (count1.ContainsKey(lower))
                count1[lower]++;
            else
                count1[lower] = 1;

            len1++;
        }

        int len2 = 0;

        // Subtract letters using the second word
        foreach (char c in word2)
        {
            if (c == ' ') continue;
            char lower = char.ToLower(c);

            // If a letter is missing or used too many times, not an anagram
            if (!count1.ContainsKey(lower) || count1[lower] == 0)
                return false;

            count1[lower]--;
            len2++;
        }

        // Both words must have the same number of valid characters
        return len1 == len2;
    }


    /// <summary>
    /// This function will read JSON data from the USGS.
    /// </summary>

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