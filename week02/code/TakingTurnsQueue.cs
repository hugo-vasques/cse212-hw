/// <summary>
/// This is a circular queue. When someone is added using AddPerson,
/// they are placed at the back of the queue (standard FIFO behavior).
/// 
/// When GetNextPerson is called, the next person is taken from the front,
/// returned, and usually placed back at the end of the queue so everyone
/// gets their turn.
/// 
/// Each person has a number of turns:
/// - If turns is 0 or less, it means they have infinite turns.
/// - Once a person runs out of turns, they are no longer added back
///   into the queue.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Adds a new person to the queue with their name and the number
    /// of turns they have.
    /// </summary>
    /// <param name="name">The person's name</param>
    /// <param name="turns">How many turns they have left</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Returns the next person in the queue.
    /// 
    /// After their turn:
    /// - If they have infinite turns (turns <= 0), they go back into the queue as-is.
    /// - If they still have turns left, one turn is used and they go to the back.
    /// - If they were on their last turn, they are removed from the queue.
    /// 
    /// Throws an exception if the queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }
        else
        {
            Person person = _people.Dequeue();

            // Key idea:
            // turns <= 0  → infinite turns, always goes back into the queue
            // turns > 1   → use one turn and re-add to the queue
            // turns == 1  → last turn used, does not go back

            if (person.Turns <= 0)
            {
                _people.Enqueue(person);
            }
            else if (person.Turns > 1)
            {
                person.Turns -= 1;
                _people.Enqueue(person);
            }

            return person;
        }
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
