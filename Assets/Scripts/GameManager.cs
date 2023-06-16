using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
   public static float blueScore = 0f;
  public static float redScore = 0f;

    public TextMeshProUGUI blueScoreUI;
    public TextMeshProUGUI redScoreUI;
    // public static GameObject winCard;
    public TextMeshProUGUI winTitle;
    // Start is called before the first frame update
    void Start()
    {

        if(blueScore >= 3){
            winTitle.text = "BLUE WINS";
            Invoke("ResetScene",3);
        }
        else if(redScore >= 3){
            winTitle.text = "RED WINS";

             Invoke("ResetScene",3);
        }
        else{
            blueScoreUI.text = blueScore.ToString();
            redScoreUI.text = redScore.ToString();
            winTitle.text = "";
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void AddBlueScore(){
        blueScore += 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void AddRedScore(){
        redScore += 1;
SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResetScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        blueScore = 0;
        redScore = 0;
    }

}
