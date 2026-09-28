using UnityEngine;

public class Character : MonoBehaviour
{
    float gravity = -9.8f;
    public float speed = 1.0f;
    public CharacterController CC;
    void Start()
    {
        CC = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            CC.Move(new Vector3(0, 0, -1) * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            CC.Move(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            CC.Move(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            CC.Move(new Vector3(1, 0, 0) * speed * Time.deltaTime);
        }
        if (CC.isGrounded == false)
        {
            CC.Move(new Vector3(0, gravity, 0) * speed * Time.deltaTime);
        }
    }
}
