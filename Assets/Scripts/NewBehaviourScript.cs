using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI mouseRaw;
    [SerializeField] TextMeshProUGUI mouseScreen;
    [SerializeField] TextMeshProUGUI direction;


    // Update is called once per frame
    void Update()
    {
        
        mouseScreen.text = "Mouse Screen: " + Camera.main.ScreenToWorldPoint(Input.mousePosition).ToString();
        var collider2D = GetComponent<Collider2D>();
        var dir = ((Camera.main.ScreenToWorldPoint(Input.mousePosition) - collider2D.bounds.center));
        direction.text = "Direction: " + dir.ToString() ;
        var normalized = dir.normalized;
        mouseRaw.text = "Direction Normalized: " + normalized.ToString();

    }
}
