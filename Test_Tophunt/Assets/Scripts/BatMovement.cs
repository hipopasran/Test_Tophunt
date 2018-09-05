using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{

    public float velocity = 10f;
    public float rotationDamp = .5f;

    public Transform NonTargetCollider;
    public BatManager Manager;
    public Transform Player;
    public Vector3 Target;

    public string nameMissTarget;

    void Start () {

        Manager = GetComponent<BatManager>();
        nameMissTarget = gameObject.name + "_Miss";
        GetTarget();
    }
	
	public void Move () {
        if (Player != null)
        {
            TurnTo(Target);
            Fly();
        }
        else
        {
            GetTarget();

            TurnTo(Target);
            Fly();
        }

	}

    void TurnTo(Vector3 target)
    {
        Vector3 Pos = target - transform.position;
        Quaternion Rotation = Quaternion.LookRotation(Pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, Rotation, rotationDamp * Time.deltaTime);
    }

    void Fly()
    {
        transform.position += transform.forward * velocity * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            Manager._eventManager.OnHited();
            Debug.Log("Player");
            if (Manager.CurrentTarget.gameObject.tag != "Point")
            {
                Target = Manager.InitNewPoin(Manager.GetNextPoint()).position;
            }
        }

        if(other.gameObject.name == nameMissTarget)
        {
            Debug.Log("Miss");
            Destroy(other.gameObject);
            if (Manager.CurrentTarget.gameObject.tag != "Point")
            {
                Target = Manager.InitNewPoin(Manager.GetNextPoint()).position;
            }
        }


    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Point")
        {
            Destroy(other.gameObject);
            Manager.Timer();
            

            GetTarget();
        }
    }

    void GetTarget()
    {
        if(Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
           
        Target = Player.position;

        Transform MissTarget = Instantiate(NonTargetCollider, Target, Quaternion.identity);
        MissTarget.gameObject.name = nameMissTarget;
        Manager.CurrentTarget = MissTarget;
    }
}
