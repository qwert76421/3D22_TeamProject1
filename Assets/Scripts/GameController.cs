
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PickupController[] m_Clone = null;
    public GameObject player;
    public float m_TimeValue = 0;
    private float m_Delay = 0;
    private int m_TimeRank =0;
    private float m_AddTime = 0;
    private const float m_MathTime = 10;
    

    public UFOController alive;

    //public GameObject pickup;
    public int startPickupsNumber;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        m_Delay = Time.time + 1;
        m_AddTime = m_MathTime;
    }

    void Update()
    {
        if (alive.isDie() == true){
            Time.timeScale = 0f;
            m_TimeValue = 0;
            m_Delay = 0;
            m_TimeRank =0;
            m_AddTime = 0;
        }else{
            Time.timeScale = 1f;
            m_TimeValue += Time.deltaTime;

            if(m_Delay < Time.time){
                m_Delay = Time.time + 1;
                //player = GameObject.FindGameObjectWithTag("Player");
                Create();
            }

            if(m_TimeValue > m_AddTime){
                m_TimeRank++;
                Time.timeScale = 1 + m_TimeRank * 0.05f;
                m_AddTime += m_MathTime;
            }
        }
    }

    private void Create(){
        PickupController unit = GetCreateObject();
        PickupController createUnit = Instantiate<PickupController>(unit);

        int r = Random.Range(0, 100);
        if(r % 4 == 0){
            createUnit.transform.localPosition = new Vector3(player.transform.localPosition.x - Random.Range(3f,10f) , player.transform.localPosition.y - Random.Range(3f,10f) , 0);
        }
        if(r % 4 == 1){
            createUnit.transform.localPosition = new Vector3(player.transform.localPosition.x - Random.Range(3f,10f) , player.transform.localPosition.y + Random.Range(3f,10f) , 0);
        }
        if(r % 4 == 2){
            createUnit.transform.localPosition = new Vector3(player.transform.localPosition.x + Random.Range(3f,10f) , player.transform.localPosition.y - Random.Range(3f,10f) , 0);
        }
        if(r % 4 == 3){
            createUnit.transform.localPosition = new Vector3(player.transform.localPosition.x + Random.Range(3f,10f) , player.transform.localPosition.y + Random.Range(3f,10f) , 0);
        }
    }

    private PickupController GetCreateObject(){
        int r = Random.Range(0, 50);

        int first = m_TimeRank > 0 ? 10 : 0;
        int second = m_TimeRank > 1 ? 10 : 0;
        int third = m_TimeRank > 2 ? 10 : 0;
        int fourth = m_TimeRank > 3 ? 10 : 0;

        r -= first;
        if(r < 0){
            return m_Clone[0];
        }
        r -= second;
        if(r < 0){
            return m_Clone[1];
        }
        r -= third;
        if(r < 0){
            return m_Clone[2];
        }
        r -= fourth;
        if(r < 0){
            return m_Clone[3];
        }
        return m_Clone[0];
    }
        
}