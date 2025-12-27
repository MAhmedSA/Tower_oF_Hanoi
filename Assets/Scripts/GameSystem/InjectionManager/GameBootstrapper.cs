using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private MouseClickInput mouseInput;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private UIManager uiManager;


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
        MoveService moveService = new MoveService(validator, invoker);
        //Create solver Service
        HanoiSolver hanoiSolver = new HanoiSolver(moveService);
        IFeedbackService feedbackService = new FeedbackService();

        // Inject into input
        mouseInput.SetMoveService(moveService);
        //Inject feedback service into input
        mouseInput.SetFeedbackService(feedbackService);

        // Subscribe feedback service to move service events
        moveService.OnInvalidMove += feedbackService.PlayInvalidMove;

        // Inject solver service into GameManger
        gameManager.SetSolver(hanoiSolver, invoker);

        // Inject services neeeded  into UIManager
        uiManager.Init(moveService, invoker, gameManager);



    }
}
