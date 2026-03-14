using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float patrolDuration;
    [SerializeField] private float attackInterval;
    private Rigidbody _rb;
    private Animator _anim;
    public bool isAttacking = false;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponentInChildren<Animator>();
        StartCoroutine(Patrol());
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Patrol()
    {
        while (true)
        {
            _rb.velocity = new Vector3(0, 0, moveSpeed);
            yield return new WaitForSeconds(patrolDuration);
            transform.Rotate(0, 180, 0);
            _rb.velocity = new Vector3(0, 0, -moveSpeed);
            yield return new WaitForSeconds(patrolDuration);
            transform.Rotate(0, 180,0);
        }
    }

    private IEnumerator Attack()
    {
        while (true)
        {   
            isAttacking = true;
            _anim.SetTrigger("Attack");
            yield return new WaitForSeconds(1);
            isAttacking = false;
            yield return new WaitForSeconds(attackInterval);
        }
    }
    
}
