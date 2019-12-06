using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HotbarMenu : MonoBehaviour
{
    public static bool button1 = false;
    public static bool button2 = false;
    public static bool button3 = false;
    public static bool button4 = false;
    public static bool button5 = false;
    public static bool button6 = false;
    public static bool button7 = false;
    public static bool button8 = false;
    public static bool button9 = false;
    public static bool button10 = false;


    public void HotbarButton1()
    {
        if (!button1)
        {
            button2 = false;
            button3 = false;
            button4 = false;
            button5 = false;
            button6 = false;
            button7 = false;
            button8 = false;
            button9 = false;
            button10 = false;
            button1 = true;
        }
        else
        {
            button1 = false;
        }
    }
    public void HotbarButton2()
    {
        if (!button2)
        {
            button1 = false;
            button3 = false;
            button4 = false;
            button5 = false;
            button6 = false;
            button7 = false;
            button8 = false;
            button9 = false;
            button10 = false;
            button2 = true;
        }
        else
        {
            button2 = false;
        }
    }
    public void HotbarButton3()
    {
        if (!button3)
        {
            button1 = false;
            button2 = false;
            button4 = false;
            button5 = false;
            button6 = false;
            button7 = false;
            button8 = false;
            button9 = false;
            button10 = false;
            button3 = true;
        }
        else
        {
            button3 = false;
        }
    }
    public void HotbarButton4()
    {
        if (!button4)
        {
            button1 = false;
            button2 = false;
            button3 = false;
            button5 = false;
            button6 = false;
            button7 = false;
            button8 = false;
            button9 = false;
            button10 = false;
            button4 = true;
        }
        else
        {
            button4 = false;
        }
    }
    public void HotbarButton5()
    {
        if (!button5)
        {
            button1 = false;
            button2 = false;
            button3 = false;
            button4 = false;
            button6 = false;
            button7 = false;
            button8 = false;
            button9 = false;
            button10 = false;
            button5 = true;
        }
        else
        {
            button5 = false;
        }
    }
    public void HotbarButton6()
    {
        if (!button6)
        {
            button1 = false;
            button2 = false;
            button3 = false;
            button4 = false;
            button5 = false;
            button7 = false;
            button8 = false;
            button9 = false;
            button10 = false;
            button6 = true;
        }
        else
        {
            button6 = false;
        }
    }
    public void HotbarButton7()
    {
        if (!button7)
        {
            button1 = false;
            button2 = false;
            button3 = false;
            button4 = false;
            button5 = false;
            button6 = false;
            button8 = false;
            button9 = false;
            button10 = false;
            button7 = true;
        }
        else
        {
            button7 = false;
        }
    }
    public void HotbarButton8()
    {
        if (!button8)
        {
            button1 = false;
            button2 = false;
            button3 = false;
            button4 = false;
            button5 = false;
            button6 = false;
            button7 = false;
            button9 = false;
            button10 = false;
            button8 = true;
        }
        else
        {
            button8 = false;
        }
    }
    public void HotbarButton9()
    {
        if (!button9)
        {
            button1 = false;
            button2 = false;
            button3 = false;
            button4 = false;
            button5 = false;
            button6 = false;
            button7 = false;
            button8 = false;
            button10 = false;
            button9 = true;
        }
        else
        {
            button9 = false;
        }
    }
    public void HotbarButton10()
    {
        if (!button10)
        {
            button1 = false;
            button2 = false;
            button3 = false;
            button4 = false;
            button5 = false;
            button6 = false;
            button7 = false;
            button8 = false;
            button9 = false;
            button10 = true;
        }
        else
        {
            button10 = false;
        }
    }
}