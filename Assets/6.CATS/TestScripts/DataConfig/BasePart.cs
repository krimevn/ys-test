using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePart: MonoBehaviour
{
    public int Level; //this should take from saved data
    public int PartID;
    public string PartName;
    public int PartStars;

    public StatModifier HPModifier; //you can round whatever you want if want it's integer
    public StatModifier ATKModifier;
    public StatModifier EnergyCost;
    public GameObject PartPrefab;
}

[System.Serializable]
public class StatModifier
{
    public float BaseStat;
    public float Modifier;
    public float Stat(int level)
    {
        //apply any formular anti snowball or something else if had for final stat value
        return BaseStat + (level * Modifier * BaseStat);
    }
}

public enum PartType
{ 
    
}

[System.Serializable]
public class StickerData
{
    public Sticker sticker;
    public Vector2 stickerPosition;
}