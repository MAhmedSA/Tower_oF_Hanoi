using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Stack<Disk> disks = new Stack<Disk>();
    [SerializeField] private MonoBehaviour feedbackTarget;
    public IFeedbackTarget Feedback => feedbackTarget as IFeedbackTarget;
    public void Init(float diskHeight)
    {
        //transform.localScale = new Vector3(transform.localScale.x, diskHeight, transform.localScale.z);
    }

    public bool CanPlace(Disk disk)
    {
        return disks.Count == 0 || disks.Peek().Size > disk.Size;
    }

    public void Push(Disk disk)
    {
        disks.Push(disk);
        disk.transform.position = transform.position + Vector3.up * (disks.Count - 1) * 0.1f;
    }

    public Disk Pop()
    {
        return disks.Pop();
    }

    public Disk Peek()
    {
        return disks.Count > 0 ? disks.Peek() : null;
    }


}
