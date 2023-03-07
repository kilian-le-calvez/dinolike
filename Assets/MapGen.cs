using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour
{
    public List<GameObject> rooms;
    private int chunkNb = 0;
    private int chunkSize = 24;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            Instantiate(rooms[i], new Vector3(chunkNb * chunkSize, 0, 0), Quaternion.identity);
            chunkNb += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
