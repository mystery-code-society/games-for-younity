using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationView : MonoBehaviour, ICardinalMovementHandler
{
    private const string WALK_PREFIX = "Walk";

    [SerializeField] private Animator _animator;
    private CardinalDirection _lastDirection = CardinalDirection.South;

    public void HandleMovement(CardinalDirection direction, float xMovement, float yMovement)
    {
        if(direction != _lastDirection)
        {
            _animator.SetBool(WALK_PREFIX + _lastDirection.ToString(), false);
        }

        if (Mathf.Abs(xMovement) > 0f || Mathf.Abs(yMovement) > 0f)
        {
            _animator.SetBool(WALK_PREFIX + direction.ToString(), true);
        }
        else
        {
            _animator.SetBool(WALK_PREFIX + direction.ToString(), false);
        }
        _lastDirection = direction;
    }
}
