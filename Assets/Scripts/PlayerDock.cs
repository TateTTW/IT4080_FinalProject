using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Netcode;
using UnityEngine;

public class PlayerDock : NetworkBehaviour
{
    public NetworkVariable<Color> colorNetVar = new NetworkVariable<Color>(Color.clear);

    void Awake()
    {
        ApplyColor();
        colorNetVar.OnValueChanged += OnColorChanged;
    }

    private void OnColorChanged(Color previousValue, Color newValue)
    {
        ApplyColor();
    }

    private void ApplyColor()
    {
        foreach (Transform item in transform)
        {
            foreach (Transform nestedItem in item)
            {
                nestedItem.GetComponent<MeshRenderer>().material.color = colorNetVar.Value;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
