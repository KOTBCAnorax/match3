using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorScript: MonoBehaviour
{
    [SerializeField] private int rowsCount = 7;
    [SerializeField] private int columsCount = 6;

    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private GameObject tokenPrefab;
    [SerializeField] private GameObject fieldObject;
    [SerializeField] private GameObject tokensContainerObject;

    public bool[,] grid;

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
        if (HasChildren(fieldObject.transform))
        {
            return;
        }

        grid = new bool[columsCount, rowsCount];

        for (int i = 0; i < columsCount; i++)
        {
            for (int j = 0; j < rowsCount; j++)
            {
                Vector2 pos = new Vector2(i, j);
                GameObject tile = 
                    Instantiate(tilePrefab, pos, Quaternion.identity, fieldObject.transform);

                grid[i, j] = false;
            }
        }
    }

    private void SpawnTokens()
    {
        int topRow = rowsCount - 1;

        for (int i = 0; i < columsCount; i++)
        {
            if (!grid[i, topRow])
            {
                Vector2 pos = new Vector2(i, topRow);
                GameObject token =
                    Instantiate(tokenPrefab, pos, Quaternion.identity, 
                                tokensContainerObject.transform);

                grid[i, topRow] = true;
            }
        }
    }

    private bool HasChildren(Transform obj)
    {
        return obj.childCount > 0;
    }
}
