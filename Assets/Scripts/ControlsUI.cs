using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsUI : MonoBehaviour {

    public Grapple grapple;
    public GameObject TetherInstruction;
    public GameObject MovementInstruction;

    void Update()
    {
        if(grapple.tethered)
        {
            if(TetherInstruction.activeInHierarchy)
            {
                Switch(TetherInstruction);
                Switch(MovementInstruction);
            }
        }
        else
        {
            if (!TetherInstruction.activeInHierarchy)
            {
                Switch(TetherInstruction);
                Switch(MovementInstruction);
            }
        }
    }

    void Switch(GameObject panel)
    {
        panel.gameObject.SetActive(!panel.activeInHierarchy);
    }
}
