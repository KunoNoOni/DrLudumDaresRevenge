using UnityEngine;

public class SpawnMandar : MonoBehaviour
{
    public GameObject mandarPrefab;
    public Transform parent;

    private GameObject spawned;

    public void OnEnable()
    {
        spawned = Instantiate(mandarPrefab, transform.position, Quaternion.identity, parent);
        spawned.name = "Enemy3Mandar";
    }

    public void OnDisable()
    {
        Destroy(spawned);
    }
}
