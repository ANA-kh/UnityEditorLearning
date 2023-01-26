using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace MiniDialogue
{
    [CreateAssetMenu(fileName = "New Dialogue Data", menuName = "MiniDialogue/Create Dialogue")]
    public class DialogueData : ScriptableObject
    {
        public List<DialogueNode> Nodes;
    }

    // 需要定义一下类型
    public enum DialogueNodeType
    {
        Text,
        TextWithAvatar,
        Option,
        CustomEvent
    }

    [System.Serializable]
    public class DialogueNode
    {
        public DialogueNodeType Type;

        // 头像
        public Sprite Avatar;

        // 句子
        public string Sentence;

        // 选项的标题
        public string OptionTitle;

        // 选项
        public List<DialogueOption> Options;

        // 事件名
        public string EventName;

        // 事件参数
        public List<DialogueEventArg> EventArgs;
    }

    [System.Serializable]
    public class DialogueOption
    {
        public string Title;
        public DialogueData Data;
    }

    [System.Serializable]
    public class DialogueEventArg
    {
        public string Key;
        public string Value;
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(DialogueNode))]
    public class DialogueNodeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // base.OnGUI(position, property, label);

            EditorGUI.BeginProperty(position, label, property);

            // 每一行高度一般是 18，但是 20 可以得到更舒服的间距
            var type = property.FindPropertyRelative("Type");
            var sentence = property.FindPropertyRelative("Sentence");
            var avatar = property.FindPropertyRelative("Avatar");
            var optionTitle = property.FindPropertyRelative("OptionTitle");
            var options = property.FindPropertyRelative("Options");
            var eventName = property.FindPropertyRelative("EventName");
            var eventArgs = property.FindPropertyRelative("EventArgs");

            var typePosition = position;
            typePosition.height = 20;
            EditorGUI.PropertyField(typePosition, type);
            position.y += 20;

            if (type.intValue == (int)DialogueNodeType.Text)
            {
                var sentencePosition = position;
                sentencePosition.height = 20;
                EditorGUI.PropertyField(sentencePosition, sentence);
                position.y += sentencePosition.height;
            }
            else if (type.intValue == (int)DialogueNodeType.TextWithAvatar)
            {
                var avatarPosition = position;
                avatarPosition.height = 20;
                EditorGUI.PropertyField(avatarPosition, avatar);
                position.y += avatarPosition.height;

                var sentencePosition = position;
                sentencePosition.height = 20;
                EditorGUI.PropertyField(sentencePosition, sentence);
                position.y += sentencePosition.height;
            }
            else if (type.intValue == (int)DialogueNodeType.Option)
            {
                var optionTitlePosition = position;
                optionTitlePosition.height = 20;
                EditorGUI.PropertyField(optionTitlePosition, optionTitle);
                position.y += optionTitlePosition.height;

                var optionsPosition = position;
                optionsPosition.height = options.arraySize * 20 + 20; // 多加 20 是有加减符号
                EditorGUI.PropertyField(optionsPosition, options);
                position.y += optionsPosition.height;
            }
            else if (type.intValue == (int)DialogueNodeType.CustomEvent)
            {
                var eventNamePosition = position;
                eventNamePosition.height = 20;
                EditorGUI.PropertyField(eventNamePosition, eventName);
                position.y += eventNamePosition.height;

                var eventArgsPosition = position;
                eventArgsPosition.height = eventArgs.arraySize * 20 + 20;
                EditorGUI.PropertyField(eventArgsPosition, eventArgs);
                position.y += eventArgsPosition.height;
            }


            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (property.FindPropertyRelative("Type").intValue == (int)DialogueNodeType.Text)
            {
                return 40;
            }

            if (property.FindPropertyRelative("Type").intValue == (int)DialogueNodeType.TextWithAvatar)
            {
                return 60;
            }

            if (property.FindPropertyRelative("Type").intValue == (int)DialogueNodeType.Option)
            {
                return 40 + property.FindPropertyRelative("Options").CountInProperty() * 20 + 20; // 多加 20 是有加减符号
            }

            if (property.FindPropertyRelative("Type").intValue == (int)DialogueNodeType.CustomEvent)
            {
                return 40 + property.FindPropertyRelative("EventArgs").CountInProperty() * 20 + 20; // 多加 20 是有加减符号
            }

            return 20;
        }
    }
#endif
}