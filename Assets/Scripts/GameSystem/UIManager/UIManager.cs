using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button undoButton;
    [SerializeField] private Button redoButton;
    [SerializeField] private Button resetButton;

    [Header("Texts")]
    [SerializeField] private TMP_Text moveCounterText;

    private MoveService moveService;
    private CommandInvoker invoker;
    private IGameActions gameActions;

    public void Init(MoveService moveService,CommandInvoker invoker,IGameActions gameActions)
    {
        this.moveService = moveService;
        this.invoker = invoker;
        this.gameActions = gameActions;

        BindButtons();
        UpdateMoveCounter();
    }

    private void BindButtons()
    {
        undoButton.onClick.AddListener(() =>
        {
            moveService.Undo();
            UpdateMoveCounter();
        });
        redoButton.onClick.AddListener(() =>
        {
            moveService.Redo();
            UpdateMoveCounter();
        });
        resetButton.onClick.AddListener(() =>
        {
            gameActions.ResetGame();
            invoker.Clear();
            UpdateMoveCounter();
        });
        

    }

    void UpdateMoveCounter()
    {
        moveCounterText.text = $"Moves: {invoker.UndoStackCount}";
    }
}