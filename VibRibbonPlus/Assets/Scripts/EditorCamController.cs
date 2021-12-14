using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorCamController : MonoBehaviour
{
    private int speed;
    private bool speedup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(speedup)
            StartCoroutine(Speedup());
        }
        else
        {
            speed = 10;
            speedup = true;
        }
    }

    IEnumerator Speedup()
    {
        speedup = false;
        speed = 20;
        yield return new WaitForSeconds(3);
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            speed = 40;
        }
    }
}
