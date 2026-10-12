using UnityEngine;

public class TriggerFinal : MonoBehaviour
{
    public GameObject PanelVictoria;
    private void OnTriggerEnter(Collider other)
    {
        PanelVictoria.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
