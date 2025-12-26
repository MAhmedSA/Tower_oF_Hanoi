using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData")]
public class LevelData : ScriptableObject
{
    public int numberOfDisks;
    public int numberOfTowers;

    public Material[] diskMaterials;

    public float diskHeight = 0.3f;
    public float diskScaleStep = 0.2f;

    public float towerSpacing = 2.5f;
    public float towerBaseHeight = 0.5f;
}