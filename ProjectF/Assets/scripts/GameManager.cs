using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{

    public static GameManager Instance { get; private set; }

    private int lifes = 10;

    private int money = 0;

    private bool passouGinasio = false;
    private bool passouPredioK = false;
    private bool passouCastelinho = false;

    private bool buyFeathers = false;

    public int Lifes{
        get { return lifes;  }
        set { lifes = value; }
    }

    public int Money{
        get { return money;  }
        set { money = value; }
    }

    public bool PassouGinasio{

        get { return passouGinasio;  }
        set { passouGinasio = value; }
    }

    public bool PassouPredioK{

        get { return passouPredioK;  }
        set { passouPredioK = value; }
    }

    public bool PassouCastelinho{

        get { return passouCastelinho;  }
        set { passouCastelinho = value; }
    }

    public bool BuyFeathers{

        get { return buyFeathers;  }
        set { buyFeathers = value; }
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
        if(lifes <= 0){
            Destroy(gameObject);
            changeScene("Derrota");
            Debug.Log("Zero de vida");
        }
    }
}
