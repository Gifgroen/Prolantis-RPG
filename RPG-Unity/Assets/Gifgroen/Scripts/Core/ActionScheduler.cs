using UnityEngine;

namespace Gifgroen.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        private IActionable _currentActionable;

        public void StartAction(IActionable a)
        {
            if (_currentActionable == a)
            {
                return;
            }

            TryStopAction();
            _currentActionable = a;
        }

        public void StopAction()
        {
            // TryStopAction();
        }

        private void TryStopAction()
        {
            if (_currentActionable == null) return;
            _currentActionable.Cancel();
            _currentActionable = null;
        }
    }

    public interface IActionable
    {
        void Cancel();
    }
}