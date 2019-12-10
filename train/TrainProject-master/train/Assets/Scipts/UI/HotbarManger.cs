using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HotbarManger : MonoBehaviour
{

	void Start()
    {

	}

	void Update()
    {
        HotbarButtonActivation();
	}

    void HotbarButtonActivation()
    {
        if (HotbarMenu.button1 == true)
        {
            Debug.Log("1");
        }
        if (HotbarMenu.button2 == true)
        {
            Debug.Log("2");
        }
        if (HotbarMenu.button3 == true)
        {
            Debug.Log("3");
        }
        if (HotbarMenu.button4 == true)
        {
            Debug.Log("4");
        }
        if (HotbarMenu.button5 == true)
        {
            Debug.Log("5");
        }
        if (HotbarMenu.button6 == true)
        {
            Debug.Log("6");
        }
        if (HotbarMenu.button7 == true)
        {
            Debug.Log("7");
        }
        if (HotbarMenu.button8 == true)
        {
            Debug.Log("8");
        }
        if (HotbarMenu.button9 == true)
        {
            Debug.Log("9");
        }
        if (HotbarMenu.button10 == true)
        {
            Debug.Log("10");
        }
    }
}