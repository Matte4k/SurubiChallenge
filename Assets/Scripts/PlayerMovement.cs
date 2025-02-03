using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float playerSpeed = 10f;
    private float horizontalSpeed = 20f;
    private float rightLimit = 4f;
    private float leftLimit = -3.9f; //kaiba was here
    private float turn;
    public Button left, right;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        left.onClick.AddListener(() => moveLeft());
        right.onClick.AddListener(() => moveRight());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime, Space.World);
        turn = Input.GetAxis("Horizontal");
        if (turn > 0)
        {
            moveRight();
        }
        else if (turn < 0)
        {
            moveLeft();
        }
    }

    public void moveLeft()
    {
        if (this.gameObject.transform.position.x > leftLimit)
        {
            transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime * turn, Space.World);
        }
    }

    public void moveRight()
    {
        if (this.gameObject.transform.position.x < rightLimit)
        {
            transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime * turn, Space.World);
        }
    }

}
