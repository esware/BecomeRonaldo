using UnityEngine;
public class Suit : MonoBehaviour
{
    [SerializeField] private GameObject[] humanPrefabs;

    private void Start()
    {
        Vector3 position = new Vector3(10, 1, 0);
        for (int i = 0; i < 10; i++)
        {
            var clone =Instantiate(humanPrefabs[Random.Range(0,humanPrefabs.Length)], Vector3.zero, 
                Quaternion.Euler(0,180,0), transform);

            clone.transform.localPosition = new Vector3(position.x + i * 4, 2, 0);
        }
    }
}
