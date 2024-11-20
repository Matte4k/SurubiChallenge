using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public LifeSystem lifeSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(detectHit());
    }

    IEnumerator detectHit()
    {
        lifeSystem.hitRegister();
        yield return new WaitForSeconds(3);
    }
}
