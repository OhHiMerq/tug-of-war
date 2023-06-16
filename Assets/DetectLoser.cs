using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLoser : MonoBehaviour
{
    public List<Transform> lPlayers;
    public List<Transform> rPlayers;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "LeftPlayer"){
            lPlayers.Add(col.gameObject.transform);
        }

        if(col.gameObject.tag == "RightPlayer"){
            rPlayers.Add(col.gameObject.transform);
        }

        if(lPlayers.Count == 3 ){
            GameManager.AddRedScore();
        }
        if(rPlayers.Count == 3 ){
            GameManager.AddBlueScore();
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "LeftPlayer"){
            lPlayers.Remove(col.gameObject.transform);
        }
         if(col.gameObject.tag == "Rightlayer"){
            rPlayers.Remove(col.gameObject.transform);
        }
    }
}
