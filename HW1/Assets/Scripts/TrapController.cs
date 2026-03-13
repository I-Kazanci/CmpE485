using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public float interval = 3f;
    // Start is called before the first frame update
    [SerializeField] private GameObject arrow;
    void Start()
    {
        StartCoroutine(ShotArrow());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ShotArrow()
    {
        while (true)
        {
            GameObject newArrow = Instantiate(arrow, transform.position + transform.forward * -1f, Quaternion.identity);
            var rb = newArrow.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.velocity = -transform.forward * 20f;
            yield return new WaitForSeconds(interval);
        }
        
        
    }
}
