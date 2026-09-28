using UnityEngine;

public class PhysicsPlayer : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5f;
    public float jumpforce = 300f;
    public bool canjump = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canjump)
        {
            AddPlayerForce(new Vector3(0, jumpforce, 0));
            canjump = false;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            AddPlayerForce(new Vector3(0, 0, speed));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            AddPlayerForce(new Vector3(0, 0, -speed));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            AddPlayerForce(new Vector3(speed, 0, 0));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            AddPlayerForce(new Vector3(-speed, 0, 0));
        }

    }
    private void AddPlayerForce(Vector3 force) 
    {
        rb.AddForce(force);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            canjump = true;
        }
    }
}
