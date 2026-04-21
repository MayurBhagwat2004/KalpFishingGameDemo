using UnityEngine;

[CreateAssetMenu(fileName = "New Fish",menuName = "Fishing/Fish Data")]
public class FishData : ScriptableObject
{
    [Header("Fish Information")]
    public string fishName;
    public Sprite icon;


    public FishRarity rarity;
    public FishDifficulty difficulty;

}

public enum FishRarity
{
    Common,
    Uncommon,
    Rare
}

public enum FishDifficulty
{
    Easy,
    Medium,
    Hard
}
