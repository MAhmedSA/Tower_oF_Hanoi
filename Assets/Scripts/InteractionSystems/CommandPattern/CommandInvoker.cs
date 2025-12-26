using System.Collections.Generic;

public class CommandInvoker
{
    private Stack<ICommand> undoStack = new();
    private Stack<ICommand> redoStack = new();
    public int UndoStackCount => undoStack.Count;
    public int RedoStackCount => undoStack.Count;
    public void Execute(ICommand command)
    {
        command.Execute();
        undoStack.Push(command);
        redoStack.Clear();
    }

    public void Undo()
    {
        if (undoStack.Count == 0) return;

        var cmd = undoStack.Pop();
        cmd.Undo();
        redoStack.Push(cmd);
    }

    public void Redo()
    {
        if (redoStack.Count == 0) return;

        var cmd = redoStack.Pop();
        cmd.Execute();
        undoStack.Push(cmd);
    }
    
    public void Clear()
    {
        undoStack.Clear();
        redoStack.Clear();
    }
}
