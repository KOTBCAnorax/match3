using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenScript : MonoBehaviour
{
    [SerializeField] Sprite[] tokenSpriteVariants;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] SpriteRenderer highlightRenderer;

    private float movementSpeed = 10f;
    private Vector2Int gridCoordinates;
    private Vector2Int tileBelowCoordinates;
    private DirectorScript director;

    public void Setup(DirectorScript directorScript)
    {
        highlightRenderer.enabled = false;
        PickColor();
        director = directorScript;
        gridCoordinates = Vector2Int.RoundToInt(transform.position);
        FindTileBelowPosition();
    }

    private void Update()
    {
        Move();
    }

    private void PickColor()
    {
        int colorId = Random.Range(0, tokenSpriteVariants.Length);
        spriteRenderer.sprite = tokenSpriteVariants[colorId];
    }

    private void FindTileBelowPosition()
    {
        tileBelowCoordinates.x = gridCoordinates.x;
        tileBelowCoordinates.y = (gridCoordinates.y - 1 >= 0) ? (gridCoordinates.y - 1) : 0;
    }

    private void Move()
    {
        if (Mathf.Ceil(transform.position.y) == tileBelowCoordinates.y)
        {
            UpdatePositionOnFallComplete();
        }
        
        if (!IsTileBelowOccupied())
        {
            transform.position =
            Vector2.MoveTowards(transform.position, tileBelowCoordinates,
                                movementSpeed * Time.deltaTime);
        }
    }

    private void UpdatePositionOnFallComplete()
    {
        director.SetTileEmpty(gridCoordinates.x, gridCoordinates.y);
        director.SetTileOccupied(tileBelowCoordinates.x, tileBelowCoordinates.y);

        gridCoordinates.y = tileBelowCoordinates.y;
        tileBelowCoordinates.y = Mathf.Max(gridCoordinates.y - 1, 0);
    }

    private bool IsTileBelowOccupied()
    {
        return director.IsTileOccupied(tileBelowCoordinates.x, tileBelowCoordinates.y);
    }

    private void OnMouseEnter()
    {
        highlightRenderer.enabled = true;
    }

    private void OnMouseExit()
    {
        highlightRenderer.enabled = false;
    }

    private void OnMouseUp()
    {
        director.SetTileEmpty(gridCoordinates.x, gridCoordinates.y);
        Destroy(gameObject);
    }
}
