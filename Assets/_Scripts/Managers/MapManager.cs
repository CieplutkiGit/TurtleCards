using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    public int fieldsX;

    public int fieldsZ;

    public GameObject tilePrefab;

    public List<Collider> tilesColliders;

    public void GenerateMap()
    {
        for (int i = 0; i < fieldsX; i++)
        {
            for (int j = 0; j < fieldsZ; j++)
            {
                GameObject newTile = Instantiate(tilePrefab, new Vector3(i, 0,j), Quaternion.identity);
                tilesColliders.Add(newTile.GetComponent<Collider>());
            }
        }
    }
}
