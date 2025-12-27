using System.Collections;
public interface ISolver
{
    IEnumerator Solve(int diskCount,Tower from,Tower auxiliary,Tower to,float moveDelay);
}
