using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Stack<Disk> disks = new Stack<Disk>();
    [SerializeField] private MonoBehaviour feedbackTarget;

    public int DiskCount => disks.Count;

    [Header("Visual")]
    [SerializeField] private Transform topPoint;
    [SerializeField] private float diskHeight =1.2f;
    public IFeedbackTarget Feedback => feedbackTarget as IFeedbackTarget;
    public void Init(float diskHeight)
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, diskHeight);
    }

    public bool CanPlace(Disk disk)
    {
        return disks.Count == 0 || disks.Peek().Size > disk.Size;
    }

    public void Push(Disk disk)
    {
        disks.Push(disk);
        disk.transform.position = topPoint.position + Vector3.up * (disks.Count - 1) * 0.12f;
    }

    public Disk Pop()
    {
        return disks.Pop();
    }

    public Disk Peek()
    {
        return disks.Count > 0 ? disks.Peek() : null;
    }
    public Vector3 GetNextDiskPosition()
    {
        return topPoint.position + Vector3.up * (disks.Count - 1) * 0.12f;
    }

}
