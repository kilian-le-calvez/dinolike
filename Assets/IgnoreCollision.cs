using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    public List<int> layers;

    // Start is called before the first frame update
    void Start()
    {
        foreach (int layer in layers)
        {
            Physics2D.IgnoreLayerCollision(gameObject.layer, layer);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
