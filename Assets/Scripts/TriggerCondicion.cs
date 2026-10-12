using UnityEngine;

public class TriggerCondicion : MonoBehaviour
{
    public TMPro.TextMeshProUGUI TextoSobreItems;
    private void OnTriggerEnter(Collider other)
    {
        TextoSobreItems.gameObject.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        TextoSobreItems.gameObject.SetActive(false);
    }
}
