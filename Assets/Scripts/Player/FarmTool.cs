using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class FarmTool : MonoBehaviour
{
    public abstract void UseTool(PlayerAnimationView animationView, Vector3 targetPosition, Tilemap soilmap, System.Action callback);
}
