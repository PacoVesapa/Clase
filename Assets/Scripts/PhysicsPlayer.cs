using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class PhysicsPlayer : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5f;
    public float jumpforce = 300f;
    public bool canjump = true;
    public float dashforce;
    public int itemCollected = 0;
    public int TotalItems = 0;
    public TMPro.TextMeshProUGUI TextoCuentaItems;
    public GameObject Barrotes;
    Vector3 direccionMovimiento = Vector3.zero;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        TotalItems = GameObject.FindGameObjectsWithTag("Item").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canjump)
        {
            rb.AddForce(new Vector3(0, jumpforce, 0), ForceMode.Impulse);
            canjump = false;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            AddPlayerForce(new Vector3(0, 0, speed));
            direccionMovimiento = new Vector3(0, 0, 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            AddPlayerForce(new Vector3(0, 0, -speed));
            direccionMovimiento = new Vector3(0, 0, -1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            AddPlayerForce(new Vector3(speed, 0, 0));
            direccionMovimiento = new Vector3(1, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            AddPlayerForce(new Vector3(-speed, 0, 0));
            direccionMovimiento = new Vector3(-1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            rb.AddForce(direccionMovimiento * dashforce, ForceMode.Impulse);
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
    public void CollectItem()
    {
        TextoCuentaItems.gameObject.SetActive(true);
        itemCollected++;
        TextoCuentaItems.text = "Items Recolectados: " + itemCollected + "/" + TotalItems;
        if (itemCollected == TotalItems)
        {
            Barrotes.gameObject.SetActive(false);
        }
    }
}
