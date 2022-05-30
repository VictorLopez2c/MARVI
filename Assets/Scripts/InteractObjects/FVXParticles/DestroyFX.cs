using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFX : MonoBehaviour
{
    public float lifeSpawnFXTime;

    // Update is called once per frame
    void Update()
    {
        if (lifeSpawnFXTime > 0)
        {
            lifeSpawnFXTime -= Time.deltaTime;
            if (lifeSpawnFXTime <= 0) { DestructFX(); }
            if (this.transform.position.y <= -20) { DestructFX(); }
        }
    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name == "DestroyFX") { DestructFX(); }
    }

    void DestructFX() { Destroy(this.gameObject); }
}
