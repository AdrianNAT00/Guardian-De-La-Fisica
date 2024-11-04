using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatLength;
    public float speed;
    //private float leftBound = -10;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; // Establish the default starting position.
        repeatLength = GetComponent<BoxCollider>().size.z * 2; // Set repeat width to half of the background
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.GameOver)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World); // Move the background backwards
                                                                                     // If background moves left by its repeat width, move it back to start position
            if (transform.position.z < startPos.z - repeatLength)
            {
                transform.position = startPos;
            }
        }
    }
}
