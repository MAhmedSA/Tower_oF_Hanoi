using UnityEngine;

public class MouseClickInput : MonoBehaviour, IInputHandler
{
    public Camera cam;
    MoveService moveService;

    private Tower selectedTower;
    public void SetMoveService(MoveService service)
    {
        moveService = service;
    }
    public void HandleInput()
    {
        if (!Input.GetMouseButtonDown(0)) {
           
            return;
        }
          
        

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit)) { 
           
            return;
        } 
        

        Tower tower = hit.collider.GetComponent<Tower>();
       
        if (tower == null) return;

        if (selectedTower == null)
        {
            selectedTower = tower;
        }
        else
        {
            Debug.Log("Attempting move from " + selectedTower.name + " to " + tower.name);
            moveService.TryMove(selectedTower, tower);
            selectedTower = null;
        }
    }

    public void TryUndo() {
        moveService.Undo();
    }
    public void TryRedo()
    {
        moveService.Redo();
    }
}