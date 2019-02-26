using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 90;

    // Update is called once per frame
    void Update()
    {
        //顺时针旋转
        transform.Rotate(new Vector3(0, 0, -speed * Time.deltaTime));
    }
}
