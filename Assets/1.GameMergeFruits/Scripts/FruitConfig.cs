using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FruitConfig", menuName = "MergeFruit/FruitConfig")]
public class FruitConfig : ScriptableObject
{
    public List<FruitData> FruitDataList;
    static FruitConfig _instance;
    public static FruitConfig instance => _instance ?? (_instance = Resources.Load<FruitConfig>("Configs/FruitConfig"));
    public int MaxFruitIndexCanDrop;

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (FruitDataList != null)
        {
            for (int i = 0; i < FruitDataList.Count; i++)
            {
                FruitDataList[i].FruitIndex = i;
            }
        }
    }
#endif
}

[System.Serializable]
public class FruitData
{
    public int FruitIndex;
    public string FruitName;
    public float Scale;
    public float Weight;
    public Sprite FruitSprite;
}

public enum FruitType //i dont think we need this enum anymore
{
    Cherry = 1,
    Grape = 2,
    Apple = 3,
    Coconut = 4,
    Watermelon = 5,
}
