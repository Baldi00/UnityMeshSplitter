using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform PlayerTransform;
    public GameObject Sword;
    public SwordCollider SwordCollider;
    public GameObject SwordEffect;
    public RectTransform UISword;
    public float SwordRotationSpeed = 1f;

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Vector3 ea = Sword.transform.eulerAngles;
            Sword.transform.eulerAngles = new Vector3(ea.x, ea.y, ea.z - SwordRotationSpeed);

            ea = UISword.transform.eulerAngles;
            UISword.transform.eulerAngles = new Vector3(ea.x, ea.y, ea.z - SwordRotationSpeed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Vector3 ea = Sword.transform.eulerAngles;
            Sword.transform.eulerAngles = new Vector3(ea.x, ea.y, ea.z + SwordRotationSpeed);

            ea = UISword.transform.eulerAngles;
            UISword.transform.eulerAngles = new Vector3(ea.x, ea.y, ea.z + SwordRotationSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(SwordEffect, null).SetActive(true);
            GetComponent<AudioSource>().Play();

            float swordRotation = 45f + Sword.transform.eulerAngles.z;

            Vector3 planePoint1 = PlayerTransform.position + PlayerTransform.TransformDirection(Vector3.forward * 10f);
            Vector3 planePoint2 = PlayerTransform.position;
            Vector3 planePoint3 = PlayerTransform.position + PlayerTransform.TransformDirection(Vector3.up * 3f * Mathf.Sin(Mathf.PI * swordRotation / 180f) + Vector3.right * 3f * Mathf.Cos(Mathf.PI * swordRotation / 180f));

            List<GameObject> colliding = SwordCollider.GetCollidingObjects();
            foreach(GameObject go in colliding)
            {
                MeshSplitter meshDestroy = go.GetComponent<MeshSplitter>();
                if(meshDestroy != null)
                {
                    meshDestroy.SplitMesh(planePoint1, planePoint2, planePoint3, PlayerTransform);
                }
            }
            SwordCollider.ClearCollidingObjects();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            MeshDestroy[] objects = FindObjectsOfType<MeshDestroy>();
            foreach(MeshDestroy md in objects)
            {
                md.DestroyMesh();
            }
            SwordCollider.ClearCollidingObjects();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Scene");
        }
    }
}
