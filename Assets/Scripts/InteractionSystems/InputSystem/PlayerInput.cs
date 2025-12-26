using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private MonoBehaviour inputHandler; // must implement IInputHandler

    private IInputHandler handler;

    void Awake()
    {
        handler = inputHandler as IInputHandler;
    }

    void Update()
    {
        handler?.HandleInput();
    }
}