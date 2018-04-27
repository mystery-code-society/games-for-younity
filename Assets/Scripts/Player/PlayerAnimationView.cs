using System.Collections;
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

    public void Till(System.Action callback)
    {
        _animator.SetBool(WALK_PREFIX + _lastDirection, false);
        _animator.SetTrigger(TILL_PREFIX + _lastDirection);
        StartCoroutine(WaitForAnimation(TILL_PREFIX + _lastDirection, callback));
    }

    private IEnumerator WaitForAnimation(string animationName, System.Action callback)
    {
        RuntimeAnimatorController animatorController = _animator.runtimeAnimatorController;
        float length = 0;
        for(int i = 0; i < animatorController.animationClips.Length; i++)
        {
            if(animatorController.animationClips[i].name == animationName)
            {
                length = animatorController.animationClips[i].length;
            }
        }
        yield return new WaitForSeconds(length / _animator.speed);
        callback();
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
