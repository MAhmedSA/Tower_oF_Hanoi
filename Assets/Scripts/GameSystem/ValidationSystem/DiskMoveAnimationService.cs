using System.Collections;
using UnityEngine;

public class DiskMoveAnimationService : MonoBehaviour
{
    [SerializeField] private float liftHeight = 1f;
    [SerializeField] private float moveSpeed = 5f;

    private MoveService moveService;
    public bool IsAnimating { get; private set; }

    public event System.Action OnAnimationFinished;
    public void Initialize(MoveService service)
    {
        moveService = service;
        moveService.OnMoveRequested += AnimateMove;
    }

    private void AnimateMove(Tower from, Tower to)
    {
        if (IsAnimating) return;

        Disk disk = from.Peek();
        if (disk == null) return;

        // freeze target position ONCE
        Vector3 targetPos = to.GetNextDiskPosition();

        StartCoroutine(MoveDiskRoutine(disk, from, to, targetPos));
    }

    private IEnumerator MoveDiskRoutine(Disk disk,Tower from,Tower to,Vector3 targetPos)
    {
        IsAnimating = true;

        Transform diskTransform = disk.transform;

        //  Deatch from tower
        diskTransform.SetParent(null, true);

        Vector3 startPos = diskTransform.position;
        Vector3 upPos = startPos + Vector3.up * liftHeight;
       

        yield return MoveTo(diskTransform, upPos);

        yield return MoveTo(diskTransform, new Vector3(targetPos.x, upPos.y, targetPos.z));

        yield return MoveTo(diskTransform, targetPos);

        moveService.ExecuteMove(from, to);

        // attach to new tower
        diskTransform.SetParent(to.transform, true);

        IsAnimating = false;
        OnAnimationFinished?.Invoke();
    }
    private IEnumerator MoveTo(Transform t, Vector3 target)
    {
        while (Vector3.Distance(t.position, target) > 0.01f)
        {
            t.position = Vector3.MoveTowards(t.position,target,moveSpeed * Time.deltaTime);
            yield return null;
        }

        t.position = target;
    }
}
