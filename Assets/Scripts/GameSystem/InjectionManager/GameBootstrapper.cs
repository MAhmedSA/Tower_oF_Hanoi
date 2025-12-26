using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private MouseClickInput mouseInput;

    private MoveService moveService;

    void Awake()
    {
        BuildDependencies();
    }
    void BuildDependencies()
    {
       
        // Create low-level services
        IMoveValidator validator = new HanoiMoveValidator();
        CommandInvoker invoker = new CommandInvoker();

        // Create MoveService (THIS answers your question)
        moveService = new MoveService(validator, invoker);

        // Inject into input
        mouseInput.SetMoveService(moveService);

    }
}
