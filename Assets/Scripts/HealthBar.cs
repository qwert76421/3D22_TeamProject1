using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text healthText;
    public int HealthCurrent;
    public int HealthMax;

    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        //HealthCurrent = HealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeHealthBar(int HealthCurrent,int HealthMax){
        //healthBar.fillAmount = (float)HealthCurrent / (float)HealthMax;
        healthBar.fillAmount = 0.3f;
        healthText.text = HealthCurrent.ToString() + "/" + HealthMax.ToString();
    }
}
