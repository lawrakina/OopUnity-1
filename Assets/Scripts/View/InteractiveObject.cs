using Interface;
using UnityEngine;

namespace View
{
    public abstract class InteractiveObject: MonoBehaviour, IInteractable
    {
        public bool IsInteractable { get; }
        protected abstract void Interaction();

        private void Start()
        {
            ((IAction)this).Action();
        }

        void IAction.Action()
        {
            // if (TryGetComponent(out Renderer renderer))
            // {
            //     renderer.material.color = Random.ColorHSV();
            // } 
        }

        public void Initialization()
        {
            
        }
    }
}