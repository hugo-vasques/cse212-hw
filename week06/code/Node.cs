public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Problema 1: Not allowing dupes
        if (value == Data)
            return;

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // 1. Base case: If the value is equal to the data of the current node, we found it
        if (value == Data)
        {
            return true;
        }

        // 2. If the value is lower, we look in the left subtree
        if (value < Data)
        {
            // We only check if the left son exists
            return Left != null && Left.Contains(value);
        }
        // 3. If the value is greater, then we look for the subtree of the right
        else
        {
            // We only check if the right son exists
            return Right != null && Right.Contains(value);
        }
    }
    public int GetHeight()
    {
        {
            // 1. We calculate the height of the left subtree recursively.

            // If the child is null, its height contributes 0.
            int leftHeight = Left != null ? Left.GetHeight() : 0;

            // 2. We calculate the height of the right subtree recursively.

            // If the child is null, its height contributes 0.
            int rightHeight = Right != null ? Right.GetHeight() : 0;

            // 3. The height of this node is 1 plus the maximum between the left and right heights.
            return 1 + Math.Max(leftHeight, rightHeight);
        }
    }
}