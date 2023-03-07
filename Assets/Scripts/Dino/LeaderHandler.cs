using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LeaderType
{
    BLUE = 0,
    RED = 1,
    GREEN = 2,
    YELLOW = 3
}

public class LeaderHandler : MonoBehaviour
{
    public bool isLeader;
    public LeaderType type;

    private DinoFollow follow;
    private int index;

    static public List<LeaderHandler> dinos = new List<LeaderHandler>() { null, null, null, null };

    // Start is called before the first frame update
    void Start()
    {
        isLeader = false;
        follow = GetComponent<DinoFollow>();
        index = dinos.Count;
        dinos[(int)type] = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            changeLeader(LeaderType.BLUE);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            changeLeader(LeaderType.RED);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            changeLeader(LeaderType.GREEN);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            changeLeader(LeaderType.YELLOW);

    }

    void changeLeader(LeaderType type)
    {
        LeaderHandler handler;
        for (int i = 0; i < dinos.Count; i++)
        {
            handler = dinos[i].GetComponent<LeaderHandler>();
            handler.isLeader = false;
            handler.follow.toFollow = dinos[i == dinos.Count - 1 ? 0 : i + 1].follow.dino;
        }
        handler = dinos[(int)type].GetComponent<LeaderHandler>();
        handler.isLeader = true;
        handler.follow.toFollow = null;
    }
}
