using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishController : MonoBehaviour {
    
    //移動系

    //public
    public float max_speed = 5; //加速距離(km/h)

    //アニメーション系統
    private Animator animator; //Animatorを取得
    private float animator_speed; //Animatorでのspeedを計算。

    //UI系

    public Image boostGage;

    // Use this for initialization
    void Start () {
        animator = GameObject.FindGameObjectWithTag("Salmon").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.LeftShift) && boostGage.fillAmount > 0)
        {
            animator_speed += Time.deltaTime;
        }
        else
        {
            animator_speed -= Time.deltaTime;
        }

        animator_speed = Mathf.Clamp(animator_speed, 0, 1);
        animator.SetFloat("Speed", animator_speed);
    }

    private void FixedUpdate()
    {
        if (GameController.isStarted) {

            //Key Input
            var hori = Input.GetAxis("Horizontal");
            var vert = Input.GetAxis("Vertical");
            //Mouse Input
            var mouse_x = Input.GetAxis("Mouse X") * 1.5f;
            var mouse_y = Input.GetAxis("Mouse Y") * 1.5f;

            //Speed Up
            Acceleration(max_speed);

            if (Input.GetKey(KeyCode.Mouse0)) {
                Rotate(mouse_x, mouse_y, 0, 0);
            }
            else
            {
                Stabilizer();
            }
        }
    }

    void Acceleration(float max_speed)
    {
        var rb = GetComponent<Rigidbody>();
        var target_velocity = Vector3.forward * max_speed;

        if (Input.GetKey(KeyCode.LeftShift) && boostGage.fillAmount > 0)
        {
            rb.AddRelativeForce(target_velocity * rb.mass * rb.drag / (1f - rb.drag * Time.fixedDeltaTime));
        }
    }

    // addForceに変更 2018/8/10
    void Move(float hori, float vert, float speed)
    {
        Vector3 translate = new Vector3(hori, 0, vert);

        this.gameObject.transform.Translate(translate * speed);
    }

    void Rotate(float x, float y, float x_lim, float y_lim)
    {
        Vector3 rotation = new Vector3(-y, x, 0);
        this.gameObject.transform.Rotate(rotation);
    }

    void Stabilizer()
    {
        var rb = GetComponent<Rigidbody>();
        var left = transform.TransformVector(Vector3.left);
        var horizontal_left = new Vector3(left.x, 0f, left.z).normalized;
        rb.AddTorque(Vector3.Cross(left, horizontal_left) * 10f);
        var forward = transform.TransformVector(Vector3.forward);
        var horizontal_forward = new Vector3(forward.x, 0f, forward.z).normalized;
        rb.AddTorque(Vector3.Cross(forward, horizontal_forward) * 10f);
    }

    float GetSpeed()
    {
        var rb = GetComponent<Rigidbody>();
        var speed = rb.velocity.magnitude;
        return speed;
    }
}
