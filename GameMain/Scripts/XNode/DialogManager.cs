using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XNode;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogueUi;

    public DialogueNodeGraph dialogueGraph;

    [SerializeField]
    private Text content;
    [SerializeField]
    private Text speaker;
    [SerializeField]
    private Image head;
    [ShowInInspector] private Node currentNode;
    [ShowInInspector] private List<string> contentList = new List<string>();
    [ShowInInspector] private List<Button> branchBtns = new List<Button>();
    public GameObject branchPb;

    void Start()
    {
        dialogueUi.SetActive(false);
    }

    void Update()
    {
         if (Input.GetKeyDown(KeyCode.A))
        {
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentNode == null)
            {
                dialogueUi.SetActive(true);
                currentNode = dialogueGraph.nodes[0].GetOutputPort("next").Connection.node;
                Debug.Log(currentNode);
                UpdateDialogueUi(currentNode);
            }
            else if (currentNode.GetType() == typeof(DialogueNode))
            {
                ShowContent();
            }
        }
    }

    #region "对话系统逻辑部分"

    private void UpdateDialogueUi(Node current)
    {
        if (current.GetType() == typeof(DialogueNode))
        {
            var node = current as DialogueNode;
            if (node != null)
            {
                contentList.AddRange(node.contents);
                content.text = contentList[0];
                speaker.text = node.speaker;
                head.sprite = node.head;
            }
        }
        else if (current.GetType() == typeof(BranchNode))
        {
            var branchNode = currentNode as BranchNode;
            if (branchNode != null)
            {
                contentList.Add(branchNode.question);
                speaker.text = branchNode.speaker;
                head.sprite = branchNode.head;
            }
        }
    }

    /// <summary>
    /// 显示对话内容
    /// </summary>
    void ShowContent()
    {
        if (contentList.Count > 0)
        {
            contentList.RemoveAt(0);
            if (contentList.Count == 0)
            {
                foreach (var connection in currentNode.GetOutputPort("trigger").GetConnections())
                {
                    TriggerEvent(connection.node as EventNode);
                }
                switch (currentNode.GetValuesByField("nextType"))
                {
                    case DialogueNode.NextType.Dialogue:
                        Debug.Log("进入对话框节点");
                        currentNode = currentNode.GetNodeByField("nextDialogue");
                        var node = currentNode as DialogueNode;
                        if (node != null)
                        {
                            contentList.AddRange(node.contents);
                            speaker.text = node.speaker;
                            head.sprite = node.head;
                        }
                        break;
                    case DialogueNode.NextType.Branch:
                        Debug.Log("进入分支框节点");
                        currentNode = currentNode.GetNodeByField("nextBranch");
                        UpdateDialogueUi(currentNode);
                        AddBranchClick(currentNode as BranchNode);
                        break;
                    case DialogueNode.NextType.Flag:
                        Debug.Log("进入标记框节点");
                        currentNode = currentNode.GetNodeByField("nextFlag");
                        FlagNode flagNode = currentNode as FlagNode;
                        if (flagNode != null && flagNode.flagType == FlagNode.FlagNodeType.End)
                        {
                            Debug.Log("对话流程结束！");
                            dialogueUi.SetActive(false);
                        }
                        break;
                }
            }
            if (contentList.Count > 0)
            {
                content.text = contentList[0];
            }
        }
    }

    /// <summary>
    /// 触发对话框连接的事件
    /// </summary>
    /// <param name="node"></param>
    private void TriggerEvent(EventNode node)
    {
        Debug.Log("触发事件：" + node.eventName);
    }

    void AddBranchClick(BranchNode node)
    {
        for (int i = 0; i < node.branchs.Count; i++)
        {
            var branchPort = node.GetOutputPort("branchs " + i);
            var text = node.branchs[i];
            Debug.Log("增加" + text + "分支");
            var btn = Instantiate(branchPb, dialogueUi.transform.Find("Select").transform, false)
               .GetComponent<Button>();
            branchBtns.Add(btn);
            btn.GetComponentInChildren<Text>().text = text;
            if (branchPort.IsConnected)
            {
                var i1 = i;
                btn.onClick.AddListener(delegate {
                    foreach (var connection in branchPort.GetConnections())
                    {
                        if (connection.node.GetType() == typeof(EventNode))
                        {
                            TriggerEvent(connection.node as EventNode);
                        }
                        if (connection.node.GetType() == typeof(DialogueNode))
                        {
                            Debug.Log("点击分支" + i1 + "进入对话框节点");
                            currentNode = connection.node;
                            contentList.RemoveAt(0);
                            UpdateDialogueUi(currentNode);
                        }
                    }
                    //清楚所有按钮
                    for (int j = branchBtns.Count - 1; j >= 0; j--)
                    {
                        Destroy(branchBtns[j].gameObject);
                        branchBtns.Remove(branchBtns[j]);
                    }
                });
            }
        }
    }

   #endregion
}
