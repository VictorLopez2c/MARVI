using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MARVILOGO : MonoBehaviour
{
    public float time_s = 0.0f;
    public float time_e = 9.0f;
    public string MainMenu;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        time_s += Time.deltaTime;
        if (time_s >= time_e)
        {
            Application.LoadLevel(MainMenu);
        }
    }
}
