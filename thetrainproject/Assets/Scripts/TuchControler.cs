using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TuchControler : MonoBehaviour
{
    [SerializeField] GameObject canvasLandmark;

    [SerializeField] Text title;
    [SerializeField] RawImage aImage; 
    [SerializeField] Text description;

    public static bool isCanvasLandmarkActive = false;


    // Start is called before the first frame update
    void Start()
    {
        canvasLandmark.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCanvasLandmarkActive)
        {
            //SetSlider();
            RaycastHit hitobject;
            Ray ray =Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hitobject))
            {



                // Check if what is hit is the desired object
                if (hitobject.transform.tag == "PointOfInterest")
                {
                    // User clicked the object.. Do something here..
                    canvasLandmark.SetActive(true);
                    title.text = hitobject.collider.GetComponentInParent<PointOfInterestScript>().GetTitle();
                    description.text = hitobject.collider.GetComponentInParent<PointOfInterestScript>().GetDescription();
                    if (hitobject.collider.GetComponentInParent<PointOfInterestScript>().GetLandmarkImage() != null)
                    {
                        aImage.texture = hitobject.collider.GetComponentInParent<PointOfInterestScript>().GetLandmarkImage();

                    }


                    isCanvasLandmarkActive = true;

                }

            }
        }
    }

    public void CloseButton()
    {
        isCanvasLandmarkActive = false;
        canvasLandmark.SetActive(false);
    }

}
