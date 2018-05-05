using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerActionController : CardinalMovementHandler
{
    [SerializeField] private Tilemap _soilMap;
    [SerializeField] private Transform _feet;
    [SerializeField] private PlayerAnimationView _animationView;
    [SerializeField] private PlayerToolbox _toolbox;
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

    public void UseEquippedTool(System.Action callback)
    {
        _toolbox.UseEquippedTool(_animationView, _feet.position + _offset, callback);
    }

    public void EquipNextTool()
    {
        _toolbox.EquipNextTool();
    }
}