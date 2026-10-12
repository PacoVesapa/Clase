using UnityEngine;

public class TriggerItem : MonoBehaviour
{
    public PhysicsPlayer player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PhysicsPlayer>();
            player.CollectItem();
            Destroy(gameObject);
        }
    }
}
