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
                GameObject newTile =
                    Instantiate(tilePrefab,
                    new Vector3(i, 0, j),
                    Quaternion.identity);

                MeshRenderer tileRenderer =
                    newTile.GetComponent<MeshRenderer>();
                tilesColliders.Add(newTile.GetComponent<Collider>());
                if (i % 2 == 0 && j % 2 == 0)
                    tileRenderer.material.color = Color.yellow;
                else if (j % 2 == 1 && i % 2 == 1)
                    tileRenderer.material.color = Color.yellow;
                else
                    tileRenderer.material.color = Color.green;
            }
        }
    }
}
