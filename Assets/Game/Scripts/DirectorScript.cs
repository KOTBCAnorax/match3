using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorScript: MonoBehaviour
{
    [SerializeField] private int rowsCount = 7;
    [SerializeField] private int columsCount = 6;

    [SerializeField] private TileScript tilePrefab;
    [SerializeField] private TokenScript tokenPrefab;
    [SerializeField] private Transform fieldObject;
    [SerializeField] private Transform tokensContainerObject;

    private bool[,] grid;

    private void Start()
    {
        GenerateField();
        SpawnTokens();
    }

    private void Update()
    {
        SpawnTokens();
    }

    private void GenerateField()
    {
        if (HasChildren(fieldObject))
        {
            return;
        }

        grid = new bool[columsCount, rowsCount];

        for (int i = 0; i < columsCount; i++)
        {
            for (int j = 0; j < rowsCount; j++)
            {
                Vector2 pos = new Vector2(i, j);
                Instantiate(tilePrefab, pos, Quaternion.identity, fieldObject);

                grid[i, j] = false;
            }
        }
    }

    private void SpawnTokens()
    {
        int topRow = rowsCount - 1;

        for (int i = 0; i < columsCount; i++)
        {
            if (!TileIsOccupied(i, topRow))
            {
                Vector2 pos = new Vector2(i, topRow);
                Instantiate(tokenPrefab, pos, Quaternion.identity, 
                    tokensContainerObject).Setup(gameObject);

                grid[i, topRow] = true;
            }
        }
    }

    private bool HasChildren(Transform obj)
    {
        return obj.childCount > 0;
    }

    public bool TileIsOccupied(int column, int row)
    {
        return grid[column, row];
    }

    public void SetTileEmpty(int column, int row)
    {
        grid[column, row] = false;
    }

    public void SetTileOccupied(int column, int row)
    {
        grid[column, row] = true;
    }
}
