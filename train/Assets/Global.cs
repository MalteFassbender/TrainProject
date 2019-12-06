using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {
    public static Dictionary<string, bool> interactionTypeList = new Dictionary<string, bool>();

    private void Start()
    {
        interactionTypeList.Add("game", false);
        interactionTypeList.Add("beispiel", false);
    }
}
