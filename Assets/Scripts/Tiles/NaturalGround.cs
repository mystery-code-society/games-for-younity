using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName ="Ground", menuName ="Scriptable Objects/Natural Ground")]
public class NaturalGround : Tile
{
    public Condition MyCondition;
    [SerializeField] private NaturalGround[] _groundAssetsOfOtherConditions;
    
    public void Till(Vector3Int coordinates, Tilemap tilemap)
    {
        tilemap.SetTile(coordinates, GroundWithCondition(Condition.Tilled));
    }

    private NaturalGround GroundWithCondition(Condition targetCondition)
    {
        if(MyCondition == targetCondition)
        {
            return this;
        }
        for(int i = 0; i < _groundAssetsOfOtherConditions.Length; i++)
        {
            if(_groundAssetsOfOtherConditions[i].MyCondition == targetCondition)
            {
                return _groundAssetsOfOtherConditions[i];
            }
        }
        throw new System.Exception("No NaturalGround Tile found with Condition " + targetCondition);
    }

    public enum Condition
    {
        Compacted,
        Tilled
    }
}
