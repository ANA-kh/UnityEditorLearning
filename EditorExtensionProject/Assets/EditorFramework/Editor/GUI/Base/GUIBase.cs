using System;
using UnityEngine;

namespace EditorFramework
{
    public abstract class GUIBase : IDisposable
    {
        protected bool Disposed { get; set; }
        protected Rect Position { get; set; }

        public virtual void OnGUI(Rect position)
        {
            Position = position;
        }

        public virtual void Dispose()
        {
            if (Disposed) return;
            OnDispose();
            Disposed = true;
        }

        protected virtual void OnDispose() { }
    }
}