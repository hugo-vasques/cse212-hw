public static class Arrays
{
    public static double[] MultiplesOf(double number, int length)
    {
        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    public static void RotateListRight(List<int> data, int amount)
    {
        if (data.Count < 2) return;

        int effectiveAmount = amount % data.Count;
        if (effectiveAmount == 0) return;

        List<int> tail = data.GetRange(data.Count - effectiveAmount, effectiveAmount);

        List<int> head = data.GetRange(0, data.Count - effectiveAmount);

        data.Clear();          
        data.AddRange(tail);   
        data.AddRange(head);   
    }
}
