/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<(int, int), bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<(int, int), bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Check if moving left is allowed. If it is, move left.
    /// Otherwise, throw an exception.
    /// </summary>
    public void MoveLeft()
    {
        // Index 0 represents the Left direction
        if (_mazeMap.ContainsKey((_currX, _currY)) && _mazeMap[(_currX, _currY)][0])
        {
            _currX--;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check if moving right is allowed. If it is, move right.
    /// Otherwise, throw an exception.
    /// </summary>
    public void MoveRight()
    {
        // Index 1 represents the Right direction
        if (_mazeMap.ContainsKey((_currX, _currY)) && _mazeMap[(_currX, _currY)][1])
        {
            _currX++;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check if moving up is allowed. If it is, move up.
    /// Otherwise, throw an exception.
    /// </summary>
    public void MoveUp()
    {
        // Index 2 represents the Up direction
        // Reminder: moving up usually decreases Y
        if (_mazeMap.ContainsKey((_currX, _currY)) && _mazeMap[(_currX, _currY)][2])
        {
            _currY--;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check if moving down is allowed. If it is, move down.
    /// Otherwise, throw an exception.
    /// </summary>
    public void MoveDown()
    {
        // Index 3 represents the Down direction
        // Reminder: moving down usually increases Y
        if (_mazeMap.ContainsKey((_currX, _currY)) && _mazeMap[(_currX, _currY)][3])
        {
            _currY++;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
