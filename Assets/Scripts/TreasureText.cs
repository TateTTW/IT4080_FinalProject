using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TreasureText : MonoBehaviour
{
    private TMP_Text text;

    private void Awake()
    {
        text = transform.Find("TreasureText").GetComponent<TMP_Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player player = GetComponentInParent<Player>();
        text.text = "Treasure Chests: " + player.playerScoreNetVar.Value;
    }
}
