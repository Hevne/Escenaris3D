using UnityEngine;
using UnityEngine.UI;

public class FPS_MouseController : MonoBehaviour
{

    [Header("Camera Speed Settings")]
    public Vector2 CameraSpeed;
    public Camera camera;

    //Body settings
    Transform body;
    float deltaTime = 0.0f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        body = this.transform;
    }


    // Update is called once per frame
    void Update()
    {

        //Get mouse position increments
        float lookHor = Input.GetAxis("Mouse X");
        float lookVert = Input.GetAxis("Mouse Y");

        body.Rotate(0, lookHor * CameraSpeed.x, 0);

        Debug.Log(camera.transform.rotation.eulerAngles);
        camera.transform.Rotate(-lookVert * CameraSpeed.y, 0, 0);
    }
}
