using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middleScript : MonoBehaviour
{
    public logicScript logic;
    public AudioClip addPointSound;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer == 3){
            logic.addScore(1);
           
        }
        
    }
}