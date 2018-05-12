using UnityEngine;

[CreateAssetMenu(fileName ="Crop", menuName ="Scriptable Objects/Crop")]
public class Crop : ScriptableObject
{
    public string Name;
    public Sprite Seed;
    public Sprite[] GrowthStages;
    public GameObject Fruit;
}
