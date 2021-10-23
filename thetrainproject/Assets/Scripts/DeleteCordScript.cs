using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteCordScript : MonoBehaviour
{
    [SerializeField] Text setText;
    [SerializeField] Camera theCamera;
    [SerializeField] GameObject aImage;
    [SerializeField] GameObject aPointofinterest;
    [SerializeField] GameObject sphere;

    float angleNew=0f;
    float angleOld=0f;
    float angleDiference=0f;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 frontCameraVector = new Vector2(sphere.transform.position.x - theCamera.transform.position.x,
    sphere.transform.position.z - theCamera.transform.position.z);

        Vector2 vectorToPontOfInterest = new Vector2(aPointofinterest.transform.position.x - theCamera.transform.position.x,
            aPointofinterest.transform.position.z - theCamera.transform.position.z);


        angleNew = Vector2.SignedAngle(frontCameraVector, vectorToPontOfInterest);
        angleDiference = angleNew- angleOld;
        angleOld = angleNew;

        //Image Rotation
        aImage.GetComponent<RectTransform>().Rotate(new Vector3(0,0,angleDiference));

        setText.text =" angle "+ Vector2.SignedAngle(frontCameraVector,vectorToPontOfInterest)+
            "angle diference" + angleDiference;

        if (angleNew < 15)
        {
            aImage.SetActive(false);
        }
        else {
            aImage.SetActive(true);
                }
        
    }


    /**
 * Calculates the angle (in radians) between two vectors pointing outward from one center
 *
 * @param p0 first point
 * @param p1 second point
 * @param c center point
 */
    public float find_angle(Vector3 p0,Vector3 p1,Vector3 c)
    {
        var p0c = Math.Sqrt(Math.Pow(c.x - p0.x, 2) +
                            Math.Pow(c.y - p0.y, 2)); // p0->c (b)   
        var p1c = Math.Sqrt(Math.Pow(c.x - p1.x, 2) +
                            Math.Pow(c.y - p1.y, 2)); // p1->c (a)
        var p0p1 = Math.Sqrt(Math.Pow(p1.x - p0.x, 2) +
                             Math.Pow(p1.y - p0.y, 2)); // p0->p1 (c)
        return (float)Math.Acos((p1c * p1c + p0c * p0c - p0p1 * p0p1) / (2 * p1c * p0c));
    }
}
