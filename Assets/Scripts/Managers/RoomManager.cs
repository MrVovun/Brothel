using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviourSingleton<RoomManager> {
    public Room[] Rooms;
    
    public Room FindRoom() {
        foreach (Room room in Rooms) {
            if (!room.IsOccupied()) {
                return room;
            }
        }

        return null;
    }
}