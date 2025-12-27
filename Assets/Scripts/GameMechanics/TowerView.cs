using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class TowerView : MonoBehaviour, IFeedbackTarget
{
    private Renderer rend;
    private Color originalColor;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    public void FlashInvalid()
    {
        StopAllCoroutines();
        StartCoroutine(Flash(Color.red, 0.15f));
    }

    public void Select()
    {
        rend.material.color = Color.yellow;
    }

    public void Deselect()
    {
        rend.material.color = originalColor;
    }

    private IEnumerator Flash(Color color, float duration)
    {
        rend.material.color = color;
        yield return new WaitForSeconds(duration);
        rend.material.color = originalColor;
    }
}
