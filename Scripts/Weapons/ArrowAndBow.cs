using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAndBow : MonoBehaviour
{
    private Rigidbody myBody;

    [SerializeField]
    private float speed = 30f;

    [SerializeField]
    private float deactivate_Timer = 3f;

    [SerializeField]
    private float damage = 15f;

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DeactivateGameObject), deactivate_Timer);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Launch(Camera mainCamera)
    {
        myBody.velocity = mainCamera.transform.forward * speed;

        transform.LookAt(transform.position + myBody.velocity);
    }

    void DeactivateGameObject()
    {
        if (gameObject.activeInHierarchy)
            gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider target)
    {
        // affter we touch an enemy deactivate game object
        if (target.tag == Tags.ENEMY_TAG)
        {
            target.GetComponent<Health>().ApplyDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
