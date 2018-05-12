using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Ground", menuName = "Scriptable Objects/Natural Ground")]
public class NaturalGround : Tile
{
    public Condition MyCondition;
    [SerializeField] private NaturalGround[] _groundAssetsOfOtherConditions;
    public Crop MyCrop;

    public bool CanPlant
    {
        get
        {
            return MyCondition == Condition.Tilled;
        }
    }

    public void Till(Vector3Int coordinates, Tilemap tilemap)
    {
        tilemap.SetTile(coordinates, GroundWithCondition(Condition.Tilled));
    }

    public void Plant(Crop crop, Vector3Int coordinates, Tilemap tilemap)
    {
        Debug.Log("Being planted with " + crop.CropType + " at coordinates " + coordinates);
        tilemap.SetTile(coordinates, GroundWithCrop(crop));
    }

    private NaturalGround GroundWithCrop(Crop targetCrop)
    {
        if(MyCrop != null && MyCrop == targetCrop)
        {
            return this;
        }
        for (int i = 0; i < _groundAssetsOfOtherConditions.Length; i++)
        {
            if (_groundAssetsOfOtherConditions[i].MyCrop == targetCrop)
            {
                return _groundAssetsOfOtherConditions[i];
            }
        }
        throw new System.Exception("No NaturalGround Tile found with Crop " + targetCrop);
    }

    private NaturalGround GroundWithCondition(Condition targetCondition)
    {
        if (MyCondition == targetCondition)
        {
            return this;
        }
        for (int i = 0; i < _groundAssetsOfOtherConditions.Length; i++)
        {
            if (_groundAssetsOfOtherConditions[i].MyCondition == targetCondition)
            {
                return _groundAssetsOfOtherConditions[i];
            }
        }
        throw new System.Exception("No NaturalGround Tile found with Condition " + targetCondition);
    }

    public enum Condition
    {
        Compacted,
        Tilled,
        Seeded
    }
}
