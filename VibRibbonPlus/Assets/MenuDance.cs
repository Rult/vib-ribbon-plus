using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDance : MonoBehaviour
{
    Vector3 og;
    bool up;
    // Start is called before the first frame update
    void Start()
    {
        og = transform.position;
        up = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(up)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(og.x, og.y + 1, og.z), Random.Range(5,10) * Time.deltaTime);
        }    
        else
        {
            transform.position = Vector3.Lerp(transform.position, og, Random.Range(5, 10) * Time.deltaTime);
        }
        if(Vector3.Distance(transform.position, new Vector3(og.x, og.y + 1, og.z)) <= .1f)
        {
            up = false;
        }
        if(Vector3.Distance(transform.position, og) <= .1f)
        {
            up = true;
        }
    }
}
