using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextController : MonoBehaviour
{
    public int initialScore;

    public int currScore;

    public Text _text;

    // Start is called before the first frame update
    void Start()
    {
        currScore = initialScore;
        _text = this.GetComponent<Text>();
        _text.text = "SCORE: " + currScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int add){
        currScore += 100 * add;
        _text.text = "SCORE: " + currScore.ToString();
    }
    public int getScore(){
        return currScore;
    }
}
