public static class Arrays
{
    /// <summary>
    /// Generates an array of multiples of a given number.
    /// The array will have the specified length and will start
    /// from the first multiple of the number.
    ///
    /// Example:
    /// MultiplesOf(7, 5) → {7, 14, 21, 28, 35}
    /// </summary>
    /// <returns>An array containing the multiples of the given number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Create an array where we will store the result
        double[] result = new double[length];

        // Loop through the array and fill it with multiples of the number
        for (int i = 0; i < length; i++)
        {
            // (i + 1) is used because we want the first multiple, not zero
            result[i] = number * (i + 1);
        }

        // Return the completed array
        return result;
    }

    /// <summary>
    /// Rotates the elements of a list to the right by a given amount.
    ///
    /// Example:
    /// {1,2,3,4,5,6,7,8,9} rotated by 3 →
    /// {7,8,9,1,2,3,4,5,6}
    ///
    /// The original list is modified directly.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // If the list has 0 or 1 elements, there's nothing to rotate
        if (data.Count < 2) return;

        // Reduce the rotation amount in case it's larger than the list size
        int effectiveAmount = amount % data.Count;
        if (effectiveAmount == 0) return;

        // Take the last 'effectiveAmount' elements (these will move to the front)
        List<int> tail = data.GetRange(
            data.Count - effectiveAmount,
            effectiveAmount
        );

        // Take the remaining elements from the beginning
        List<int> head = data.GetRange(
            0,
            data.Count - effectiveAmount
        );

        // Clear the list and rebuild it in the new order
        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}
