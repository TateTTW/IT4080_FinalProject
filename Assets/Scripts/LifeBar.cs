using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : NetworkBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponentInChildren<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Player player = GetComponentInParent<Player>();
        image.fillAmount = player.health.Value / player.fullHealth.Value;
    }
}
