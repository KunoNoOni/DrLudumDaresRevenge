using UnityEngine;

public class SpawnSpinnaDoodle : MonoBehaviour
{
    public GameObject spinnaDoodlePrefab;
    public Transform parent;

    private GameObject spawned;

    public void OnEnable()
    {
        spawned = Instantiate(spinnaDoodlePrefab, transform.position, Quaternion.identity, parent);
        spawned.name = "Enemy2SpinnaDoodle";
    }

    public void OnDisable()
    {
        Destroy(spawned);
    }
}
