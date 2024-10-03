using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamend : MonoBehaviour
{   
    #region Attributes

    public Vector3 newpos = new Vector3(0.51f, 3.63f, 0);
    #endregion 

    private bool end = false;


    // Update is called once per frame
    void Update()
    {
        if(end == true){
            return;
        }
    }

    private void OnTriggerEnd(Collider other){

        if (other.tag == "Player"){

            EndGame();
        }
    }

    private void EndGame(){

        end = true;
    }
}
