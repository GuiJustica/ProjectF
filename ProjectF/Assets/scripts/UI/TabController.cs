using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TabController : MonoBehaviour
{
    public Image[] tabImage;
    public GameObject[] pages;

    // Start is called before the first frame update
    void Start()
    {
        ActivateTab(0);
    }
    public void ActivateTab(int tabNum)
    {
        for(int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
            tabImage[i].color = Color.grey;
        }
        pages[tabNum].SetActive(true);
        tabImage[tabNum].color = Color.white;
    }
}
