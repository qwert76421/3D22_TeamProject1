using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class PickupController : MonoBehaviour
{
    public float rotateAngle = 45f;
    public float speed = 0.2f;
    public int scoreBase = 1;
    public int blood = 1;
    public GameObject player;
    // Start is called before the first frame update
    public UFOController alive;

    void Start()
    {
        this.transform.Rotate(new Vector3(0, 0, rotateAngle * Time.deltaTime));
    }
    // Update is called once per frame
    void Update()
    {
        if(alive.isDie() == true){
            Time.timeScale = 0f;
        }else{
            Time.timeScale = 1f;
            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.fixedDeltaTime);
        }
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        UFOController ufo = collision.transform.GetComponent<UFOController>();
        if (ufo != null)
        {
            ufo.Damaged(100);
            Destroy(gameObject);
        }
    }

    public int getScoreBase(){
        return scoreBase;
    }
    public int getBlood(){
        return blood;
    }
    public void hurt(){
        blood--;
    }
}
