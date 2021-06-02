using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUp : MonoBehaviour
{

    public float Speed = 5f;
    Vector3 temp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //originaly
        // transform.locale.x += 5f;
        if (Input.GetKeyDown(KeyCode.Space))
        {

            temp = transform.localScale;

            temp.x += Time.fixedDeltaTime;
            temp.y += Time.fixedDeltaTime;
            temp.z += Time.fixedDeltaTime;
            transform.localScale = temp;
        }
        
    }
}
