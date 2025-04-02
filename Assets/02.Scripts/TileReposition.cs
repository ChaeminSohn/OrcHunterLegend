using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileReposition : MonoBehaviour
{
    private Transform player;

    public Transform[] tileMaps;
    private Vector2 tileSize = new Vector2(20, 20); //타일맵 크기

    void Start()
    {
        player = FindFirstObjectByType<PlayerMove>().transform;
    }

    void Update()
    {
        foreach (Transform tilemap in tileMaps)
        {
            Vector2 playerOffset = player.position - tilemap.position;
            Vector2 newPosition = tilemap.position;
            if (Mathf.Abs(playerOffset.x) > tileSize.x)
            {
                newPosition.x += Math.Sign(playerOffset.x) * tileSize.x * 2;
            }
            if (Mathf.Abs(playerOffset.y) > tileSize.y)
            {
                newPosition.y += Math.Sign(playerOffset.y) * tileSize.y * 2;
            }
            tilemap.position = newPosition;


        }
    }
}
