using UnityEngine;

public class Room
{
    public int xPos;                      // The x coordinate of the lower left tile of the room.
    public int yPos;                      // The y coordinate of the lower left tile of the room.
    public int roomWidth;                     // How many tiles wide the room is.
    public int roomHeight;                    // How many tiles high the room is.


    // This is used for the first room.  It does not have a Corridor parameter since there are no corridors yet.
    public void SetupRoom(RangeAttribute widthRange, RangeAttribute heightRange, int columns, int rows)
    {
        // Set a random width and height.
        roomWidth = (int)Random.Range(widthRange.min, widthRange.max);
        roomHeight = (int)Random.Range(heightRange.min, heightRange.max);

        // Set the x and y coordinates so the room is roughly in the middle of the board.
        xPos = Mathf.RoundToInt(columns / 2f - roomWidth / 2f);
        yPos = Mathf.RoundToInt(rows / 2f - roomHeight / 2f);

    }
}