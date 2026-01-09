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
        // PLAN:
        // First, create an array that can store the required number of multiples.
        // Then, loop through the array from start to finish.
        // For each position, calculate the next multiple of the number.
        // Store each calculated value in the array.
        // Finally, return the completed array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            // We use (i + 1) so the first value is the first multiple, not zero
            result[i] = number * (i + 1);
        }

        return result;
    }
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN:
        // If the list has fewer than two elements, rotating it would change nothing.
        // Reduce the rotation amount using modulo to avoid unnecessary full rotations.
        // Split the list into two parts:
        //   - The last 'amount' elements that will move to the front.
        //   - The remaining elements that will move to the back.
        // Clear the original list.
        // Rebuild the list by adding the second part first, then the first part.

        if (data.Count < 2) return;

        int effectiveAmount = amount % data.Count;
        if (effectiveAmount == 0) return;

        List<int> tail = data.GetRange(
            data.Count - effectiveAmount,
            effectiveAmount
        );

        List<int> head = data.GetRange(
            0,
            data.Count - effectiveAmount
        );

        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}
