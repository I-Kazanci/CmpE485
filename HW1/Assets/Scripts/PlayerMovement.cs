using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public float pushPower = 0.008f;
    private CharacterController _controller;
    private Animator _animator;
    private bool _alive = true;
    private Vector3 _moveDirection;
    public event Action onDie;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (_alive)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            

            
            Vector3 move = transform.right * h + transform.forward * v;

            bool isMoving = move.sqrMagnitude > 0.01f;
            _animator.SetBool("isMoving", isMoving);

            if (isMoving)
            {
                move.Normalize();
                _moveDirection = move;

                _animator.SetFloat("inputX", h);
                _animator.SetFloat("inputY", v);

                _controller.Move(move * speed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_alive)
        {
            if (other.gameObject.CompareTag("Arrow"))
            {
                StartCoroutine(DieCourutine());
            }
        }
    }

    private IEnumerator DieCourutine()
    {
        _animator.SetTrigger("Die");
        _alive = false;
        yield return new  WaitForSeconds(1f);
        onDie?.Invoke();
    }

    public void StopMoving()
    {   
        _animator.SetBool("isMoving", false);
        this.enabled = false;
        GetComponent<MouseLook>().enabled = false;
    }
    
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!hit.gameObject.CompareTag("Key"))
            return;

        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb == null || rb.isKinematic)
            return;

        if (_moveDirection.sqrMagnitude < 0.01f)
            return;

        Vector3 pushDir = _moveDirection;
        pushDir.y = 0f;

        rb.AddForce(pushDir * pushPower, ForceMode.Impulse);
    }
}