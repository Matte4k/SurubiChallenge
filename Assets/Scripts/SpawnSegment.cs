using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSegment : MonoBehaviour
{
    public GameObject[] section;
    private int zPos = 250;
    private int secNum;
    private bool creatingSection = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!creatingSection)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 4);
        Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 250;
        yield return new WaitForSeconds(25);
        creatingSection = false;
    }
}
