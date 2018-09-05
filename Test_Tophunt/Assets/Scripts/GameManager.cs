using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public Transform Player;
    public Transform[] Bat;

    private Vector3 PlayerPosition = new Vector3(0, 1.8f, 0);

    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance!= this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        Init();
    }

    private void Init()
    {
        Instantiate(Player, new Vector3(0,1.8f,0),Quaternion.identity);
        for(int i=0;i<3;i++)
        {
            int BatNumber = Random.Range(0, 3);
            Vector3 EnemyPosition = GenerateBatPosition();
            Transform anotherBat = Instantiate(Bat[BatNumber], EnemyPosition, Quaternion.identity);
            anotherBat.gameObject.name = "Bat " + i;
        }

    }

    public Vector3 GenerateBatPosition()
    {
        Vector3 BatSpawn;
        BatSpawn.y = Random.Range(15, 36) + PlayerPosition.y;

        BatSpawn.x = Random.Range(20, 100);
        BatSpawn.z = Random.Range(20, 100);
        int minus = Random.Range(0, 2);
        if(minus == 0)
        {
            BatSpawn.x = BatSpawn.x * -1;
        }
        minus = Random.Range(0, 2);
        if (minus == 0)
        {
            BatSpawn.z = BatSpawn.z * -1;
        }
        BatSpawn.x = PlayerPosition.x + BatSpawn.x;
        BatSpawn.z = PlayerPosition.z + BatSpawn.z;

        return BatSpawn;
    }
}
