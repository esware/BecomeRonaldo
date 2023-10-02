using Managers;
using UnityEngine; 
/*using MoreMountains.NiceVibrations;*/

namespace Collectable
{
    public class GemCollectableTrigger : MonoBehaviour
    {
        [Tooltip("Tag of what is going to trigger it")]
        [SerializeField] private string triggerTargetTag;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(triggerTargetTag)) return;
            
            /*MMVibrationManager.Haptic(HapticTypes.LightImpact, false, true, this);*/
            GameEvents.CollectableEvent?.Invoke(transform.position);
            gameObject.SetActive(false);
        }
    }
}