using UnityEngine;

public class SpawnBebop : MonoBehaviour
{
    public GameObject bebopPrefab;
    public Transform parent;

    private GameObject spawned;

    public void OnEnable()
    {
        spawned = Instantiate(bebopPrefab, transform.position, Quaternion.identity, parent);
        spawned.name = "EnemyBebop";
    }

    public void OnDisable()
    {
        Destroy(spawned);
    }
}
