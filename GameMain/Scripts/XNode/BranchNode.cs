using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class BranchNode : Node {
    [LabelText("提问人")]
    public string speaker;
    [PreviewField(Alignment = ObjectFieldAlignment.Left), LabelText("头像")]
    public Sprite head;
    [TextArea, LabelText("问题")] public string question;
    [Input(ShowBackingValue.Never), LabelText("上一段")] public string pre;
    [Output(dynamicPortList = true), LabelText("分支选项"), TextArea]
    public List<string> branchs;

    public override object GetValue(NodePort port)
    {
        return null; // Replace this
    }
}