using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenScript : MonoBehaviour
{
    [SerializeField] Sprite[] Colors;
    [SerializeField] SpriteRenderer mySpriteRenderer;

    private void Start()
    {
        PickColor();
    }

    private void PickColor()
    {
        int colorId = Random.Range(0, Colors.Length);
        mySpriteRenderer.sprite = Colors[colorId];
        AssignTag(colorId);
    }

    private void AssignTag(int colorId)
    {
        switch (colorId)
        {
            case 0:
                gameObject.tag = "blue";
                break;
            case 1:
                gameObject.tag = "green";
                break;
            case 2:
                gameObject.tag = "orange";
                break;
            case 3:
                gameObject.tag = "purple";
                break;
            case 4:
                gameObject.tag = "red";
                break;
            case 5:
                gameObject.tag = "yellow";
                break;
        }
    }
}
