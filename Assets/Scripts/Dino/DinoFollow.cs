using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ActionType = State.DinoState_STATIC.ActionType;

public class DinoFollow : MonoBehaviour
{
    public float speed;
    public float adaptiveSpeed;
    public GameObject toFollow;
    public GameObject dino;
    public State.DinoState state;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (toFollow == null)
            return;
        Vector2 distance = toFollow.transform.position - dino.transform.position;
        distance.x = Mathf.Abs(distance.x);
        distance.y = Mathf.Abs(distance.y);

        if (distance.x > 0.5f || distance.y > 0.5f)
        {
            float biggestDistance = distance.x > distance.y ? distance.x : distance.y;
            adaptiveSpeed = speed;
            if (GetComponent<LeaderHandler>().type == LeaderType.YELLOW)
                print(biggestDistance);
            adaptiveSpeed += biggestDistance > 1.75f ? 3 : biggestDistance > 1.25f ? 2 : biggestDistance > 0.75f ? 1 : 0;
            state.changeState(ActionType.WALKING);
            dino.transform.position = Vector2.MoveTowards(dino.transform.position, toFollow.transform.position, Time.deltaTime * adaptiveSpeed);
            dino.transform.rotation = Quaternion.Euler(0, distance.x < 0 ? 180 : 0, 0);
        }
        else
        {
            state.changeState(ActionType.IDLE);
        }
    }
}
