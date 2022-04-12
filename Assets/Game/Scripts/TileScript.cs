using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    private DirectorScript director;

    private void Start()
    {
        director = GameObject.Find("Director").GetComponent<DirectorScript>();
    }

    // Debug
    private void OnMouseUp()
    {
        Debug.Log(director.grid[(int)transform.position.x, (int)transform.position.y]);
    }
}
