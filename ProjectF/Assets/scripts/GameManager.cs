using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{

    public static GameManager Instance { get; private set; }
   
    private int lifes = 10;

    private int money = 0;

    public int Lifes
{
    get { return lifes;  }
    set { lifes = value; }
}

    public int Money
    {
        get { return money;  }
        set { money = value; }


    }

    void Awake(){
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start(){
        
       
    }

    public static void changeScene(string nameScene){
        SceneManager.LoadScene(nameScene);
    }

   

    void Update(){
        
    }
}
