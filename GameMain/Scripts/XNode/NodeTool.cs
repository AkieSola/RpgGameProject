using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public static class NodeTool
{
    /// <summary>
    /// 获取端口连接点的值
    /// </summary>
    /// <param name="node"></param>
    /// <param name="fieldName"></param>
    /// <returns></returns>
    public static Node GetNodeByField(this Node node, string fieldName)
    {
        if (!node.HasPort(fieldName))
        {
            Debug.LogWarning("不存在 " + fieldName + " 端口！");
            return null;
        }

        var port = node.GetPort(fieldName);
        if (!port.IsConnected)
        {
            Debug.LogWarning(fieldName + "端口未连接！");
            return null;
        }
        return port.Connection.node;
    } 
    /// <summary>
    /// 获取端口属性的值
    /// </summary>
    /// <param name="node"></param>
    /// <param name="fieldName"></param>
    /// <returns></returns>
    public static object GetValuesByField(this Node node,string fieldName)
    {
        return node.GetType().GetField(fieldName).GetValue(node);
    }
}
