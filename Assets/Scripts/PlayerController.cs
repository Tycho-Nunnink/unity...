using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Vector3 moveForce = new Vector3(5, 0, 5);
    [SerializeField] float jumpForce = 5f;
    [SerializeField] GameObject beachballCollector;
    [SerializeField] GameObject tmp;

    public int score = 0;
    private float time;

    Rigidbody rb;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tmp.SetActive(false);
    }

    void FixedUpdate()
    {
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            move += transform.forward;
        if (Input.GetKey(KeyCode.S))
            move -= transform.forward;
        if (Input.GetKey(KeyCode.A))
            move -= transform.right;
        if (Input.GetKey(KeyCode.D))
            move += transform.right;

        move = move.normalized * moveForce.z * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        time += Time.deltaTime;
        if (time > 10)
        {
            time = 0;
            if (transform.position.y >= 55)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 40, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 20, transform.position.z);
            }
        }
        
        if (score >= 1 && beachballCollector.GetComponent<BeachballCollector>().count >= 1)
        {
            tmp.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.collider.CompareTag("BEACHBALL"))
        {
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            collision.rigidbody.AddForce(awayFromPlayer, ForceMode.Impulse);
        }
    }
}
