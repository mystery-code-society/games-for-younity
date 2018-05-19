using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SeedPacket : FarmTool
{
    [SerializeField] private Crop _crop;

    public override void UseTool(PlayerAnimationView animationView, Vector3 targetPosition, Tilemap soilMap, Action callback)
    {
        Debug.Log("Trying to plant seeds!");
        Vector3Int cellToPlant = soilMap.WorldToCell(targetPosition);
        NaturalGround groundTile = soilMap.GetTile<NaturalGround>(cellToPlant);
        if(groundTile != null && groundTile.CanPlant)
        {
            groundTile.Plant(_crop, cellToPlant, soilMap);
        }
        callback();
    }
}
