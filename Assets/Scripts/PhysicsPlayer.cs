using UnityEngine;

public class PhysicsPlayer : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5f;
    public float jumpforce = 300f;
    public bool canjump = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canjump)
        {
        rb.AddForce (0, jumpforce, 0);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, 0, speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(0, 0, -speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-speed, 0, 0);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            canjump = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            canjump = false;
        }
    }
}
