using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumController : MonoBehaviour
{
    // 振り子の長さ。
    [SerializeField] private float length = 0.50f;
    // ラジアンからディグリーに変換するための数値
    private float Rad_To_Deg = 180f / (2f * Mathf.PI);
    // 振り子の重りオブジェクトへの参照
    private GameObject sphere = null;

    // 振り子を動作させる / させない フラグ 
    private bool is_moving = false;

    // 重力加速度
    float G = Mathf.Abs(Physics.gravity.y);
    // 振り子を振るX軸の幅(m)
    private float pendulum_width = 0.25f;

    // 最高の高度と開始時のY座標位置を取得する。
    private float max_height = 0.0f;
    private float init_pos_y = 0.0f;

    // 左右フラグ true=左に回転中。false=右に回転中。
    private bool is_left = true;

    // 振り子をふり始めるまでの秒数
    private float invoke_time = 10.0f;


    // 現在の高さから速度、角速度を求めラジアン値で返す
    // 入力 : float current_height : 現状の振り子重りの中心のY軸の高さ
    // 戻り値 : float 現状の振り子の高さでの角速度ラジアン値(rad/s)
    private float angular_velocity(float current_height)
    {
  
        // 以下速度を求める式
        // m * g * max_h = m * g * current_height - 0.5 * m * v^2
        // g * max_h = g * current_height - 0.5 * v^2
        // g * max_h - g * current_height = - 0.5 * v^2
        // -2 (g * max_h - g * current_height) = v^2
        // -2 * g * (max_h - current_height) = v^2
        // v = √(-2 * g * (max_h - current_height))
        float v = Mathf.Sqrt(2f * this.G * Mathf.Abs(this.max_height - current_height));
        //Debug.Log("v : " + v);

        // 以下角速度を求める式
        // v = r * w
        // w = v / r
        return (v / this.length);
    }

    // 振り子の振動を始める
    private void move()
    {
        this.is_moving = true;
    }



    // Start is called before the first frame update
    void Start()
    {
        // オモリの位置を取得する
        this.sphere = transform.Find("Sphere").gameObject;
        // 開始時のY座標位置を取得する。
        this.init_pos_y = this.sphere.transform.position.y;
        //Debug.Log("init_pos_y : " + init_pos_y);

        // 振り子の「長さ」と期待する「振り幅」から、振り上げる高さを算出する
        // 高さ^2 = 振り子の長さ - √(振り子の長さ^2 - X軸の振り幅^2)
        this.max_height = this.length - Mathf.Sqrt(Mathf.Pow(this.length, 2.0f) - Mathf.Pow(this.pendulum_width, 2.0f));
        //Debug.Log("max_height : " + max_height);

        Invoke("move", this.invoke_time);
    }


    void FixedUpdate()
    {
        if (this.is_moving == false)
        {
            return;
        }

        // 現在の高さを取得する
        float pos_y = this.sphere.transform.position.y;
        float current_height = pos_y - this.init_pos_y;

        if (current_height >= this.max_height)
        {
            this.is_left = !(this.is_left);
        }

        // 現在の角速度(rad/s)を取得する。
        float anguler_velocity = angular_velocity(current_height);

        if (this.is_left == true)
        {
            anguler_velocity *= -1;
        }

        // 算出した角速度にて振り子を回転する
        transform.Rotate(new Vector3(0.0f, 0.0f, anguler_velocity * this.Rad_To_Deg * Time.fixedDeltaTime));
    }


    // Update is called once per frame
    void Update()
    {

    }
}
