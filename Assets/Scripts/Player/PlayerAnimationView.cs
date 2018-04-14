using UnityEngine;

public class PlayerAnimationView : CardinalMovementHandler
{
    private const string WALK_PREFIX = "Walk";
    private const string TILL_PREFIX = "Till";

    [SerializeField] private Animator _animator;
    private CardinalDirection _lastDirection = CardinalDirection.South;
    public float Speed;

    private void Awake()
    {
        _animator.speed = Speed;
    }

    public void Till()
    {
        _animator.SetTrigger(TILL_PREFIX + _lastDirection);
    }

    public override void HandleMovement(CardinalDirection direction, float xMovement, float yMovement)
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
