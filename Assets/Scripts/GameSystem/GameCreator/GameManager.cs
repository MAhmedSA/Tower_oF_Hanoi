using UnityEngine;

public class GameManager : MonoBehaviour, IGameActions
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

    [Header("Solver Parameters")]
    private ISolver solver;
    [Range(0,1)]
    [SerializeField] float delaySolve = 0.8f;

    [Header("Reset Section Variables")]
    private CommandInvoker invoker;
    void Start()
    {
        GenerateLevel();
    }
    // Inject Solver Service from Bootstrapper
    public void SetSolver(ISolver solver, CommandInvoker invoker)
    {
        this.solver = solver;
        this.invoker = invoker;
    }
    // Generate Level based on level data
    private void GenerateLevel()
    {
        GenerateTowers();
        GenerateDisks();
    }

    // Generate Towers based on level data
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

    // Generate Disks and place them on the first tower
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
    // method to start auto solving the puzzle
    public void StartAutoSolve()
    {
        //reset the game if there are any moves made after that start solving
        if (invoker.UndoStackCount > 0) {
            ResetGame();
        }

        StartCoroutine(solver.Solve(levelData.numberOfDisks, towers[0],towers[1],towers[2], delaySolve));
    }

    //Reset the game by regenerating the level 
    public void ResetGame()
    {
        while (invoker.UndoStackCount > 0)
        {
            invoker.Undo();
        }
        invoker.Clear();
    }
}