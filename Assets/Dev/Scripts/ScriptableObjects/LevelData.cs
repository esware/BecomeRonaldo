using UnityEngine;

namespace ScriptableObjects.Scripts
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 1)]
    public class LevelData : ScriptableObject
    {
        [SerializeField] public RevealItem revealItem;
        [SerializeField] public int revealStartPercentage;
        [SerializeField] public int revealPercentageIncrease;

        [Header("Level")] [SerializeField] public GameObject levelObject;
    }
}