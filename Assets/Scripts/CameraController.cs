using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    private Vector3 offset;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - player.position;
    }


    void Update()
    {
        //Vector3 targetPosition = player.position + player.TransformDirection(offset);
        //transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothing);
        transform.position = player.position + player.TransformDirection(offset);
        transform.LookAt(player.position);
    }
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    private Vector3 offset;  

    public Vector3 distanse;
    public float speed = 14f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform ;
        offset = transform.position - player.position ;
    }

    private Vector3 temp;
    void Update()
    {
            //Vector3 targetPosition = player.position + player.TransformDirection(offset);
            //transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothing);

            temp = player.position + player.TransformDirection(offset);
            if (temp.y <= 20 && temp.y >= -20 && temp.x <= 39 && temp.x <= 39)
            {
                transform.position = temp;
                transform.LookAt(player.position);
            }
            else if (temp.y > 20 || temp.y < -20)
            {
                transform.localPosition = new Vector3(temp.x, transform.localPosition.y, temp.z);
            }
            else if (temp.x > 39 || temp.x < -39)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, temp.y, temp.z);
            }
            //transform.LookAt(player.position);
        }
}*/
