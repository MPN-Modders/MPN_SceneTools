using UnityEngine;
using System.Collections.Generic;


public class Zone_Spawner : AreaZone
{
    [Space(10)]
    [Tooltip("List of character markers to set SpawnEnabled to true when the player enters the zone.")]
    public List<Marker_Character> EnableCharacters = new List<Marker_Character>();

    [Tooltip("Frames that must pass between the previous and next character spawn.")]
    public float SpawnBuffer = 10;
}