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

    private void Start()
    {
        GenerateField();
        GenerateTokens();
        GenerateSpawnPoints();
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
                Vector3 pos = new Vector3(i, j, 0);
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

        int topRowId = rowsCount - 1;

        for (int i = 0; i < columsCount; i++)
        {
            Vector3 pos = new Vector3(i, topRowId, 0);
            Instantiate(tokenPrefab, pos, Quaternion.identity, tokensContainerObject.transform);
        }
    }

    private void GenerateSpawnPoints()
    {

    }

    private bool HasChildren(Transform obj)
    {
        return obj.childCount > 0;
    }
}
