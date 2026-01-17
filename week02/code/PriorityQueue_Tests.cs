using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases, then fix the code so it meets the requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with Node A (Pri: 10), Node B (Pri: 50), and Node C (Pri: 20)
    // Expected Result: Dequeue should return B first, then C, and finally A.
    // Defect(s) Found:
    // 1. The loop in Dequeue skipped the last item (index < count - 1).
    // 2. The item was returned, but it was never actually removed from the list.
    public void TestPriorityQueue_Basics()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 10);
        priorityQueue.Enqueue("B", 50);
        priorityQueue.Enqueue("C", 20);

        // B has the highest priority (50)
        var first = priorityQueue.Dequeue();
        Assert.AreEqual("B", first);

        // C has the next highest priority (20)
        var second = priorityQueue.Dequeue();
        Assert.AreEqual("C", second);

        // A has the lowest priority (10)
        var third = priorityQueue.Dequeue();
        Assert.AreEqual("A", third);
    }

    [TestMethod]
    // Scenario: Create a queue with two items that have the same highest priority.
    // Node A (Pri: 50), Node B (Pri: 50), Node C (Pri: 10).
    // Expected Result: The queue should follow FIFO when priorities are tied.
    // It should return A, then B, then C.
    // Defect(s) Found:
    // 1. The comparison used >= instead of >, which caused the queue
    //    to return the LAST highest-priority item (LIFO) instead of the FIRST (FIFO).
    public void TestPriorityQueue_TieBreaking()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 50);
        priorityQueue.Enqueue("B", 50);
        priorityQueue.Enqueue("C", 10);

        // A was added first with priority 50, so it should come out before B
        var first = priorityQueue.Dequeue();
        Assert.AreEqual("A", first);

        var second = priorityQueue.Dequeue();
        Assert.AreEqual("B", second);

        var third = priorityQueue.Dequeue();
        Assert.AreEqual("C", third);
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown.
    // Defect(s) Found: None (this behavior was already working correctly).
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("An exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}
