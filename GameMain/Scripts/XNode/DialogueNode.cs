using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XNode;

public class DialogueNode : Node
{
    [LabelText("说话人")] public string speaker;
    [PreviewField(Alignment = ObjectFieldAlignment.Left), LabelText("头像")]
    public Sprite head;
    [TextArea, LabelText("说话内容")] public List<string> contents;
    [Input(ShowBackingValue.Never), LabelText("上一段")] public string pre;

    [LabelText("下一个是")] public NextType nextType;

    [ShowIf("nextType", NextType.Dialogue), Output, LabelText("下一段对话")]
    public DialogueNode nextDialogue;
    [ShowIf("nextType", NextType.Branch), Output, LabelText("下一段分支")]
    public BranchNode nextBranch;
    [ShowIf("nextType", NextType.Flag), Output, LabelText("下一段标记")]
    public FlagNode nextFlag;
    [Output, LabelText("触发事件")] public EventNode trigger;
    //下一个节点类型
    public enum NextType
    {
        [LabelText("对话框")] Dialogue,
        [LabelText("分支框")] Branch,
        [LabelText("标记框")] Flag
    }
    //类型与名字存起来 对连接进行限制时使用
    private Dictionary<NextType, string> singleDt = new Dictionary<NextType, string>(){
        {NextType.Dialogue, nameof(nextDialogue)},
        {NextType.Branch, nameof(nextBranch)},
        {NextType.Flag, nameof(nextFlag)}
    };

    protected override void Init()
    {
        base.Init();
    }

    public override object GetValue(NodePort port)
    {
        return null;
    }

    //当值更新时 （编辑器下）
    private void OnValidate()
    {
        //切换下一个类型的选项时 对所连接的节点进行限制
        foreach (var s in singleDt)
        {
            if (nextType != s.Key)
            {
                GetPort(s.Value).ClearConnections();
            }
        }
    }

    public override void OnCreateConnection(NodePort from, NodePort to)
    {
        //限定连接节点类型
        if (Outputs.Contains(from))
        {
            if (from.ValueType != to.node.GetType())
            {
                Debug.LogError("不能将" + from.ValueType + "端口连接到" + to.node.GetType() + "节点！");
                GetPort(from.fieldName).Disconnect(to);
            }
        }
    }
}
