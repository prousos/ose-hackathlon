using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetRailActive : MonoBehaviour
{
    [SerializeField] GameObject theRailWay;
    [SerializeField] Slider aSlider;
    [SerializeField] Text railHightText;

    // Start is called before the first frame update
    void Start()
    {
        var temp=theRailWay.GetComponent<Transform>().position;
        temp.x = aSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRailActivefunc()
    {
        var temp=theRailWay.GetComponent<Transform>().position ;
        temp.x = aSlider.value;
        railHightText.text = aSlider.value.ToString();
    }
}
