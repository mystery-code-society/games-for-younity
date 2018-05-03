using UnityEngine;
using UnityEngine.Tilemaps;

public class Tiller : FarmTool
{
    [SerializeField] private Tilemap _soilMap;
    [SerializeField] private Transform _feet;
    [SerializeField] private GameObject _tillEffect;

    public override void UseTool(PlayerAnimationView animationView, Vector3 targetPosition, System.Action callback)
    {
        animationView.Till(() =>
        {
            Vector3Int cellToTill = _soilMap.WorldToCell(targetPosition);
            NaturalGround groundTile = _soilMap.GetTile<NaturalGround>(cellToTill);
            if (groundTile != null)
            {
                Instantiate(_tillEffect, targetPosition + new Vector3(0f, 0f, -6f), _tillEffect.transform.rotation);
                groundTile.Till(cellToTill, _soilMap);
            }
        });
    }
}
