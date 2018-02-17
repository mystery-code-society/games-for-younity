using UnityEngine;
using System.Collections;

public class PlayerInputController : MonoBehaviour
{
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string VERTICAL_AXIS = "Vertical";
    private const float MOVEMENT_THRESHOLD = 0f;

    private CardinalDirection _lastDirection = CardinalDirection.South;
    private ICardinalMovementHandler[] _movementHandlers;

    private void Start()
    {
        _movementHandlers = GetComponents<ICardinalMovementHandler>();
    }

    // Update is called once per frame
    private void Update()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        var xAxis = Input.GetAxis(HORIZONTAL_AXIS);
        var yAxis = Input.GetAxis(VERTICAL_AXIS);
        var shouldMoveHorizontal = ShouldMoveOnAxis(xAxis);
        var shouldMoveVertical = ShouldMoveOnAxis(yAxis);
        Debug.Log(xAxis + ", " + yAxis);
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
        Debug.Log("Propagating " + direction.ToString() + " x " + xAxis + " y " + yAxis);
        foreach(var handler in _movementHandlers)
        {
            handler.HandleMovement(direction, xAxis, yAxis);
        }
        _lastDirection = direction;
    }

    private bool ShouldMoveOnAxis(float axis)
    {
        return Mathf.Abs(axis) > MOVEMENT_THRESHOLD;
    }
}
