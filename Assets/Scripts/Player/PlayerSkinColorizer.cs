using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinColorizer : MonoBehaviour
{
    [SerializeField] private Color[] _skinTones;
    [SerializeField] private SkinTone _mySkinTone;
    [SerializeField] private SpriteRenderer[] _skinSprites;

    private void OnValidate()
    {
        foreach(var img in _skinSprites)
        {
            img.color = _skinTones[(int)_mySkinTone];
        }
    }

    private enum SkinTone
    {
        One = 0,
        Two = 1,
        Three = 2,
        Four = 3,
        Five = 4,
        Six = 5,
        Seven = 6,
        Eight = 7,
        Nine = 8,
        Ten = 9
    }
}
