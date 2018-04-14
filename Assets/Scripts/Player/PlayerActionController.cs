
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerActionController : MonoBehaviour
{
    [SerializeField] private Tilemap _soilMap;
    [SerializeField] private Transform _feetPosition;

    public void TillTheSoil()
    {
        Vector3Int cellPlayerIsStandingIn = _soilMap.WorldToCell(_feetPosition.position);
        NaturalGround groundTile = _soilMap.GetTile<NaturalGround>(cellPlayerIsStandingIn);
        if(groundTile != null)
        {
            groundTile.Till(cellPlayerIsStandingIn, _soilMap);
        }
    }
}