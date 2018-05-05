using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerToolbox : MonoBehaviour
{
    [SerializeField] private FarmTool[] _tools;
    [SerializeField] private Tilemap _soilMap;
    private int _toolIndex;

    public void UseEquippedTool(PlayerAnimationView animationView, Vector3 targetPosition, System.Action callback)
    {
        _tools[_toolIndex].UseTool(animationView, targetPosition, _soilMap, callback);
    }

    public void EquipNextTool()
    {
        _toolIndex = (_toolIndex + 1) % _tools.Length;
    }
}
