using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private DoorController _door;
    [SerializeField] private GameObject gamePlane;
    [SerializeField] private GameObject mapPlane;
    [SerializeField ]private PlayerMovement player;
    [SerializeField] private PanelController panel;
    private Rigidbody rb;
    void Start()
    {
        _door = FindObjectOfType<DoorController>();
        _door.onKeyDelivered += handleWin;
        player.onDie += handleLose;
    }

    void handleWin()
    {
        player.StopMoving();
        panel.enablePanel("Win");
        panel.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void handleLose()
    {   
        player.StopMoving();
        panel.enablePanel("Lose");
        panel.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            gamePlane.SetActive(!gamePlane.activeInHierarchy);
            mapPlane.SetActive(!mapPlane.activeInHierarchy);
        }
    }

    public void HandleUINo()
    {
        Debug.Log("No pressed");
        panel.gameObject.SetActive(false);
        
    }

    public void HandleUIYes()
    {
        Debug.Log("Yes pressed");
        panel.gameObject.SetActive(false);
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
