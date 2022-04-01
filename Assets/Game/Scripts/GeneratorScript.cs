using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    [SerializeField] private int ROWS_COUNT = 7;
    [SerializeField] private int COLUMNS_COUNT = 6;

    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private GameObject tokenPrefab;
    [SerializeField] private GameObject fieldObject;
    [SerializeField] private GameObject tokensContainerObject;

    private void Start()
    {
        GenerateField();
        GenerateTokens();
    }

    [ContextMenu("GenerateField")]
    private void GenerateField()
    {
        if (HasChildren(fieldObject.transform))
        {
            return;
        }

        for (int i = 0; i < COLUMNS_COUNT; i++)
        {
            for (int j = 0; j < ROWS_COUNT; j++)
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

        for (int i = 0; i < COLUMNS_COUNT; i++)
        {
            Vector3 pos = new Vector3(i, TopRowId(), 0);
            Instantiate(tokenPrefab, pos, Quaternion.identity, tokensContainerObject.transform);
        }
    }

    private bool HasChildren(Transform obj)
    {
        return obj.childCount > 0;
    }

    private int TopRowId()
    {
        return ROWS_COUNT - 1;
    }
}
