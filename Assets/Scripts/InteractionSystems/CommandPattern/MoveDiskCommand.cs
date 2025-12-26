using UnityEngine;

public class MoveDiskCommand : ICommand
{
    private Tower source;
    private Tower target;
    private Disk disk;

    public MoveDiskCommand(Tower from, Tower to)
    {
        source = from;
        target = to;
    }

    public void Execute()
    {
        disk = source.Pop();
        target.Push(disk);
    }

    public void Undo()
    {
        target.Pop();
        source.Push(disk);
    }
}