using RPGGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 cameraMoveDir = Vector3.zero;
    float cameraMoveSpeed = 10f;
    public float cameraFocusSpeed = 10f;
    public Camera tabCamera;
    public Camera sceneCamera;
    [SerializeField]
    private GameObject Player;

    Transform cameraTrans;

    int width = Screen.width;
    int height = Screen.height;
    Vector3 tmpPos;

    Ray ray;
    RaycastHit hit;
    public Material mat;

    float newy;
    private void Start()
    {
        cameraTrans = this.transform;
        tmpPos = cameraTrans.position;
    }

    void Update()
    {
        ray = sceneCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("Enemy")))
        {
            hit.collider.gameObject.GetComponent<MeshRenderer>().materials[0] = mat;
        }

        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        if (Player != null)
        {
            float y = cameraTrans.position.y;
            tmpPos = new Vector3(Player.transform.position.x, y, Player.transform.position.z);
            while (Vector3.Distance(tmpPos, this.transform.position) > 0.1f)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, tmpPos, 0.2f);
            }
        }

        //Debug.Log("鼠标增量的值" + );
        if (Input.mouseScrollDelta.y < 0) 
        {
            newy = Mathf.Clamp(this.transform.position.y + cameraFocusSpeed*Time.deltaTime, 7.5f, 25);
            this.transform.position = new Vector3(transform.position.x, newy, transform.position.z);
        }
        if (Input.mouseScrollDelta.y > 0)
        {
            newy = Mathf.Clamp(this.transform.position.y - cameraFocusSpeed * Time.deltaTime, 7.5f, 25);
            this.transform.position = new Vector3(transform.position.x, newy, transform.position.z);
        }

        tabCamera.transform.position = new Vector3(transform.position.x, tabCamera.transform.position.y, transform.position.z);
        //if (Input.mousePosition.x <= 0)
        //{
        //    //Input.mousePosition.Set(0, Input.mousePosition.y, Input.mousePosition.z);
        //    cameraMoveDir.x = -1;
        //}
        //else if (Input.mousePosition.x >= width)
        //{
        //    //Input.mousePosition.Set(width, Input.mousePosition.y, Input.mousePosition.z);
        //    cameraMoveDir.x = 1;
        //}
        //else
        //{
        //    cameraMoveDir.x = 0;
        //}

        //if (Input.mousePosition.y <= 0)
        //{
        //    //Input.mousePosition.Set(Input.mousePosition.x, 0, Input.mousePosition.z);
        //    cameraMoveDir.z = -1;
        //}
        //else if (Input.mousePosition.y >= height)
        //{
        //    //Input.mousePosition.Set(Input.mousePosition.x, height, Input.mousePosition.z);
        //    cameraMoveDir.z = 1;
        //}
        //else
        //{
        //    cameraMoveDir.z = 0;
        //}

        //this.transform.position += cameraMoveDir * cameraMoveSpeed * Time.deltaTime;
    }

    IEnumerator CameraSmoothMoveToPlayer(Vector3 pos)
    {
        while (Vector3.Distance(pos, this.transform.position) > 0.3f)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, pos, 0.2f);
            yield return null;
        }
    }
}
