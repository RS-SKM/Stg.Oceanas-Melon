using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echolocation : MonoBehaviour
{
    [SerializeField] private Transform pfObjectPinged;
    //[SerializeField] private Transform pfRock;

    private Transform pulseTransform;
    private float range;
    private float maxRange;
    private float rangeSpeed;
    private float fadeRange;
    private SpriteRenderer pulseSpriteRender;
    private Color pulseColor;
    private List<Collider2D> alreadyPingedColliderList; //list to contain pinded objects

    private void Awake()
    {
        pulseTransform = transform.Find("Pulse");
        pulseSpriteRender = pulseTransform.GetComponent<SpriteRenderer>();
        pulseColor = pulseSpriteRender.color;
        maxRange = 200f;
        fadeRange = 20f;
        rangeSpeed = maxRange;
        alreadyPingedColliderList = new List<Collider2D>();
    }

    private void Update()
    {
        range += rangeSpeed * Time.deltaTime;
        if (range > maxRange)
        {
            range = 0f;
            alreadyPingedColliderList.Clear(); //clear the list after echo reaches max range
        }
        pulseTransform.localScale = new Vector3(range, range);

        //.CircleCastAll will return an array of raycastHit
        RaycastHit2D[] raycastHit2DArray = Physics2D.CircleCastAll(transform.position, range / 2f, Vector2.zero); //fancy magic funtion to detect when they hit an object
        foreach (RaycastHit2D raycastHit2D in raycastHit2DArray) //execute for every raycastHit in the array
        {
            if(raycastHit2D.collider != null)
            {
                if(!alreadyPingedColliderList.Contains(raycastHit2D.collider)) //if the object is already pinged, add it to the list
                {
                    alreadyPingedColliderList.Add(raycastHit2D.collider);
                    Instantiate(pfObjectPinged, raycastHit2D.point, Quaternion.identity);
                    //Debug.Log("Pinged");
                }
            }
        }

        //made the echolocation ring fade as it reaches the max radius
        if (range > maxRange - fadeRange)
        {
            pulseColor.a = Mathf.Lerp(0f, 1f, (maxRange - range)/fadeRange);
        } 
        else 
        {
            pulseColor.a = 1f;
        }
        pulseSpriteRender.color = pulseColor;
    }
}
