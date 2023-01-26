using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniDialogue
{
    public class MiniDialogueExample : MonoBehaviour, IDialogueView
    {
        public DialogueData DialogueData;

        public Image Avatar;
        public Text Text;

        public Text OptionTitle;
        public GameObject OptionRoot;
        public GameObject OptionItemPrefab;
        public GameObject TextBoxBg;

        public TextPlayer TextPlayer = new TextPlayer();
        public Coroutine TextPlayerCoroutine = null;

        public AudioSource TypeSound;

        private void Start()
        {
            // 一开始与自己关联
            DialogueController.Default.ConnectView(this);
            DialogueController.Default.SetData(DialogueData);
            DialogueController.Default.Init();
            DialogueController.Default.OnCustomEvent += OnDialogueCustomEvent;

            DialogueController.Default.Translator = (text) =>
            {
                // 多语言
                return text;
            };
        }

        public void OnViewInit()
        {
            Avatar.gameObject.SetActive(false);
            Text.gameObject.SetActive(false);
            OptionTitle.gameObject.SetActive(false);
            OptionRoot.gameObject.SetActive(false);

            OptionItemPrefab.gameObject.SetActive(false);
            TextBoxBg.SetActive(false);
            Text.text = string.Empty;
        }

        private void OnDialogueCustomEvent(string eventName, List<DialogueEventArg> args)
        {
            Debug.Log(eventName + ":" + args.Find(arg => arg.Key == "Count").Value);
        }

        private void OnDestroy()
        {
            DialogueController.Default.Translator = (text) => text;
            DialogueController.Default.OnCustomEvent -= OnDialogueCustomEvent;
            DialogueController.Default.DisconnectView(this);
        }

        private void Update()
        {
            // 这里需要判断下当前的节点是不是选项节点 
            if (Input.GetMouseButtonDown(0))
            {
                // 如果是文字播放，则快进文字播放。
                if (TextPlayerCoroutine != null)
                {
                    StopCoroutine(TextPlayerCoroutine);
                    TextPlayer.Finish();
                }
                else
                {
                    Controller.Step();
                }
            }
        }

        public IDialogueController Controller { get; set; }

        public void OnDialogueStart()
        {
        }

        public void OnDialogueFinish()
        {
            // 结束对话
            Avatar.gameObject.SetActive(false);
            Text.gameObject.SetActive(false);
            OptionTitle.gameObject.SetActive(false);
            OptionRoot.gameObject.SetActive(false);
            TextBoxBg.SetActive(false);
        }

        public void OnDialogueNodeStart(DialogueNode node)
        {
            // 播放之前需要全部关闭
            Avatar.gameObject.SetActive(false);
            Text.gameObject.SetActive(false);
            OptionTitle.gameObject.SetActive(false);
            OptionRoot.gameObject.SetActive(false);
            TextBoxBg.gameObject.SetActive(false);

            if (node.Type == DialogueNodeType.Text)
            {
                // 播放普通对话
                Text.gameObject.SetActive(true);
                TextBoxBg.gameObject.SetActive(true);

                Text.text = string.Empty;
                Controller.StepEnable = false;
                
                TextPlayerCoroutine = StartCoroutine(TextPlayer.StartPlayText(Controller.Translate(node.Sentence),
                    (text) =>
                    {
                        Text.text = text;
                        TypeSound.Play();
                    },
                    () =>
                    {
                        Text.text = Controller.Translate(node.Sentence);
                        Controller.StepEnable = true;
                        Controller.MoveToNext();
                        TextPlayerCoroutine = null;
                        TypeSound.Play();
                    }));
            }

            if (node.Type == DialogueNodeType.TextWithAvatar)
            {
                // 播放头像对话
                Avatar.gameObject.SetActive(true);
                Text.gameObject.SetActive(true);
                TextBoxBg.gameObject.SetActive(true);


                Avatar.sprite = node.Avatar;
                Text.text = string.Empty;
                Controller.StepEnable = false;

                TextPlayerCoroutine = StartCoroutine(TextPlayer.StartPlayText(Controller.Translate(node.Sentence),
                    (text) =>
                    {
                        Text.text = text;
                        TypeSound.Play();
                    },
                    () =>
                    {
                        Text.text = Controller.Translate(node.Sentence);
                        Controller.StepEnable = true;
                        Controller.MoveToNext();
                        TextPlayerCoroutine = null;
                        TypeSound.Play();
                    }));
            }
            else if (node.Type == DialogueNodeType.Option)
            {
                // 播放选项对话
                OptionTitle.gameObject.SetActive(true);
                OptionRoot.gameObject.SetActive(true);

                // 清除掉 OptionRoot 的全部子节点
                var children = OptionRoot.GetComponentsInChildren<Button>();

                foreach (var button in children)
                {
                    if (button.gameObject != OptionItemPrefab)
                    {
                        Destroy(button.gameObject);
                    }
                }

                OptionTitle.text = string.Empty;
                Controller.StepEnable = false;

                TextPlayerCoroutine = StartCoroutine(TextPlayer.StartPlayText(Controller.Translate(node.OptionTitle),
                    (text) =>
                    {
                        OptionTitle.text = text;
                        TypeSound.Play();
                    },
                    () =>
                    {
                        OptionTitle.text = Controller.Translate(node.OptionTitle);
                        TextPlayerCoroutine = null;
                        TypeSound.Play();
                        // 生成选项
                        foreach (var dialogueOption in node.Options)
                        {
                            // 防止按钮点击时出现变量引用错误的问题
                            var cachedDialogueOption = dialogueOption;
                            var optionTitle = Controller.Translate(cachedDialogueOption.Title);
                            var optionItem = Instantiate(OptionItemPrefab, OptionRoot.transform);
                            optionItem.gameObject.SetActive(true);
                            optionItem.GetComponentInChildren<Text>().text = optionTitle;
                            optionItem.GetComponent<Button>().onClick.AddListener(() =>
                            {
                                Controller.StepEnable = true;

                                if (cachedDialogueOption.Data)
                                {
                                    // 将选项对应的对话数据设置给当前的 DialogueData
                                    DialogueData = cachedDialogueOption.Data;
                                    // 从头开始播放
                                    this.Controller.StepAtFirst();
                                }
                                else
                                {
                                    // data 为空说明继续对话
                                    Controller.NextStep();
                                }
                            });
                        }
                    }));
            }
            else if (node.Type == DialogueNodeType.CustomEvent)
            {
                // 触发事件
                Controller.TriggerCustomEvent(node.EventName, node.EventArgs);
                Controller.NextStep();
            }
        }
    }
}