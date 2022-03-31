using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    const int rows = 7;
    const int cols = 6;
    const int topRow = rows - 1;

    [SerializeField] GameObject tilePrefab;
    [SerializeField] GameObject tokenPrefab;
    [SerializeField] GameObject fieldObject;
    [SerializeField] GameObject tokensContainerObject;

    [ContextMenu("GenerateField")]
    void GenerateField()
    {
        if (HasChildren(fieldObject.transform))
        {
            return;
        }

        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Vector3 pos = new Vector3(i, j, 0);
                GameObject newTile = Instantiate(tilePrefab, pos, Quaternion.identity);
                newTile.transform.parent = fieldObject.transform;
            }
        }
    }

    [ContextMenu("GenerateTokens")]
    void GenerateTokens()
    {
        if (HasChildren(tokensContainerObject.transform))
        {
            return;
        }

        for (int i = 0; i < cols; i++)
        {
            Vector3 pos = new Vector3(i, topRow, 0);
            GameObject newToken = Instantiate(tokenPrefab, pos, Quaternion.identity);
            newToken.transform.parent = tokensContainerObject.transform;
        }
    }

    bool HasChildren(Transform obj)
    {
        return obj.childCount > 0;
    }
}
