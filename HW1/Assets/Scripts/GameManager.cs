using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private DoorController _door;
    private GameObject _key;
    private AudioSource _audioSource;
    [SerializeField] private GameObject gamePlane;
    [SerializeField] private GameObject mapPlane;
    [SerializeField ]private PlayerMovement player;
    [SerializeField] private PanelController panel;
    private Rigidbody rb;
    void Start()
    {
        _door = FindObjectOfType<DoorController>();
        _key = GameObject.FindGameObjectWithTag("Key");
        _audioSource = GetComponent<AudioSource>();
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

        if (Input.GetKeyDown(KeyCode.K))
        {
            _key.transform.position = new Vector3(-0.8f, -0.0495f, 9.11f);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (_audioSource.isPlaying)
            {
                _audioSource.Stop();
            }
            else
            {
                _audioSource.Play();
            }
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
