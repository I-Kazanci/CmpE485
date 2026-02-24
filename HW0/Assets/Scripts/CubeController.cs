using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{   
    private Rigidbody _rb;
    private Renderer _renderer;
    [SerializeField] private float magnitude = 20f;
    private bool _jumping = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
    }


    private void FixedUpdate()
    {
        if (_jumping)
        {
            Debug.Log("Aman");
            _rb.AddForce(Vector3.up * magnitude);
            _jumping = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumping = true;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
            _renderer.material.color = Color.red;
        }
    } 
}
