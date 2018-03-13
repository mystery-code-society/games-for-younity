using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : CardinalMovementHandler
{
    public float Speed;
    public BoxCollider2D WalkableArea;

    public override void HandleMovement(CardinalDirection direction, float xMovement, float yMovement)
    {
        Vector3 position = transform.position + new Vector3(xMovement, yMovement, 0f) * Time.deltaTime * Speed;
        transform.position = WalkableArea.bounds.ClosestPoint(position);
    }

    private Vector3 ConstrainToWalkableArea(Vector3 position)
    {
        if(WalkableArea.bounds.Contains(position))
        {
            return position;
        }
        else
        {
            return WalkableArea.bounds.ClosestPoint(position);
        }
    }
}
