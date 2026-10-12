using UnityEngine;

public class ControlGravedad : MonoBehaviour
{
    private Rigidbody rb;
    public bool gravedadInvertida = false;
    public float Gravedad = 9.81f;
    public Camara CinemachineCamera;

    void Start()
    {
        CinemachineCamera = GetComponent<Camara>();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        float direction = gravedadInvertida ? 1f : -1f;
        Vector3 customGravity = new Vector3(0, direction * Gravedad, 0);
        rb.AddForce(customGravity, ForceMode.Acceleration);
        if (gravedadInvertida == true)
        {
            CinemachineCamera.InvertirCamara();
        }
        else 
        {
            CinemachineCamera.CamaraNormal();        
        }
    }
}
