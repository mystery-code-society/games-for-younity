using System.Collections;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string VERTICAL_AXIS = "Vertical";
    [SerializeField] private float _movementThreshold = 0f;
    [SerializeField] private CardinalMovementHandler[] _movementHandlers;
    [SerializeField] private PlayerActionController _actionController;

    private CardinalDirection _lastDirection = CardinalDirection.South;
    private bool _inputAllowed = true;

    // Update is called once per frame
    private void Update()
    {
        if(_inputAllowed)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _inputAllowed = false;
                StartCoroutine(WaitForOverridingActionToBeDone(0.5f));
                _actionController.TillTheSoil();
            }
            else
            {
                HandleMovementInput();
            }
        }
    }

    private IEnumerator WaitForOverridingActionToBeDone(float actionLength)
    {
        yield return new WaitForSeconds(actionLength);
        _inputAllowed = true;
    }

    private void HandleMovementInput()
    {
        var xAxis = Input.GetAxis(HORIZONTAL_AXIS);
        var yAxis = Input.GetAxis(VERTICAL_AXIS);
        var shouldMoveHorizontal = ShouldMoveOnAxis(xAxis);
        var shouldMoveVertical = ShouldMoveOnAxis(yAxis);
        if(!shouldMoveHorizontal)
        {
            xAxis = 0f;
        }
        if(!shouldMoveVertical)
        {
            yAxis = 0f;
        }
        if(Mathf.Abs(xAxis) > Mathf.Abs(yAxis))
        {
            HandleMainHorizontalMovement(xAxis, yAxis);
        }
        else if(Mathf.Abs(xAxis) < Mathf.Abs(yAxis))
        {
            HandleMainVerticalMovement(xAxis, yAxis);
        }
        else
        {
            PropagateMovement(_lastDirection, xAxis, yAxis);
        }
    }

    private void HandleMainHorizontalMovement(float xAxis, float yAxis)
    {
        CardinalDirection direction;
        if(xAxis > 0)
            direction = CardinalDirection.East;
        else
            direction = CardinalDirection.West;
        PropagateMovement(direction, xAxis, yAxis);
    }

    private void HandleMainVerticalMovement(float xAxis, float yAxis)
    {
        CardinalDirection direction;
        if(yAxis > 0)
            direction = CardinalDirection.North;
        else
            direction = CardinalDirection.South;
        PropagateMovement(direction, xAxis, yAxis);
    }

    private void PropagateMovement(CardinalDirection direction, float xAxis, float yAxis)
    {
        var v = new Vector2(xAxis, yAxis);
        v = Vector2.ClampMagnitude(v, 1f);
        //Debug.Log("Propagating " + direction.ToString() + " x " + xAxis + " y " + yAxis);
        foreach(var handler in _movementHandlers)
        {
            handler.HandleMovement(direction, v.x, v.y);
        }
        _lastDirection = direction;
    }

    private bool ShouldMoveOnAxis(float axis)
    {
        return Mathf.Abs(axis) > _movementThreshold;
    }

    private void Reset()
    {
        _movementHandlers = GetComponents<CardinalMovementHandler>();
    }
}
