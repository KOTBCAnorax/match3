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

    private Vector2[] spawnPoints;

    private void Start()
    {
        GenerateField();
        GenerateTokens();
        PlaceSpawnPoints();
    }

    [ContextMenu("GenerateField")]
    private void GenerateField()
    {
        if (HasChildren(fieldObject.transform))
        {
            return;
        }

        for (int i = 0; i < columsCount; i++)
        {
            for (int j = 0; j < rowsCount; j++)
            {
                Vector2 pos = new Vector2(i, j);
                Instantiate(tilePrefab, pos, Quaternion.identity, fieldObject.transform);
            }
        }
    }

    [ContextMenu("GenerateTokens")]
    private void GenerateTokens()
    {
        if (HasChildren(tokensContainerObject.transform))
        {
            return;
        }

        for (int i = 0; i < columsCount; i++)
        {
            for (int j = 0; j < rowsCount; j++)
            {
                Vector2 pos = new Vector2(i, j);
                Instantiate(tokenPrefab, pos, Quaternion.identity, tokensContainerObject.transform);
            }
        }
    }

    private void PlaceSpawnPoints()
    {
        spawnPoints = new Vector2[columsCount];

        for (int i = 0; i < columsCount; i++)
        {
            spawnPoints[i] = new Vector2(i, rowsCount);
        }
    }

    private bool HasChildren(Transform obj)
    {
        return obj.childCount > 0;
    }
}
