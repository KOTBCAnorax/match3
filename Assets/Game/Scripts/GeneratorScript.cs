using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    const int rows = 7;
    const int cols = 6;
    const int topRow = rows - 1;

    GameObject[,] field;
    GameObject[,] tokens;

    [SerializeField] GameObject tilePrefab;
    [SerializeField] GameObject tokenPrefab;
    [SerializeField] GameObject fieldObject;
    [SerializeField] GameObject tokensContainerObject;

    [ContextMenu("GenerateField")]
    [ContextMenu("GenerateTokens")]

    void Start()
    {
         field = new GameObject[cols, rows];
         tokens = new GameObject[cols, rows];
         
         GenerateField();
         GenerateTokens();
    }

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
                field[i,j] = Instantiate(tilePrefab, pos, Quaternion.identity);
                field[i,j].transform.parent = fieldObject.transform;
            }
        }
    }

    void GenerateTokens()
    {
        if (HasChildren(tokensContainerObject.transform))
        {
            return;
        }

        for (int i = 0; i < cols; i++)
        {
            Vector3 pos = new Vector3(i, topRow, 0);
            tokens[i, topRow] = Instantiate(tokenPrefab, pos, Quaternion.identity);
            tokens[i, topRow].transform.parent = tokensContainerObject.transform;
        }
    }

    bool HasChildren(Transform obj)
    {
        return obj.childCount > 0;
    }
}
