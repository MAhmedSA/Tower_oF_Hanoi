using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private MouseClickInput mouseInput;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private UIManager uiManager;

    private MoveService moveService; // move service Variable to be injected
    private HanoiSolver hanoiSolver;// hanoi solver variable to be injected

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
        //Create solver Service
        hanoiSolver = new HanoiSolver(moveService);

        // Inject into input
        mouseInput.SetMoveService(moveService);

        // Inject solver service into GameManger
        gameManager.SetSolver(hanoiSolver, invoker);

        // Inject services neeeded  into UIManager
        uiManager.Init(moveService, invoker, gameManager);



    }
}
