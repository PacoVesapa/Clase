using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class PhysicsPlayer : MonoBehaviour
{
    public Rigidbody rb;
    public ControlGravedad Cg;
    public GameObject PanelPausa;
    [Header("Movimiento")]
    public float speed = 5f;
    public float jumpforce = 300f;
    public bool canjump = true;
    public bool candash = true;
    public float dashforce;
    Vector3 direccionMovimiento = Vector3.zero;
    [Header("Items")]
    public int itemCollected = 0;
    public int TotalItems = 0;
    public TMPro.TextMeshProUGUI TextoCuentaItems;
    public GameObject Barrotes;
    void Start()
    {
        Cg = GetComponent<ControlGravedad>();
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

        if (Input.GetKeyDown(KeyCode.X) && candash)
        {
            rb.AddForce(direccionMovimiento * dashforce, ForceMode.Impulse);
            candash = false;
        }
        if (Input.GetKeyDown(KeyCode.G) && Cg.gravedadInvertida == false)
        {
            Cg.gravedadInvertida = true;
        }
        else if (Input.GetKeyDown(KeyCode.G) && Cg.gravedadInvertida == true)
        {
            Cg.gravedadInvertida = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            PanelPausa.gameObject.SetActive(true);
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
            candash = true;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            canjump = false;
            candash = true;
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
