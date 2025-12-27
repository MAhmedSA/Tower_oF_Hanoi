public class MoveService
{
    private readonly IMoveValidator validator;
    private readonly CommandInvoker invoker;
    public event System.Action<Tower, Tower> OnMoveRequested;
    public event System.Action<Tower, Tower> OnInvalidMove;
    public event System.Action OnMoveExecuted;
    public MoveService(IMoveValidator validator, CommandInvoker invoker)
    {
        this.validator = validator;
        this.invoker = invoker;
    }

    public void TryMove(Tower from, Tower to)
    {
        if (!validator.IsValid(from, to))
        {
            OnInvalidMove?.Invoke(from, to);
            return ;
        }

        // invoker.Execute(new MoveDiskCommand(from, to));
        //  OnMoveExecuted?.Invoke();
        OnMoveRequested?.Invoke(from, to);

    }
    // called AFTER animation finishes
    public void ExecuteMove(Tower from, Tower to)
    {
        invoker.Execute(new MoveDiskCommand(from, to));
        OnMoveExecuted?.Invoke();
    }

    public void Undo() { 
        invoker.Undo();
        OnMoveExecuted?.Invoke();
    }
    public void Redo() { 
        invoker.Redo();
        OnMoveExecuted?.Invoke();
    } 
}