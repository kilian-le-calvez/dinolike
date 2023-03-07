using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State
{
    using static DinoState_STATIC;

    public class DinoState_STATIC
    {
        public enum ActionType
        {
            WALKING,
            IDLE
        };
    }

    public class DinoState : MonoBehaviour
    {
        public ActionType actionState;
        private ActionType lastState;

        void Start()
        {
            lastState = ActionType.WALKING;
            actionState = ActionType.IDLE;
        }

        public void changeState(ActionType newState)
        {
            actionState = newState;
        }

        public bool hasChanged()
        {
            if (lastState == actionState)
                return false;
            lastState = actionState;
            return true;
        }
    }
}
