using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    [SerializeField] Sprite normalSprite;
    [SerializeField] Sprite higlihtedSprite;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] public GameObject myToken;

    private void OnMouseOver()
    {
        sr.sprite = higlihtedSprite;
    }

    private void OnMouseExit()
    {
        sr.sprite = normalSprite;
    }
}
