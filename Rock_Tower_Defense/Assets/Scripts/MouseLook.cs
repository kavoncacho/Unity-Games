using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 3f;
    public Transform playerBody;
   

    float rotateX = 0f;
    float rotateY = 0f;

    public pauseScript pauseScript;

    
    // Update is called once per frame
    void Update()
    {
        if (pauseScript.gamePause == false)
        {
            fpsPOV();
        } else // means gamePause == true
        {
            Cursor.visible = true;
        }
            
    }

    void fpsPOV()
    {
        Vector2 delta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        rotateX -= delta.y * sensitivity;

        rotateX = Mathf.Clamp(rotateX, -90f, 45f);
        rotateY -= delta.x * sensitivity;
        rotateY = Mathf.Clamp(rotateY, -180f, 180f);


        transform.localRotation = Quaternion.Euler(rotateX, -rotateY, 0f);


        playerBody.Rotate(Vector3.up * delta.x * sensitivity);
        playerBody.Rotate(Vector3.right * -delta.y * sensitivity);
        playerBody.localRotation = Quaternion.Euler(0f, 90 - rotateY, rotateX);
        /*float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX);*/
    }
}
