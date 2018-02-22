using UnityEngine;

public abstract class CardinalMovementHandler : MonoBehaviour
{
    public abstract void HandleMovement(CardinalDirection direction, float xMovement, float yMovement);
}
