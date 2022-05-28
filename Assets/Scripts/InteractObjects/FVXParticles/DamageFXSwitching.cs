using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFXSwitching : MonoBehaviour
{
    public int sDamageFX;


    // Start is called before the first frame update
    void Start()
    {
        SelectDamageFX();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchDamage() { sDamageFX++; }
    void SelectDamageFX()
    {
        int nDamageFX = 0;
        foreach (Transform damageFX in transform)
        {
            if (nDamageFX == sDamageFX)
                damageFX.gameObject.SetActive(true);
            else
                damageFX.gameObject.SetActive(false);

            nDamageFX++;
        }
    }
}
