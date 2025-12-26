using System.Collections;
using UnityEngine;

public interface ISolver
{
    IEnumerator Solve(int diskCount,Tower from,Tower auxiliary,Tower to,float moveDelay);
}
