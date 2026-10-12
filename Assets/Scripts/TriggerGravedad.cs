using Unity.VisualScripting;
using UnityEngine;

public class TriggerGravedad : MonoBehaviour
{
    public ControlGravedad ControlG;
    public TMPro.TextMeshProUGUI TextoGravedad;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("¡ALGO ENTRÓ AL TRIGGER!: " + other.name);
        TextoGravedad.gameObject.SetActive(true);
        ControlG.enabled = true;
    }
    private void OnTriggerExit(Collider other)
    {
        TextoGravedad.gameObject.SetActive(false);
    }
}
