using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBossSceneNA : MonoBehaviour
{

    public GameObject Boss;
    public GameObject Player;

    public GameObject Boundary;
    public GameObject Boundary2;
    public GameObject Boundary3;


    // Start is called before the first frame update
    void Start()
    {
        Boss = Instantiate(Boss);
        Boss.transform.position = Vector3.zero;
        Player = Instantiate(Player);
        Player.transform.position = new Vector3(0, -20, 0);

        //CreateLevel();      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateLevel()
    {
        Boundary = Instantiate(Boundary);
        Boundary.transform.position = new Vector3(14.8f, -60.3f, 2.8f);
        

        Boundary2 = Instantiate(Boundary);
        Boundary2.transform.position = new Vector3(-21.96291f, -23.76254f, 2.86978f);
        

        Boundary3 = Instantiate(Boundary);
        Boundary3.transform.position = new Vector3(22.4f, -23.76254f, 2.86978f);
        

    }

}
