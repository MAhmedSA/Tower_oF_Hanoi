public class MoveService
{
    private readonly IMoveValidator validator;
    private readonly CommandInvoker invoker;

    public MoveService(IMoveValidator validator, CommandInvoker invoker)
    {
        this.validator = validator;
        this.invoker = invoker;
    }

    public void TryMove(Tower from, Tower to)
    {
        if (!validator.IsValid(from, to))
        {
            return;
        }

        invoker.Execute(new MoveDiskCommand(from, to));
    }

    public void Undo() => invoker.Undo();
    public void Redo() => invoker.Redo();
}