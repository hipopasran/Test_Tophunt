using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatManager : MonoBehaviour
{

    public BatMovement Controller;
    public bool IsWaiting = true;
    public Transform Point;
    public Transform CurrentTarget;
    public EventManager _eventManager = new EventManager();
    

	void Start () {
        Controller = GetComponent<BatMovement>();
        Timer();
	}

	void Update () {
        if (!IsWaiting)
        {
            Controller.Move();
        }
        if(transform.position == Controller.Target)
        {
            IsWaiting = true;
        }
	}

    public void Timer()
    {
        IsWaiting = true;
        int TimeToGo = Random.Range(1,11);
        StartCoroutine(Wait(TimeToGo));
        

    }

    IEnumerator Wait(int TimeToGo)
    {
        while (TimeToGo !=0)
        {
            Debug.Log( gameObject.name+ " " + TimeToGo);
            TimeToGo--;
            yield return new WaitForSeconds(1);
            
        }
        IsWaiting = false;
        yield return null;
    }

    public Transform InitNewPoin(Vector3 newPoint)
    {
        Transform NewPoint = Instantiate(Point, newPoint, Quaternion.identity);
        CurrentTarget = NewPoint;
        NewPoint.gameObject.name = gameObject.name + "_Point";

        return NewPoint;
    }

    public Vector3 GetNextPoint()
    {
        Vector3 BatSpawn;
        BatSpawn.y = Random.Range(15, 36) + Controller.Target.y;

        BatSpawn.x = Random.Range(20, 100);
        BatSpawn.z = Random.Range(20, 100);
        int minus = Random.Range(0, 2);
        if (minus == 0)
        {
            BatSpawn.x = BatSpawn.x * -1;
        }
        minus = Random.Range(0, 2);
        if (minus == 0)
        {
            BatSpawn.z = BatSpawn.z * -1;
        }
        BatSpawn.x = Controller.Target.x + BatSpawn.x;
        BatSpawn.z = Controller.Target.z + BatSpawn.z;

        return BatSpawn;
    }
}
