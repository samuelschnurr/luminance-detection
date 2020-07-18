using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
//    public float speed = 3;
//    public CharacterController CharCont;
//    public Vector3 currentVector = Vector3.up;


//    public float CurrentForce = 0;
//    public float MaxForce = 5;



//    void Start()
//    {

//    }

//    void FixedUpdate()
//    {
//        // JetPack is on hold space button, so FixedUpdate() which may not run every single frame is enough.
//        if (Input.GetButton("Jump") && MaxForce > 0)
//        {
//            MaxForce -= Time.deltaTime;

//            if (CurrentForce < 1)
//            {
//                CurrentForce += Time.deltaTime * 10;
//            }
//            else
//            {
//                CurrentForce = 1;
//            }
//        }

//        // No fuel, but still in the air.
//        if (MaxForce < 0 && CurrentForce > 0)
//        {
//            CurrentForce -= Time.deltaTime;
//        }

//        if (!Input.GetButton("Jump"))
//        {
//            if (CurrentForce > 0)
//            {
//                CurrentForce -= Time.deltaTime;
//            }
//            else
//            {
//                CurrentForce = 0;
//            }
//            if (MaxForce < 5)
//            {
//                MaxForce += Time.deltaTime;
//            }
//            else
//            {
//                MaxForce = 5;
//            }

//            if (CurrentForce > 0)
//            {
//                useJetPack();
//            }
//        }
//    }

//    public void useJetPack()
//    {
//        currentVector = Vector3.up;
//        currentVector += transform.right * Input.GetAxis("Horizontal");
//        currentVector += transform.forward * Input.GetAxis("Vertical");
//        //CharCont.Move((currentVector * speed * Time.fixedDeltaTime - CharCont.velocity * Time.fixedDeltaTime) * CurrentForce);
//    }
}
