public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Adds a new value to the queue with an associated priority.
    /// The item is always added to the back of the queue,
    /// no matter what its priority is.
    /// </summary>
    /// <param name="value">The value to store</param>
    /// <param name="priority">The priority of the item</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        // Make sure the queue is not empty
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Start by assuming the first item has the highest priority
        var highPriorityIndex = 0;

        // FIX 1:
        // The loop must go up to < _queue.Count (not Count - 1)
        // so that every item in the queue is checked.
        for (int index = 1; index < _queue.Count; index++)
        {
            // FIX 2:
            // Use > instead of >=.
            // If two items have the same priority, we keep the one
            // that appeared first in the queue to preserve FIFO behavior.
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
        }

        // Store the value of the highest-priority item
        var value = _queue[highPriorityIndex].Value;

        // FIX 3:
        // The item was returned, but it was not being removed from the list.
        _queue.RemoveAt(highPriorityIndex);

        return value;
    }

    // DO NOT MODIFY THE CODE IN THIS METHOD
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    // DO NOT MODIFY THE CODE IN THIS METHOD
    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}
