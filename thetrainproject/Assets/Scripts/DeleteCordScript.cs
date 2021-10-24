using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteCordScript : MonoBehaviour
{
    //ακυρο το delete


    [SerializeField] Text setText;
    [SerializeField] Camera theCamera;
    [SerializeField] GameObject aImage;
    [SerializeField] GameObject aPointofinterest;
    [SerializeField] GameObject sphere;

    [SerializeField] List<PointOfInterestScript> pointOfIntList = new List<PointOfInterestScript>();

    float angleNew=0f;
    float angleOld=0f;
    float angleDiference=0f;

    int listCounter = 0;

    //var pointOfIntList;

    //List<PointOfInterestScript> pointOfIntList = new List<PointOfInterestScript>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        SetTheArrowImage();
    }


    public void SetTheArrowImage()
    {
        //front Camera Vector
        Vector2 frontCameraVector = new Vector2(sphere.transform.position.x - theCamera.transform.position.x,
sphere.transform.position.z - theCamera.transform.position.z);

        //
        Vector2 vectorToPontOfInterest = new Vector2(pointOfIntList[listCounter].GetPosition().x - theCamera.transform.position.x,
            pointOfIntList[listCounter].GetPosition().z - theCamera.transform.position.z);


        angleNew = Vector2.SignedAngle(frontCameraVector, vectorToPontOfInterest);
        angleDiference = angleNew - angleOld;
        angleOld = angleNew;

        //Image Rotation
        aImage.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, angleDiference));

        setText.text = " pointD " + pointOfIntList[listCounter].GetDistance() +
            "cameraD" + Vector3.Distance(theCamera.transform.position, pointOfIntList[listCounter].GetPosition())
            + " List Counter: " + listCounter + " Title: " + pointOfIntList[listCounter].GetTitle() 
            +" testlistcount: "+ pointOfIntList.Count;

        if (Math.Abs (angleNew) < 14)
        {
            
            aImage.SetActive(false);
            if (pointOfIntList[listCounter].GetDidYouSeeIt() && listCounter< pointOfIntList.Count)
            {

                listCounter++;

            }
        }
        if(pointOfIntList[listCounter].GetDistance() > Vector3.Distance(theCamera.transform.position, pointOfIntList[listCounter].GetPosition()))
        {
            aImage.SetActive(true);
            pointOfIntList[listCounter].ResetScale();
            pointOfIntList[listCounter].SetDidYouSeeIt();

        }
    }


}
