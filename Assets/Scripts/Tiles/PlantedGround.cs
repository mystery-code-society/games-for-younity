using UnityEngine;

[CreateAssetMenu(fileName ="PlantedGround", menuName ="Scriptable Objects/Planted Ground")]
public class PlantedGround : NaturalGround
{
    public Crop MyCrop { get; private set; }
    public SpriteRenderer CropSprite { get; private set; }

    public void Init(Crop crop, Vector3 position)
    {
        MyCrop = crop;
        CropSprite = CreateSprite(position);
        CropSprite.sprite = MyCrop.GrowthStages[0];
    }

    private SpriteRenderer CreateSprite(Vector3 position)
    {
        GameObject go = new GameObject();
        go.name = MyCrop.CropType.ToString() + position;
        go.transform.position = position + Vector3.back;
        return go.AddComponent<SpriteRenderer>();
    }
}
