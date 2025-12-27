using System.Collections;
using UnityEngine;

public class HanoiSolver : ISolver
{
    private MoveService moveService;
    private DiskMoveAnimationService animationService;
    public HanoiSolver(MoveService moveService, DiskMoveAnimationService animationService)
    {
        this.moveService = moveService;
        this.animationService = animationService;
    }

    public IEnumerator Solve(int n,Tower from,Tower aux, Tower to,float delay)
    {
        if (n <= 0)
            yield break;

        // Move n-1 disks to auxiliary tower
        yield return Solve(n - 1, from, to, aux, delay);

        // Move largest disk
        moveService.TryMove(from, to);

        // wait until animation finishes
        yield return new WaitUntil(() => !animationService.IsAnimating);

        // optional delay BETWEEN moves
        yield return new WaitForSeconds(delay);

        // Move n-1 disks to target tower
        yield return Solve(n - 1, aux, from, to, delay);
    }
}