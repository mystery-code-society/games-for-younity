using UnityEngine;

public class PlayerToolbox : MonoBehaviour
{
    [SerializeField] private FarmTool[] _tools;
    private int _toolIndex;

    public void UseEquippedTool(PlayerAnimationView animationView, Vector3 targetPosition, System.Action callback)
    {
        _tools[_toolIndex].UseTool(animationView, targetPosition, callback);
    }
}
