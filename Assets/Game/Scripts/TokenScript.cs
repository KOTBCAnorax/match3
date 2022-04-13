using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenScript : MonoBehaviour
{
    [SerializeField] Sprite[] Colors;
    [SerializeField] SpriteRenderer mySpriteRenderer;
    [SerializeField] SpriteRenderer myBackgroundRenderer;

    private float speed = 10f;
    private Vector2Int myPosition;
    private Vector2Int tileBelowPosition;
    private DirectorScript directorRef;

    public void Setup(GameObject director)
    {
        myBackgroundRenderer.enabled = false;
        PickColor();
        directorRef = director.GetComponent<DirectorScript>();
        myPosition = Vector2Int.RoundToInt(transform.position);
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
    }

    private void FindTileBelowPosition()
    {
        tileBelowPosition.x = myPosition.x;
        tileBelowPosition.y = (myPosition.y - 1 >= 0) ? (myPosition.y - 1) : 0;
    }

    private void Fall()
    {
        if (Mathf.Ceil(transform.position.y) == tileBelowPosition.y)
        {
            UpdatePosition();
        }
        
        if (!TileBelowIsOccupied())
        {
            transform.position =
            Vector2.MoveTowards(transform.position, tileBelowPosition,
                                speed * Time.deltaTime);
        }
    }

    private void UpdatePosition()
    {
        directorRef.SetTileEmpty(myPosition.x, myPosition.y);
        directorRef.SetTileOccupied(tileBelowPosition.x, tileBelowPosition.y);

        myPosition.y = tileBelowPosition.y;
        tileBelowPosition.y = (myPosition.y - 1 >= 0) ? (myPosition.y - 1) : 0;
    }

    private bool TileBelowIsOccupied()
    {
        return directorRef.TileIsOccupied(tileBelowPosition.x, tileBelowPosition.y);
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
        directorRef.SetTileEmpty(myPosition.x, myPosition.y);
        Destroy(gameObject);
    }
}
