using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyHalfOfTilemap : MonoBehaviour
{
    public Tilemap tilemap;

    public void RemoveTilesInArea(Vector3Int position, Vector3Int size)
    {
        for (int x = position.x; x < position.x + size.x; x++)
            for (int y = position.y; y < position.y + size.y; y++)
                tilemap.SetTile(new Vector3Int(x, y, 0), null); 
    }
}

