using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorScript: MonoBehaviour
{
    [SerializeField] private int rowsCount = 7;
    [SerializeField] private int columsCount = 6;

    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private TokenScript tokenPrefab;
    [SerializeField] private Transform fieldObject;
    [SerializeField] private Transform tokensContainerObject;

    private bool[,] occupiedTilesGrid;

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

        occupiedTilesGrid = new bool[columsCount, rowsCount];

        for (int i = 0; i < columsCount; i++)
        {
            for (int j = 0; j < rowsCount; j++)
            {
                Vector2 pos = new Vector2(i, j);
                Instantiate(tilePrefab, pos, Quaternion.identity, fieldObject);

                SetTileEmpty(i, j);
            }
        }
    }

    private void SpawnTokens()
    {
        int topRow = rowsCount - 1;

        for (int i = 0; i < columsCount; i++)
        {
            if (!IsTileOccupied(i, topRow))
            {
                Vector2 pos = new Vector2(i, topRow);
                Instantiate(tokenPrefab, pos, Quaternion.identity, 
                    tokensContainerObject).Setup(this);

                SetTileOccupied(i, topRow);
            }
        }
    }

    private bool HasChildren(Transform obj)
    {
        return obj.childCount > 0;
    }

    public bool IsTileOccupied(int column, int row)
    {
        return occupiedTilesGrid[column, row];
    }

    public void SetTileEmpty(int column, int row)
    {
        occupiedTilesGrid[column, row] = false;
    }

    public void SetTileOccupied(int column, int row)
    {
        occupiedTilesGrid[column, row] = true;
    }
}
