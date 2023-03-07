using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ActionType = State.DinoState_STATIC.ActionType;

public class DinoMovement : MonoBehaviour
{
    public GameObject dino;
    public State.DinoState state;
    public float speed;

    private LeaderHandler leaderHandler;

    void Start()
    {
        leaderHandler = GetComponent<LeaderHandler>();
    }

    void Update()
    {
        if (!leaderHandler.isLeader) return;

        Vector3 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (input != Vector3.zero)
        {
            state.changeState(ActionType.WALKING);
            dino.transform.position += input.normalized * Time.deltaTime * speed;
            dino.transform.rotation = Quaternion.Euler(0, input.x < 0 ? 180 : 0, 0);
        }
        else if (state.actionState == ActionType.WALKING)
        {
            state.changeState(ActionType.IDLE);
        }
    }
}
