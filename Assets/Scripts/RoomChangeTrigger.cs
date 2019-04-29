using UnityEngine;

public class RoomChangeTrigger : MonoBehaviour
{
    public float xDir;
    public float yDir;

    private RoomManager roomManager;
    private GameObject playerPosition;
    
    void Start()
    {
        roomManager = GameObject.Find("RoomManager").GetComponent<RoomManager>();
        playerPosition = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.CompareTag("Player"))
        {
            Debug.Log("RoomChangeTrigger Activated!");
            Debug.Log("Triggered by " + collider2D.name);
            roomManager.ChangeRoom(xDir, yDir);
            playerPosition.transform.position += new Vector3(3 * xDir, 3 * yDir, 0);
        }
        
    }

}
