using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use this class to access data about the room the player is currently in.
/// </summary>
public class RoomManager : MonoBehaviour
{
    private FogOfWar current_room;

    /// <summary>
    /// Updates the current room.
    /// </summary>
    /// <param name="room">The GameObject of the room the player has entered.</param>
    public void setCurrentRoom(FogOfWar room)
    {
        current_room = room;
    }

    /// <summary>
    /// Gets the current room.
    /// </summary>
    /// <returns>
    /// A GameObject which contains data about the current room (data is in the FogOfWar component).
    /// </returns>
    public FogOfWar getCurrentRoom()
    {
        return current_room;
    }

   
}
