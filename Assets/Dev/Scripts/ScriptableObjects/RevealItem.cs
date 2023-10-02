using UnityEngine;

namespace ScriptableObjects.Scripts
{
    [CreateAssetMenu(fileName = "RevealItem", menuName = "ScriptableObjects/RevealItem", order = 1)]
    public class RevealItem : ScriptableObject
    {
        [Header("UI")]
        [SerializeField] public Sprite sprite;
        [SerializeField] public Sprite darkSprite;
        
        [Header("About")]
        [SerializeField] public new string name;
    }
}