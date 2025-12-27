using UnityEngine;

public class Disk : MonoBehaviour
{
    public int Size { get; private set; }

    [SerializeField] private Renderer diskRenderer;

    public void Init(int size,float stepSize,float diskHight, Material material)
    {
        Size = size;

        if (diskRenderer != null && material != null)
            diskRenderer.material = material;

        //scale disk by size
        float scale = 100 + size * stepSize;
        transform.localScale = new Vector3(scale,  scale, diskHight);
    }
}