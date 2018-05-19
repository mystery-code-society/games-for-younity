using UnityEngine;
using UnityEngine.Tilemaps;

public class Tiller : FarmTool
{
    [SerializeField] private GameObject _tillEffect;

    public override void UseTool(PlayerAnimationView animationView, Vector3 targetPosition, Tilemap soilMap, System.Action callback)
    {
        animationView.Till(() =>
        {
            Vector3Int cellToTill = soilMap.WorldToCell(targetPosition);
            NaturalGround groundTile = soilMap.GetTile<NaturalGround>(cellToTill);
            if (groundTile != null && groundTile.MyCondition == NaturalGround.Condition.Compacted)
            {
                Instantiate(_tillEffect, targetPosition + new Vector3(0f, 0f, -6f), _tillEffect.transform.rotation);
                groundTile.Till(cellToTill, soilMap);
            }
            callback();
        });
    }
}
