using UnityEngine;

public class PlayerMovemment : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 60f;
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        

        Vector3 mvmt = Vector3.right * x;

        controller.Move(mvmt * speed * Time.deltaTime);
    }
}
