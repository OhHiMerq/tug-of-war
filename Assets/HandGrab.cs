using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrab : MonoBehaviour
{   
    public Transform chain; 
    // Start is called before the first frame update
    void Start()
    {
        chain.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
