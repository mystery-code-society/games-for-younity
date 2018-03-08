using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : CardinalMovementHandler
{
    public override void HandleMovement(CardinalDirection direction, float xMovement, float yMovement)
    {
        transform.position += new Vector3(xMovement, yMovement, 0f);
    }
}
