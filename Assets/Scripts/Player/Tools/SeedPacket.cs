using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SeedPacket : FarmTool
{
    public override void UseTool(PlayerAnimationView animationView, Vector3 targetPosition, Tilemap soilmap, Action callback)
    {
        Debug.Log("Planting seeds!");
        callback();
    }
}
