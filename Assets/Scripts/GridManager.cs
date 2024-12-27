using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject tilePrefab;
    private GameObject[,] grid = new GameObject[9,9];
    
    void Start()
    {
        CreateGrid();
    }
    
    void CreateGrid()
    {
        for (int x = 0; x < 9; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                Vector3 position = new Vector3(x, y, 0);
                grid[x,y] = Instantiate(tilePrefab, position, Quaternion.identity);
            }
        }
    }
}
