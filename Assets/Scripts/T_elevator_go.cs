using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_elevator_go : MonoBehaviour
{
    Vector3[] locations;
    float speed = 3;
    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        int count = 5;
        locations = new Vector3[count];
        Vector3 startPos=transform.position;

        for (int i = 0; i < count; i++)
        {
            float yValue = 0.5f + (i * 5f);
            locations[i] = startPos + new Vector3(0, yValue, 0);
        }

        ChooseRandomTarget();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=Vector3.MoveTowards(transform.position,target,speed*Time.deltaTime);
        
        if(transform.position==target)
        {
            new WaitForSeconds(3f);
            //GetComponent<StopMovement>().StopForSeconds(3);
            Vector3 target= ChooseRandomTarget();
        }
        
    }

    Vector3 ChooseRandomTarget()
    {
        int randomIndex = Random.Range(0, locations.Length);
        return locations[randomIndex];
    }

}
