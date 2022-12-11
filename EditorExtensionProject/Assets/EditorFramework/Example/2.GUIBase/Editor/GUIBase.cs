using System;
using UnityEngine;

namespace EditorFramework
{
    public abstract class GUIBase : IDisposable
    {
        public bool Disposed { get; private set; }
        public Rect Position { get; private set; }

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