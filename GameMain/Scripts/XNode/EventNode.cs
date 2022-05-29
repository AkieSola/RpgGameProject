using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public enum DialogEventType
{
	Nothing = 0,
	ShiftToBattle = 1,
}

public class EventNode : Node
{
	[Input(ShowBackingValue.Never), LabelText("触发前置")]
	public string trigger;
	[ShowInInspector, LabelText("事件类型")]
	public DialogEventType eventType;

	public override object GetValue(NodePort port)
	{
		return null;
	}
}
