using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Level Data")]
    [SerializeField] private LevelData levelData;

    [Header("Prefabs")]
    [SerializeField] private Tower towerPrefab;
    [SerializeField] private Disk diskPrefab;

    [Header("Transform Parameters")]
    [SerializeField] private Transform playAreaCenter;
    [SerializeField] private float playAreaWidth = 8f;

    [Header("Towers Section")]
    [SerializeField]
    private Tower[] towers;

    void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        GenerateTowers();
        GenerateDisks();
    }

    private void GenerateTowers()
    {
        towers = new Tower[levelData.numberOfTowers];

        float totalWidth = playAreaWidth;
        float spacing = totalWidth / (levelData.numberOfTowers - 1);

        float startX = playAreaCenter.position.x - totalWidth / 2f;

        for (int i = 0; i < levelData.numberOfTowers; i++)
        {
            Vector3 position = new Vector3( startX + spacing * i, playAreaCenter.position.y, playAreaCenter.position.z );

            Tower tower = Instantiate(towerPrefab);
            tower.transform.position = position;
            tower.transform.parent = playAreaCenter;
            tower.Init(levelData.diskHeight);

            towers[i] = tower;
        }
    }


    private void GenerateDisks()
    {
        Tower startTower = towers[0];

        for (int i = levelData.numberOfDisks; i >= 1; i--)
        {
            Disk disk = Instantiate(diskPrefab);

            Material mat = levelData.diskMaterials[Mathf.Clamp(i - 1, 0, levelData.diskMaterials.Length - 1)];

            disk.Init( i,levelData.diskScaleStep,levelData.diskHeight,mat);

            disk.transform.parent = startTower.transform;

            startTower.Push(disk);
        }
    }
}