using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectScript : MonoBehaviour
{
    [SerializeField] private GameObject cube_1;

    [SerializeField] private GameObject particle_1;
    [SerializeField] private GameObject particle_2;
    [SerializeField] private GameObject particle_3;
    [SerializeField] private GameObject particle_4;
    [SerializeField] private GameObject particle_5;
    [SerializeField] private GameObject particle_6;
    [SerializeField] private GameObject particle_7;
    [SerializeField] private GameObject particle_8;
    [SerializeField] private GameObject particle_9;
    [SerializeField] private GameObject particle_10;



    private void show_1()
    {
        particle_1.SetActive(true);
    }
    private void show_2()
    {
        particle_2.SetActive(true);
    }
    private void show_3()
    {
        particle_3.SetActive(true);
    }
    private void show_4()
    {
        particle_4.SetActive(true);
    }
    private void show_5()
    {
        particle_5.SetActive(true);
    }
    private void show_6()
    {
        particle_6.SetActive(true);
    }
    private void show_7()
    {
        particle_7.SetActive(true);
    }
    private void show_8()
    {
        particle_8.SetActive(true);
    }
    private void show_9()
    {
        particle_9.SetActive(true);
    }
    private void show_10()
    {
        particle_10.SetActive(true);
    }


    // Start is called before the first frame update
    void Start()
    {
        float invoke_time = 2.0f;
        float wait_time = 0.5f;

        Invoke("show_1", invoke_time);
        invoke_time += wait_time;
        Invoke("show_2", invoke_time);
        invoke_time += wait_time;
        Invoke("show_3", invoke_time);
        invoke_time += wait_time;
        Invoke("show_4", invoke_time);
        invoke_time += wait_time;
        Invoke("show_5", invoke_time);
        invoke_time += wait_time;
        Invoke("show_6", invoke_time);
        invoke_time += wait_time;
        Invoke("show_7", invoke_time);
        invoke_time += wait_time;
        Invoke("show_8", invoke_time);
        invoke_time += wait_time;
        Invoke("show_9", invoke_time);
        invoke_time += wait_time;
        Invoke("show_10", invoke_time);


        //Vector3 velocity = Vector3.left * 2;
        //this.Sphere.GetComponent<Rigidbody>().AddForce(velocity, ForceMode.VelocityChange);
        //this.Sphere_2.GetComponent<Rigidbody>().AddForce(velocity, ForceMode.VelocityChange);
        //this.Cylinder_2.GetComponent<Rigidbody>().AddForce(velocity, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
