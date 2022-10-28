using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BestController : MonoBehaviour
{

    public ScoreTextController scoreTextController;
    public int curr;
    public static int best;
    public Text bestScore;

    public UFOController alive;
    // Start is called before the first frame update
    void Start()
    {
        curr = scoreTextController.currScore;
        bestScore = this.GetComponent<Text>();

        // if (!File.Exists("Assets/Scripts/best.txt"))
        // {
        //     File.WriteAllText("Assets/Scripts/best.txt", "0");
        // }
        // best = int.Parse(File.ReadAllText("Assets/Scripts/best.txt"));
        bestScore.text = "BEST: " + best.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        curr = scoreTextController.currScore;
        if (curr > best)
        {
            best = curr;
            bestScore.text = "BEST: " + best.ToString();
            // File.WriteAllText("Assets/Scripts/best.txt", best.ToString());
        }
    }
    public int getBest(){
        return best;
    }
}
