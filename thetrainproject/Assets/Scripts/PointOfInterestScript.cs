using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointOfInterestScript : MonoBehaviour
{

    [SerializeField] string aTitle;
    [SerializeField] Texture theLandmarkImage;
    [SerializeField] string aDescription;
    [SerializeField] float aDistance;

    Vector3 position;

    bool didYouSeeIt = false;

    private void Start()
    {
        position = transform.position;
        transform.localScale = new Vector3(0.00001f, 0.00001f, 0.00001f);
    }

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

    public float GetDistance()
    {
        return aDistance;
    }

    public Vector3 GetPosition()
    {
        return position;
    }

    public void ResetScale()
    {
        transform.localScale = new Vector3(20,20,20);
    }

    public bool GetDidYouSeeIt()
    {
        return didYouSeeIt;
    }

    public void SetDidYouSeeIt()
    {
        didYouSeeIt = true;
    }
}
