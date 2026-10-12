using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarEscena : MonoBehaviour
{
    public GameObject PanelPausa;
    public void ReiniciarJuego()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ReanudarJuego()
    {
        Time.timeScale = 1.0f;
        PanelPausa.gameObject.SetActive(false);
    }
}
