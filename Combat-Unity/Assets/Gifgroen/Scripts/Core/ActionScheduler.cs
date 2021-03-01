using UnityEngine;

namespace Gifgroen.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        private IAction currentAction;

        public void StartAction(IAction a)
        {
            if (currentAction == a)
            {
                return;
            }

            currentAction?.Cancel();
            currentAction = a;
        }

        public void CancelCurrentAction()
        {
            StartAction(null);
        }
    }
}