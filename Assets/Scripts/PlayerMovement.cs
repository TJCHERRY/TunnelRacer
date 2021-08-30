using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform backLeft;
    public Transform backRight;
    public Transform frontLeft;
    public Transform frontRight;

    public float speed;

   // private Ray ray;
    private RaycastHit bl;
    private RaycastHit br;
    private RaycastHit fl;
    private RaycastHit fr;

    private List<RaycastHit> hitInfoList;
    private Vector3 upDir;

    private Vector3 surfaceNormal;
    private Vector3 ProjectionOnPlane;

    // Start is called before the first frame update
    void Start()
    {
        hitInfoList = new List<RaycastHit>();
        speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        Physics.Raycast(backLeft.position + Vector3.up, Vector3.down*2f, out bl);
        hitInfoList.Add(bl);
        Physics.Raycast(backRight.position + Vector3.up , Vector3.down*2f, out br);
        hitInfoList.Add(br);
        Physics.Raycast(frontLeft.position + Vector3.up , Vector3.down*2f, out fl);
        hitInfoList.Add(fl);
        Physics.Raycast(frontRight.position + Vector3.up , Vector3.down*2f, out fr);
        hitInfoList.Add(fr);

        Vector3 a =  bl.point-br.point;
        Vector3 b = br.point - fr.point;
        Vector3 c = fr.point - fl.point;
        Vector3 d = fl.point - bl.point;

        Vector3 BA = Vector3.Cross(b, a);
        Vector3 CB = Vector3.Cross(c, b);
        Vector3 DC = Vector3.Cross(d, c);
        Vector3 AD = Vector3.Cross(a, d);

        upDir = (BA + CB + DC + AD).normalized;

        //

       foreach(RaycastHit rch in hitInfoList)
       {
            if (rch.distance < 1f)
            {
                transform.up = Vector3.Lerp(transform.up, upDir*20f, 20f * Time.deltaTime);
            }


       }

        //Debug.Log(bl.collider.name + " " + br.collider.name + " " + fl.collider.name + " " + fr.collider.name+" ");
        /* if(Physics.Raycast(ray,out hit))
         {
             Debug.Log(hit.collider.name);
             surfaceNormal = hit.normal;
             Quaternion grndTilt = Quaternion.FromToRotation(transform.up, hit.normal);
             transform.rotation = grndTilt;

         }*/

        //ProjectionOnPlane = Vector3.ProjectOnPlane(transform.GetChild(0).transform.up * -2f, surfaceNormal);
        // transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        foreach(Transform wheel in this.transform)
        {
            if (wheel.gameObject.tag == "RayShooters")
            {
                Gizmos.color = Color.green;
                Gizmos.DrawRay(wheel.position + Vector3.up , Vector3.up * -5f);
            }
        }
        
    }
}
