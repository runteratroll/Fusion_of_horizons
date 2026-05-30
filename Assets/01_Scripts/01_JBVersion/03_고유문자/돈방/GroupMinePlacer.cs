using UnityEngine;

public class GroupMinePlacer : MonoBehaviour
{
    [SerializeField] private MineSweeperManager manager;

    private readonly Vector2Int[][] groupShapes =
    {
        new Vector2Int[] { new(0,0), new(1,0), new(0,1), new(1,1) }, // 네모
        new Vector2Int[] { new(0,0), new(1,0), new(2,0), new(3,0) }, // 가로
        new Vector2Int[] { new(0,0), new(0,1), new(0,2), new(0,3) }, // 세로
        new Vector2Int[] { new(0,0), new(0,1), new(0,2), new(1,2) }, // ㄴ
        new Vector2Int[] { new(0,0), new(1,0), new(2,0), new(1,1) }, // T
    };

    public void PlaceGroupedMines(MineCell[,] cells, int width, int height, int mineCount)
    {
        if (mineCount % 4 != 0)
        {
            Debug.LogError("4개 그룹 지뢰는 mineCount가 4의 배수여야 함");
            return;
        }

        int targetGroupCount = mineCount / 4;
        int placedGroupCount = 0;
        int tryCount = 0;

        while (placedGroupCount < targetGroupCount && tryCount < 5000)
        {
            tryCount++;

            Vector2Int[] shape = groupShapes[Random.Range(0, groupShapes.Length)];

            int startX = Random.Range(0, width);
            int startY = Random.Range(0, height);

            if (!CanPlace(cells, width, height, startX, startY, shape))
                continue;

            Place(cells, startX, startY, shape);
            placedGroupCount++;
        }

        if (placedGroupCount < targetGroupCount)
        {
            Debug.LogWarning("4개 그룹 지뢰를 전부 배치하지 못함");
        }
    }

    private bool CanPlace(
        MineCell[,] cells,
        int width,
        int height,
        int startX,
        int startY,
        Vector2Int[] shape)
    {
        foreach (Vector2Int offset in shape)
        {
            int x = startX + offset.x;
            int y = startY + offset.y;

            if (x < 0 || x >= width || y < 0 || y >= height)
                return false;

            if (cells[x, y].isMine)
                return false;
        }

        return true;
    }

    private void Place(
        MineCell[,] cells,
        int startX,
        int startY,
        Vector2Int[] shape)
    {
        foreach (Vector2Int offset in shape)
        {
            int x = startX + offset.x;
            int y = startY + offset.y;

            cells[x, y].isMine = true;
        }
    }
}