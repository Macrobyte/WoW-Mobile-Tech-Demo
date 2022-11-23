using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //Instance
    public static GameManager Instance;




    

    private void Awake()
    {
        Instance = this;
    }

}
 
