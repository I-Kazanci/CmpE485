using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private CharacterController _controller;
    private Animator _animator;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * h + transform.forward * v;

        bool isMoving = move.sqrMagnitude > 0.01f;
        _animator.SetBool("isMoving", isMoving);

        if (isMoving)
        {
            move.Normalize();

            _animator.SetFloat("inputX", h);
            _animator.SetFloat("inputY", v);

            _controller.Move(move * speed * Time.deltaTime);
        }
    }
}