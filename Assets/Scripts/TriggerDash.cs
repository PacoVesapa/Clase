using UnityEngine;

public class TriggerDash : MonoBehaviour
{
    public TMPro.TextMeshProUGUI TextoDash;
    private void OnTriggerEnter(Collider other)
    {
        TextoDash.gameObject.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        TextoDash.gameObject.SetActive(false);
    }
}
