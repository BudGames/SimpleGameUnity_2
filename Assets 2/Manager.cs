using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject Ground;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Make());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator Make()
    {
        yield return new WaitForSeconds(Random.Range(1.1f , 2f));

        Instantiate(Ground , new Vector3(Random.Range(-4 , 4) , 8 , 0) , Quaternion.identity);

        StartCoroutine(Make());
    }
}
