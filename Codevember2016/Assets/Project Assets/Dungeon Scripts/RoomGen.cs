﻿using UnityEngine;
using System.Collections;

public class RoomGen : MonoBehaviour
{
    // The type of tile that will be laid in a specific position.
    public enum TileType
    {
        Wall, Floor
    }

    // The type of Event that will be laid in a specific position.
    public enum EventType
    {
        Enemy, Exit
    }

    public int columns = 10, rows = 10; //The number of rows and columns for the tiles (How many Tiles)

    public RangeAttribute roomWidth = new RangeAttribute(7, 10);
    public RangeAttribute roomHeight = new RangeAttribute(7, 10);

    public int enemyCount;

    public GameObject[] floorTiles;                           // An array of floor tile prefabs.
    public GameObject[] wallTiles;                            // An array of wall tile prefabs.
    public GameObject[] outerWallTiles;                       // An array of outer wall tile prefabs.
    public GameObject[] enemies;                              // An array of the random enemies that can appear
    public GameObject exitSign;
    public GameObject player;
    public Room room;

    private TileType[][] tiles;                               // A jagged array of tile types representing the board, like a grid.
    private EventType[][] events;                               // A jagged array of tile types representing the board, like a grid.
    private GameObject boardHolder;                           // GameObject that acts as a container for all other tiles.

    private void Start()
    {
        // Create the board holder.
        boardHolder = new GameObject("BoardHolder");

        SetupTilesArray();

        CreateRoom();

        SetTileValues();

        InstantiateTiles();

        InstantiateOuterWalls();
    }

    /// <summary>
    /// Creates an empty Tile array
    /// </summary>
    void SetupTilesArray()
    {
        // Set the tiles jagged array to the correct width.
        tiles = new TileType[columns][];

        // Go through all the tile arrays...
        for (int i = 0; i < tiles.Length; i++)
        {
            // ... and set each tile array is the correct height.
            tiles[i] = new TileType[rows];
        }
    }

    /// <summary>
    /// Creates and Sets up the Room
    /// </summary>
    void CreateRoom()
    {
        room = new Room();
        room.SetupRoom(roomWidth, roomHeight, columns, rows);

        Vector3 playerPos = new Vector3(room.xPos, room.yPos, 0);
        Instantiate(player, playerPos, Quaternion.identity);
    }

    void SetTileValues()
    {
        // ... and for each room go through it's width.
        for (int i = 0; i < room.roomWidth; i++)
        {
            int xCoord = room.xPos + i;

            // For each horizontal tile, go up vertically through the room's height.
            for (int j = 0; j < room.roomHeight; j++)
            {
                int yCoord = room.yPos + j;

                // The coordinates in the jagged array are based on the room's position and it's width and height.
                tiles[xCoord][yCoord] = TileType.Floor;
            }
        }
    }

    void SetEvent()
    {
        // ... and for each room go through it's width.
        for (int i = 0; i < room.roomWidth; i++)
        {
            int xCoord = room.xPos + i;

            // For each horizontal tile, go up vertically through the room's height.
            for (int j = 0; j < room.roomHeight; j++)
            {
                int yCoord = room.yPos + j;

                // The coordinates in the jagged array are based on the room's position and it's width and height.
                tiles[xCoord][yCoord] = TileType.Floor;
            }
        }
    }

    void InstantiateTiles()
    {
        // Go through all the tiles in the jagged array...
        for (int i = 0; i < tiles.Length; i++)
        {
            for (int j = 0; j < tiles[i].Length; j++)
            {
                // ... and instantiate a floor tile for it.
                InstantiateFromArray(floorTiles, i, j);

                // If the tile type is Wall...
                if (tiles[i][j] == TileType.Wall)
                {
                    // ... instantiate a wall over the top.
                    InstantiateFromArray(wallTiles, i, j);
                }
            }
        }
    }

    void InstantiateOuterWalls()
    {
        // The outer walls are one unit left, right, up and down from the board.
        float leftEdgeX = -1f;
        float rightEdgeX = columns + 0f;
        float bottomEdgeY = -1f;
        float topEdgeY = rows + 0f;

        // Instantiate both vertical walls (one on each side).
        InstantiateVerticalOuterWall(leftEdgeX, bottomEdgeY, topEdgeY);
        InstantiateVerticalOuterWall(rightEdgeX, bottomEdgeY, topEdgeY);

        // Instantiate both horizontal walls, these are one in left and right from the outer walls.
        InstantiateHorizontalOuterWall(leftEdgeX + 1f, rightEdgeX - 1f, bottomEdgeY);
        InstantiateHorizontalOuterWall(leftEdgeX + 1f, rightEdgeX - 1f, topEdgeY);
    }

    void InstantiateVerticalOuterWall(float xCoord, float startingY, float endingY)
    {
        // Start the loop at the starting value for Y.
        float currentY = startingY;

        // While the value for Y is less than the end value...
        while (currentY <= endingY)
        {
            // ... instantiate an outer wall tile at the x coordinate and the current y coordinate.
            InstantiateFromArray(outerWallTiles, xCoord, currentY);

            currentY++;
        }
    }

    void InstantiateHorizontalOuterWall(float startingX, float endingX, float yCoord)
    {
        // Start the loop at the starting value for X.
        float currentX = startingX;

        // While the value for X is less than the end value...
        while (currentX <= endingX)
        {
            // ... instantiate an outer wall tile at the y coordinate and the current x coordinate.
            InstantiateFromArray(outerWallTiles, currentX, yCoord);

            currentX++;
        }
    }

    void InstantiateFromArray(GameObject[] prefabs, float xCoord, float yCoord)
    {
        // Create a random index for the array.
        int randomIndex = Random.Range(0, prefabs.Length);

        // The position to be instantiated at is based on the coordinates.
        Vector3 position = new Vector3(xCoord, yCoord, 0f);

        // Create an instance of the prefab from the random index of the array.
        GameObject tileInstance = Instantiate(prefabs[randomIndex], position, Quaternion.identity) as GameObject;

        // Set the tile's parent to the board holder.
        tileInstance.transform.parent = boardHolder.transform;
    }
}
