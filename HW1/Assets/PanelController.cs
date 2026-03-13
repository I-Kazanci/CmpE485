using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI text;
    private void Start()
    {
    }

    public void enablePanel(string panelType)
    {
        if (panelType == "Win")
        {
            text.text = "YOU WIN!\n WANT TO PLAY AGAIN ?";
        }
        else if (panelType == "Lose")
        {
            text.text = "YOU LOSE :(\n WANT TO PLAY AGAIN ?";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
