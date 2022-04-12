using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenScript : MonoBehaviour
{
    [SerializeField] Sprite[] Colors;
    [SerializeField] SpriteRenderer mySpriteRenderer;
    [SerializeField] SpriteRenderer myBackgroundRenderer;

    public Vector2 lowestEmptyTile;

    private float speed = 10f;
    private int[] myPosition; // 1-d array of 2
    private int[] tileBelowPosition; // 1-d array of 2
    private DirectorScript director;

    private void Start()
    {
        myBackgroundRenderer.enabled = false;
        PickColor();
        director = GameObject.Find("Director").GetComponent<DirectorScript>();
        myPosition = new int[] {Mathf.RoundToInt(transform.position.x),
                                Mathf.RoundToInt(transform.position.y)};
        FindTileBelowPosition();
    }

    private void Update()
    {
        Fall();
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

    private void FindTileBelowPosition()
    {
        tileBelowPosition = new int[2];
        tileBelowPosition[0] = myPosition[0];
        tileBelowPosition[1] = (myPosition[1] - 1 >= 0) ? (myPosition[1] - 1) : 0;
    }

    private void Fall()
    {
        if (Mathf.Ceil(transform.position.y) == tileBelowPosition[1])
        {
            UpdatePosition();
        }
        
        if (TileBelowIsEmpty())
        {
            transform.position =
            Vector3.MoveTowards(transform.position, ArrayToVector(tileBelowPosition),
                                speed * Time.deltaTime);
        }
    }

    private void UpdatePosition()
    {
        director.grid[myPosition[0], myPosition[1]] = false;
        director.grid[tileBelowPosition[0], tileBelowPosition[1]] = true;

        myPosition[1] = tileBelowPosition[1];
        tileBelowPosition[1] = (myPosition[1] - 1 >= 0) ? (myPosition[1] - 1) : 0;
    }

    private bool TileBelowIsEmpty()
    {
        return !director.grid[tileBelowPosition[0], tileBelowPosition[1]];
    }

    private Vector3 ArrayToVector(int[] twoDimensionalArray)
    {
        return new Vector3(twoDimensionalArray[0], twoDimensionalArray[1], 0);
    }

    private void OnMouseEnter()
    {
        myBackgroundRenderer.enabled = true;
    }

    private void OnMouseExit()
    {
        myBackgroundRenderer.enabled = false;
    }

    //Debug
    private void OnMouseUp()
    {
        director.grid[myPosition[0], myPosition[1]] = false;
        Destroy(gameObject);
    }
}
