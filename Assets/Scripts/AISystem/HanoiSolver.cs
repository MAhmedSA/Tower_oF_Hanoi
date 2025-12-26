using System.Collections;
using UnityEngine;

public class HanoiSolver : ISolver
{
    private MoveService moveService;

    public HanoiSolver(MoveService moveService)
    {
        this.moveService = moveService;
    }

    public IEnumerator Solve(int n,Tower from,Tower aux, Tower to,float delay)
    {
        if (n <= 0)
            yield break;

        // Move n-1 disks to auxiliary tower
        yield return Solve(n - 1, from, to, aux, delay);

        // Move largest disk
        moveService.TryMove(from, to);
        yield return new WaitForSeconds(delay);

        // Move n-1 disks to target tower
        yield return Solve(n - 1, aux, from, to, delay);
    }
}