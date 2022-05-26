using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class FlagNode : Node {

	[LabelText("节点类型")]
	public FlagNodeType flagType;
	public enum FlagNodeType
    {
		Start,End
    }
	[Input((ShowBackingValue.Never)), ShowIf("flagType", FlagNodeType.End)]
	public string pre;

	[Output(), LabelText("下一段"), ShowIf("flagType", FlagNodeType.Start)] 
	public string next;

	protected override void Init() {
		base.Init();
		
	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		return null; // Replace this
	}
}

public class EventNode : Node
{
	[Input(ShowBackingValue.Never), LabelText("触发对象")] 
	public string triggerObj;
	[LabelText("事件名称")] 
	public string eventName;

    public override object GetValue(NodePort port)
    {
		return null;
    }
}