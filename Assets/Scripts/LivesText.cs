using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesText : MonoBehaviour
{
    private TMP_Text text;

    private void Awake()
    {
        text = transform.Find("LivesText").GetComponent<TMP_Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player player = GetComponentInParent<Player>();
        text.text = "Lives: " + player.playerLivesNetVar.Value;
    }
}
