using UnityEngine;

public class MouseClickInput : MonoBehaviour, IInputHandler
{
    public Camera cam;
    MoveService moveService;
    private IFeedbackService feedbackService;
    private Tower selectedTower;
    public void SetMoveService(MoveService service)
    {
        moveService = service;
    }

    public void SetFeedbackService(IFeedbackService feedback)
    {
        feedbackService = feedback;
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
            feedbackService?.PlaySelectTower(tower);
        }
        else if (selectedTower == tower)
        {
            feedbackService?.PlayDeselectTower(tower);
            selectedTower = null;
        }
        else
        {
            moveService.TryMove(selectedTower, tower);
      
            feedbackService?.PlayDeselectTower(selectedTower);
            selectedTower = null;
        }
    }

}