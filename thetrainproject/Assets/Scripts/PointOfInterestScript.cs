using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointOfInterestScript : MonoBehaviour
{

    [SerializeField] string aTitle;
    [SerializeField] Texture theLandmarkImage;
    [SerializeField] string aDescription;


    public string GetTitle()
    {
        return aTitle;
    } 

    public string GetDescription()
    {
        return aDescription;
    }

    public Texture GetLandmarkImage()
    {
        return theLandmarkImage;
    }
}
