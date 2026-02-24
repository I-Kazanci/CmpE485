using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{   
    private Rigidbody _rb;
    private Renderer _renderer;
    [SerializeField] private float magnitude = 20f;
    [SerializeField] private float moveSpeed = 10f;
    private bool _jumping = false;
    private bool w = false;
    private bool a = false;
    private bool s = false;
    private bool d = false;

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

        if (w)
        {
            _rb.AddForce(Vector3.forward * moveSpeed);
            w = false;
        }
        if (a)
        {
            _rb.AddForce(Vector3.left * moveSpeed);
            a = false;
        }
        if (s)
        {
            _rb.AddForce(Vector3.back * moveSpeed);
            s = false;
        }
        if (d)
        {
            _rb.AddForce(Vector3.right * moveSpeed);
            d = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumping = true;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            w = true;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            a = true;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            s = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            d = true;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
            _renderer.material.color = Color.red;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Sphere"))
        {
            _renderer.material.color = Color.magenta;
        }
    }
}
