using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 cameraMoveDir = Vector3.zero;
    float cameraMoveSpeed = 50f;

    Transform cameraTrans;

    int width = Screen.width;
    int height = Screen.height;

    private void Start()
    {
        cameraTrans = this.transform;
    }

    void Update()
    {
        if (Input.mousePosition.x <= 0)
        {
            Input.mousePosition.Set(0, Input.mousePosition.y, Input.mousePosition.z);
            cameraMoveDir.x = -1;
        }
        else if (Input.mousePosition.x >= width)
        {
            Input.mousePosition.Set(width, Input.mousePosition.y, Input.mousePosition.z);
            cameraMoveDir.x = 1;
        }
        else
        {
            cameraMoveDir.x = 0;
        }

        if (Input.mousePosition.y <= 0)
        {
            Input.mousePosition.Set(Input.mousePosition.x, 0, Input.mousePosition.z);
            cameraMoveDir.z = -1;
        }
        else if (Input.mousePosition.y >= height)
        {
            Input.mousePosition.Set(Input.mousePosition.x, height, Input.mousePosition.z);
            cameraMoveDir.z = 1;
        }
        else
        {
            cameraMoveDir.z = 0;
        }

        if (cameraMoveDir.magnitude != 0)
        {
            cameraTrans.position = Vector3.Lerp(cameraTrans.position, cameraTrans.position + cameraMoveDir.normalized * cameraMoveSpeed * Time.deltaTime, 0.1f);
        }
    }
}
