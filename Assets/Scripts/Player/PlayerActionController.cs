
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerActionController : CardinalMovementHandler
{
    [SerializeField] private Tilemap _soilMap;
    [SerializeField] private Transform _feet;
    [SerializeField] private GameObject _tillEffect;
    private Vector3 _offset;

    public override void HandleMovement(CardinalDirection direction, float xMovement, float yMovement)
    {
        switch(direction)
        {
            case CardinalDirection.North:
                _offset = Vector3.up;
                break;
            case CardinalDirection.East:
                _offset = Vector3.right;
                break;
            case CardinalDirection.South:
                _offset = Vector3.down;
                break;
            case CardinalDirection.West:
                _offset = Vector3.left;
                break;
            default:
                throw new System.ArgumentException("No case defined in HandleMovement() for " + direction);
        }
    }

    public void TillTheSoil()
    {
        Vector3 tilledPosition = _feet.position + _offset;
        Vector3Int cellToTill = _soilMap.WorldToCell(tilledPosition);
        NaturalGround groundTile = _soilMap.GetTile<NaturalGround>(cellToTill);
        if(groundTile != null)
        {
            Instantiate(_tillEffect, tilledPosition + new Vector3(0f, 0f, -6f), _tillEffect.transform.rotation);
            groundTile.Till(cellToTill, _soilMap);
        }
    }
}