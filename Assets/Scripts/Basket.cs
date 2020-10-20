using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Отримати поточні координати мишки на екрані з Input
        Vector3 mousePos2D = Input.mousePosition;

        //Координати Z камери визначаючий, як далеко в трохмірному просторі
        //знаходиться вказівник миші
        mousePos2D.z = -Camera.main.transform.position.z;

        //Перетворити точку на двухмірній площині єкрану в трохмірні коодинати ігри
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Переміщаємо корзину вздовж осі X в координату X вказівника миші
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    //Визивається всякий раз коли який інший обєкт стикається із корзиною
    private void OnCollisionEnter(Collision coll)
    {
        //Пошук яблука, яке попало в корзину
        GameObject collidedWidth = coll.gameObject;  //Обєкт який стикнувся із корзиною
        if (collidedWidth.tag == "Apple")
        {
            Destroy(collidedWidth); //Якщо облуко то видаємо його
        }
    }
}
