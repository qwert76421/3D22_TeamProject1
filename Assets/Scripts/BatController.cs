using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BatController : MonoBehaviour
{
    public GameObject myObj;
    public ScoreTextController scoretextcontroller;
    public float speed = 14f;
    public Vector3 distance;
    public UFOController alive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (alive.isDie() == true){
            Time.timeScale = 0f;
        }else{
            Time.timeScale = 1f;
            transform.RotateAround(myObj.transform.localPosition+distance, new Vector3(0, 0, 1), -0.5f);

            if (Input.GetKey(KeyCode.A) && myObj.transform.localPosition.x > -50)
            {
                transform.localPosition += new Vector3(-speed, 0, 0) * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D) && myObj.transform.localPosition.x < 40)
            {
                transform.localPosition += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S) && myObj.transform.localPosition.y > -25)
            {
                transform.localPosition += new Vector3(0, -speed, 0) * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.W) && myObj.transform.localPosition.y < 25)
            {
                transform.localPosition += new Vector3(0, speed, 0) * Time.deltaTime;
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        PickupController pc = other.transform.GetComponent<PickupController>();
        if (other.gameObject.tag == "pickup")
        {
            if(pc.getBlood()==1){
                scoretextcontroller.AddScore(pc.getScoreBase());
                Destroy(other.gameObject);
            }    
            else{
                pc.hurt();
            }
                
        }
        transform.RotateAround(myObj.transform.localPosition+distance, new Vector3(0, 0, 1), -0.5f);    
    }
    
}