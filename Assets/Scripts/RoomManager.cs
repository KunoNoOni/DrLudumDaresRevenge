using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    private float xOffset = 14f;
    private float yOffset = 10f;
    private GameObject levelCamera;
    MusicManager mm;

    void Awake()
    {
        mm = GameObject.Find("MusicManager").GetComponent<MusicManager>();
    }

    private void Start()
    {
        levelCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mm.PlaySound(mm.music[3]);
    }

    public void ChangeRoom(float xDir, float yDir)
    {
        Debug.Log("Moving Camera");
        float cameraX = levelCamera.transform.position.x;
        float cameraY = levelCamera.transform.position.y;

        cameraX += xOffset * xDir;
        cameraY += yOffset * yDir;
        levelCamera.transform.position = new Vector3(cameraX, cameraY, -10f);

    }
    
}
