using System;
using System.Collections;
using UnityEngine;

namespace MiniDialogue
{
    public class TextPlayer
    {
        private string mCurrentSentence = string.Empty;

        private Action mOnFinish;
        public IEnumerator StartPlayText(string sentence,Action<string> OnPlayText,Action onFinish = null)
        {
            mCurrentSentence = sentence;
            mOnFinish = onFinish;
            
            var sentenceToPlay = string.Empty;

            var length = mCurrentSentence.Length;

            for (var i = 0; i < length; i++)
            {
                // 一秒播放 10 个字符
                yield return new WaitForSeconds(0.1f);
                
                // 截取字符串
                sentenceToPlay = mCurrentSentence.Substring(0, i);
                
                // 设置文本
                OnPlayText?.Invoke(sentenceToPlay);
            }

            yield return new WaitForSeconds(0.1f);

            sentenceToPlay = mCurrentSentence;
            
            OnPlayText?.Invoke(sentenceToPlay);
            
            Finish();
        }

        public void Finish()
        {
            mOnFinish?.Invoke();
            mOnFinish = null;
        }
    }
}