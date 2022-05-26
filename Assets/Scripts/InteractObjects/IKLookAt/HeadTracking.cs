using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeadTracking : MonoBehaviour
{
    public Transform Target;

    public float Radius = 10f;
    public float RetargetSpeed = 5f;

    List<PointOfInterest> POIs;
    float RadiusSqr;

    // Start is called before the first frame update
    void Start()
    {
        POIs = FindObjectsOfType<PointOfInterest>().ToList();
        RadiusSqr = Radius * Radius;
    }
    // Update is called once per frame
    void Update()
    {
        Transform tracking = null;
        foreach (PointOfInterest poi in POIs)
        {
            Vector3 delta = poi.transform.position - transform.position;
            if (delta.sqrMagnitude < RadiusSqr)
            {
                tracking = poi.transform;
                break;
            }

        }
        Vector3 targetPos = transform.position + (transform.forward * 2);
        if (tracking != null)
        {
            targetPos = tracking.position;
        }
        Target.position = Vector3.Lerp(Target.position, targetPos, Time.deltaTime * RetargetSpeed);
    }

}
