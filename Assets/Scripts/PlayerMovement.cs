using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerSpeed = 10f;
    private float horizontalSpeed = 12f;
    private float rightLimit = 4f;
    private float leftLimit = -3.9f; //kaiba was here

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime, Space.World);
        float turn = Input.GetAxis("Horizontal");
        if (turn > 0)
        {
            if (this.gameObject.transform.position.x < rightLimit)
            {
                transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime * turn, Space.World);
            }
        }
        else if (turn < 0)
        {
            if (this.gameObject.transform.position.x > leftLimit)
            {
                transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime * turn, Space.World);
            }
        }
    }
}
