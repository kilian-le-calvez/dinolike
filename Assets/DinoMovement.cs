using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ActionType = State.DinoState_STATIC.ActionType;

public class DinoMovement : MonoBehaviour
{
    public GameObject dino;
    public State.DinoState state;
    public float speed;

    void Start()
    {

    }

    void Update()
    {
        Vector3 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (input != Vector3.zero)
        {
            state.changeState(ActionType.WALKING);
            dino.transform.position += input.normalized * Time.deltaTime * speed;
        }
    }
}
