using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Material [] quads;
    public GameObject B;
    public Material bf;
    private int x,y,z;
    // Start is called before the first frame update
    void Start()
    {
        //x = UnityEngine.Random.Range(0, 10);
        //y = UnityEngine.Random.Range(0, 10);
        //z = UnityEngine.Random.Range(0, 10);
        //quads[x].color = Color.green;
        //quads[y].color = Color.green;
        //quads[z].color = Color.green;
        bf.color = Color.black;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
