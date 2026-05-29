using UnityEngine;
using System.Collections;

public class MineSweeperManager : MonoBehaviour
{
    [Header("Clear Reward")]
    [SerializeField] private SpriteRenderer rewardObjectSprite;
    [SerializeField] private Sprite clearedSprite;
    [SerializeField] private Collider2D rewardObjectCollider;



    [Header("Board")]
    public int width = 10;
    public int height = 10;
    public int mineCount = 15;
    public int OpenCount = 4;

    [Header("References")]
    public Transform boardParent;
    public MineCell cellPrefab;

    private MineCell[,] cells;
    private bool gameOver;

    private readonly int[] dx = { -1, 0, 1, -1, 1, -1, 0, 1 };
    private readonly int[] dy = { -1, -1, -1, 0, 0, 1, 1, 1 };


    [SerializeField] private GroupMinePlacer groupMinePlacer;
    [SerializeField] private bool useGroupedMines;
    private void Start()
    {
        ResetBoard();
    }

    private void ResetBoard()
    {
        gameOver = false;

        foreach (Transform child in boardParent)
        {
            Destroy(child.gameObject);
        }

        CreateBoard();
        if (useGroupedMines)
        {
            groupMinePlacer.PlaceGroupedMines(cells, width, height, mineCount);
        }
        else
        {
            PlaceMines();
        }
        CalculateNumbers();

        OpenStartingCells(OpenCount); // 초반 공개칸 쓰고 있으면 유지
    }

    private void OpenStartingCells(int count)
    {
        int opened = 0;
        int tryCount = 0;

        while (opened < count && tryCount < 1000)
        {
            tryCount++;

            int x = Random.Range(0, width);
            int y = Random.Range(0, height);

            MineCell cell = cells[x, y];

            if (cell.isMine) continue;
            if (cell.isOpened) continue;
            if (cell.nearbyMineCount == 0) continue; // 0칸 제외

            cell.Open();
            opened++;
        }
    }
    private void CreateBoard()
    {
        cells = new MineCell[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                MineCell cell = Instantiate(cellPrefab, boardParent);
                cell.Init(x, y, this);
                cells[x, y] = cell;
            }
        }
    }

    private void PlaceMines()
    {
        int placed = 0;

        while (placed < mineCount)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);

            if (cells[x, y].isMine) continue;

            cells[x, y].isMine = true;
            placed++;
        }
    }

    private void CalculateNumbers()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (cells[x, y].isMine) continue;

                int count = 0;

                for (int i = 0; i < 8; i++)
                {
                    int nx = x + dx[i];
                    int ny = y + dy[i];

                    if (IsInside(nx, ny) && cells[nx, ny].isMine)
                    {
                        count++;
                    }
                }

                cells[x, y].nearbyMineCount = count;
            }
        }
    }

    public void OpenCell(int x, int y)
    {
        if (gameOver) return;
        if (!IsInside(x, y)) return;

        MineCell cell = cells[x, y];

        if (cell.isOpened || cell.isFlagged) return;

        cell.Open();

        if (cell.isMine)
        {
            GameOver();
            return;
        }

        if (cell.nearbyMineCount == 0)
        {
            OpenAround(x, y);
        }

        CheckClear();
    }

    private void OpenAround(int x, int y)
    {
        for (int i = 0; i < 8; i++)
        {
            int nx = x + dx[i];
            int ny = y + dy[i];

            if (IsInside(nx, ny))
            {
                MineCell next = cells[nx, ny];

                if (!next.isOpened && !next.isMine)
                {
                    OpenCell(nx, ny);
                }
            }
        }
    }

    private void GameOver()
    {
        gameOver = true;
        StartCoroutine(GameOverRoutine());
    }

    private IEnumerator GameOverRoutine()
    {
        foreach (MineCell cell in cells)
        {
            if (cell.isMine)
            {
                cell.Open();
            }
        }

        yield return new WaitForSeconds(1f);

        ResetBoard();
    }
    private void CheckClear()
    {
        int openedCount = 0;

        foreach (MineCell cell in cells)
        {
            if (cell.isOpened)
            {
                openedCount++;
            }
        }

        int safeCellCount = width * height - mineCount;

        if (openedCount >= safeCellCount)
        {
            gameOver = true;
            ClearReward();
        }
    }

    private void ClearReward()
    {
        Debug.Log("클리어!");

        if (rewardObjectSprite != null && clearedSprite != null)
        {
            rewardObjectSprite.sprite = clearedSprite;
        }

        if (rewardObjectCollider != null)
        {
            rewardObjectCollider.enabled = false;
        }
    }

    private bool IsInside(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }
}