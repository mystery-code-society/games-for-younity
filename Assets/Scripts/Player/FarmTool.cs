using UnityEngine;

public abstract class FarmTool : MonoBehaviour
{
    public abstract void UseTool(Animator animator, Vector3 targetPosition, System.Action callback);
}
