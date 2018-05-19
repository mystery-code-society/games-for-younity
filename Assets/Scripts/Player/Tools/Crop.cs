using UnityEngine;

[CreateAssetMenu(fileName ="Crop", menuName ="Scriptable Objects/Crop")]
public class Crop : ScriptableObject
{
    public Type CropType;
    public Sprite[] GrowthStages;
    public GameObject Fruit;

    public enum Type
    {
        Corn
    }
}
