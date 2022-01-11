using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyEditor : Editor
{
    [MenuItem("工具/创建方块， &_f",false)]
    public static void CreateCube()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);   
        cube.name = "方块";
    }

    [MenuItem("工具/销毁方块, &_G",false)]
    public static void DestoryCube()
    {
        GameObject cube = GameObject.Find("方块");
        Debug.Log(cube);
        if (cube != null)
        {
            Editor.DestroyImmediate(cube);
        }
      
    }
    private void OnSceneGUI()
    {
        if (Input.GetKeyDown(KeyCode.F) && Input.GetKeyDown(KeyCode.LeftAlt))
        {
            CreateCube();
        }
        if (Input.GetKeyDown(KeyCode.G) && Input.GetKeyDown(KeyCode.LeftAlt))
        {
            DestoryCube();
        }
    }
}
