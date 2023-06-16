using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
   [SerializeField] public static float blueScore = 0f;
   [SerializeField] public static float redScore = 0f;

    public TextMeshProUGUI blueScoreUI;
    public TextMeshProUGUI redScoreUI;
    // Start is called before the first frame update
    void Start()
    {
        blueScoreUI.text = blueScore.ToString();
        redScoreUI.text = redScore.ToString();
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
}
