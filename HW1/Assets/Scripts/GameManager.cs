using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DoorController _door;
    void Start()
    {
        _door = FindObjectOfType<DoorController>();
        _door.onKeyDelivered += handleWin;
    }

    void handleWin()
    {
        Debug.Log("Win");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
