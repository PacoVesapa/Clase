using UnityEngine;

public class TriggerInicio : MonoBehaviour
{
    public TMPro.TextMeshProUGUI TextoControles;
    private void OnTriggerEnter(Collider other)
    {
        TextoControles.gameObject.SetActive(true);  
    }
    private void OnTriggerExit(Collider other)
    {
        TextoControles.gameObject.SetActive(false);
    }
}
