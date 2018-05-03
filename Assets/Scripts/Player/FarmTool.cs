using UnityEngine;

public abstract class FarmTool : MonoBehaviour
{
    public abstract void UseTool(PlayerAnimationView animationView, Vector3 targetPosition, System.Action callback);
}
