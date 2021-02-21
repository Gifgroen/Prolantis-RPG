using UnityEngine;

namespace Gifgroen.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        private IAction _currentAction;

        public void StartAction(IAction a)
        {
            if (_currentAction == a)
            {
                return;
            }

            if (_currentAction != null)
            {
                _currentAction.Cancel();
            }

            _currentAction = a;
        }
    }
}