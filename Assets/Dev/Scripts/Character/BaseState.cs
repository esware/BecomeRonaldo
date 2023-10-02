using UnityEngine;

namespace Dev.Scripts.Character
{
    public abstract class BaseState<T>
    {
        protected T controller;

        protected BaseState(T controller)
        {
            this.controller = controller;
        }

        public abstract void Update();
        public abstract void FixedUpdate();
    }
}