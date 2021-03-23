using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public float _damage = 10f;
    public float _range = 100f;

    public Camera _camera;
    public ParticleSystem particle;
    public GameObject impact;
    public GameObject sound;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }

    void shoot()
    {
        GameObject soundGO = Instantiate(sound);
        soundGO.GetComponent<AudioSource>().Play();
        Destroy(soundGO, 2f);
        particle.Play();
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(_damage);
            }
            GameObject impactGO = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f); 

        }
    }
}
