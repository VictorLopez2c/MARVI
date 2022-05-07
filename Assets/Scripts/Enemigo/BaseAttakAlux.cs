using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttakAlux : MonoBehaviour
{

    public GameObject BaseAttack;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateHitBox()
    {
        BaseAttack.SetActive(true);
    }

    public void DeactivateHitBox()
    {
        BaseAttack.SetActive(false);
    }
}
