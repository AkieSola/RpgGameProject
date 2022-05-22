using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class AssetPostprocessorTools : AssetPostprocessor
{
    /// <summary>
    /// 音频资源导入完成之前调用
    /// </summary>
    private void OnPreprocessAudio()
    {
        AudioImporter _importer = (AudioImporter)assetImporter;
        _importer.preloadAudioData = true;
    }
    /// <summary>
    /// 从模型（.fbx，.mb文件等）导入动画之前调用
    /// </summary>
    private void OnPreprocessAnimation()
    {
        ModelImporter _importer = (ModelImporter)assetImporter;
    }
    /// <summary>
    /// 模型导入之前调用
    /// </summary>
    private void OnPreprocessModel()
    {
        ModelImporter _importer = (ModelImporter)assetImporter;
    }

    /// <summary>
    /// 音频资源导入完成之后调用
    /// </summary>
    /// <param name="clip"></param>
    private void OnPostprocessAudio(AudioClip clip)
    {
        Debug.Log("导入音频：" + clip.name);
        AudioImporter _importer = (AudioImporter)assetImporter;
    }
    /// <summary>
    /// 模型导入完成之后调用
    /// </summary>
    /// <param name="g"></param>
    private void OnPostprocessModel(GameObject g)
    {
        Debug.Log("导入模型：" + g.name);
    }
    /// <summary>
    /// 精灵的纹理导入完成之后调用
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="sprites"></param>
    private void OnPostprocessSprites(Texture2D texture, Sprite[] sprites)
    {
        Debug.Log("导入纹理：" + texture.name);
    }
    /// <summary>
    /// 所有的资源的导入完成后都会调用
    /// </summary>
    /// <param name="importedAssets">导入资源路径</param>
    /// <param name="deletedAssets">删除资源路径</param>
    /// <param name="movedAssets">移动资源目标路径</param>
    /// <param name="movedFromAssetPaths">移动资源源路径</param>
    private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (string str in importedAssets)
        {
            Debug.Log("导入资源: " + str);
            if (str.EndsWith(".atlas"))
            {
                Debug.LogError("啊啊啊啊啊啊啊啊啊啊啊啊");
                if (File.Exists(str))
                {
                    File.Move(str, str + ".txt");
                    Debug.LogError("修改成功");
                }
            }
        }
        foreach (string str in deletedAssets)
        {
            Debug.Log("删除资源: " + str);
        }
        for (int i = 0; i < movedAssets.Length; i++)
        {
            Debug.Log("从:" + movedFromAssetPaths[i] + "，移动资源到:" + movedAssets[i]);
        }
    }
    /// <summary>
    /// 该函数会在纹理导入完成之后调用
    /// </summary>
    /// <param name="texture"></param>
    private void OnPostprocessTexture(Texture2D texture)
    {
        Debug.Log("导入贴图：" + texture.name);
        Debug.Log("assetPath ：" + assetPath);
        TextureImporter textureImporter = AssetImporter.GetAtPath(assetPath) as TextureImporter;
        if (textureImporter != null)
        {
            string AtlasName = new System.IO.DirectoryInfo(System.IO.Path.GetDirectoryName(assetPath)).Name;
            textureImporter.textureType = TextureImporterType.Sprite;
            textureImporter.spriteImportMode = SpriteImportMode.Single;
            textureImporter.spritePackingTag = AtlasName;
            textureImporter.mipmapEnabled = false;
        }
    }
    /// <summary>
    /// 该函数会在纹理导入完成之前调用
    /// </summary>
    void OnPreprocessTexture()
    {

        //自动设置类型;
        TextureImporter textureImporter = (TextureImporter)assetImporter;
        textureImporter.textureType = TextureImporterType.Sprite;

        //自动设置打包tag;
        string dirName = System.IO.Path.GetDirectoryName(assetPath);
        Debug.Log("Import ---  " + dirName);
        string folderStr = System.IO.Path.GetFileName(dirName);
        Debug.Log("Set Packing Tag ---  " + folderStr);

        textureImporter.spritePackingTag = folderStr;
    }
}
