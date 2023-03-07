using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ActionType = State.DinoState_STATIC.ActionType;

public class DinoAction : MonoBehaviour
{
    public State.DinoState state;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            state.changeState(ActionType.IDLE);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            state.changeState(ActionType.WALKING);
    }
}
