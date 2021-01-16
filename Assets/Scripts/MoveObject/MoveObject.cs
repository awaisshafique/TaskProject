using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    bool isInit = true;

    float speed;

    public Transform target;

    bool doneMoving;

   public void Init(float speed , Transform target)
   {
        
        this.speed = speed;
        this.target = target;
        isInit = true;
    }


    private void Update()
    {
        if(isInit)
        {
            if (doneMoving)
                return;

            Vector3 movePlayer = (target.transform.position - transform.position);

            movePlayer.Normalize();

            transform.position += movePlayer * speed * Time.deltaTime ;

            if(Vector3.Distance(transform.position  , target.position) < 0.5f)
            {
                transform.position = target.transform.position;
                doneMoving = true;
                GetComponent<Collider>().enabled = false;
            }

        }
    }



    public float GetSpeed()
    {
        return speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.GetComponent<MoveObject>();
        if (obj)
        {
            if(obj.GetSpeed() < speed)
            {
                Destroy(obj.gameObject);
            }

            else
            {
                Destroy(this.gameObject);
            }
            
        }
    }


}
