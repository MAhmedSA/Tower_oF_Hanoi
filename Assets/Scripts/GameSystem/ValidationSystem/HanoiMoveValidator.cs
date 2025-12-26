public class HanoiMoveValidator : IMoveValidator
{
    public bool IsValid(Tower from, Tower to)
    {
        if (from.Peek() == null)
            return false;

        Disk disk = from.Peek();
        return to.CanPlace(disk);
    }
}