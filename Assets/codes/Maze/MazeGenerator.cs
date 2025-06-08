using UnityEngine;
using System.Collections.Generic;

public class MazeGenerator : MonoBehaviour
{
    public int width = 80;
    public int height = 40;
    public GameObject wallPrefab;
    public float cellSize = 1f;

    int[,] maze;
    Vector2Int[] dirs = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };

    void Start()
    {
        maze = new int[width, height];

        // Užpildome visą labirintą sienomis
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                maze[x, y] = 1;

        // Paleidžiam carving funkciją nuo (1,1)
        Carve(1, 1);

        // Atidarom įėjimą ir išėjimą apačioje
        maze[1, 0] = 0;                // Įėjimas kairėje apačioje
        maze[width - 2, 0] = 0;       // Išėjimas dešinėje apačioje

        // Užtikrinam, kad viršutinė siena būtų uždaryta (y = height-1), visas sienas paliekam
        for (int x = 0; x < width; x++)
            maze[x, height - 1] = 1;

        // Uždarom sieną dešinėje pusėje (x = width-1)
        for (int y = 0; y < height; y++)
            maze[width - 1, y] = 1;

        Draw();
    }

    void Carve(int x, int y)
    {
        maze[x, y] = 0;
        var directions = new List<Vector2Int>(dirs);

        // Išmaišome kryptis
        for (int i = 0; i < directions.Count; i++)
        {
            int r = Random.Range(i, directions.Count);
            (directions[i], directions[r]) = (directions[r], directions[i]);
        }

        foreach (var d in directions)
        {
            int nx = x + d.x * 2;
            int ny = y + d.y * 2;

            if (nx > 0 && nx < width - 1 && ny > 0 && ny < height - 1 && maze[nx, ny] == 1)
            {
                maze[x + d.x, y + d.y] = 0;
                Carve(nx, ny);
            }
        }
    }

    void Draw()
    {
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                if (maze[x, y] == 1)
                    Instantiate(wallPrefab, new Vector3(x * cellSize, y * cellSize, 0), Quaternion.identity, transform);
    }
}
