using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slime : MonoBehaviour
{
    public float time = 1f;
    public bool isleft=false;
    public GameObject text;
    public Transform canvas;
    private void Update()
    {
        if (!isleft)
        {
            time -= Time.deltaTime;
            transform.Translate(Vector3.left*Time.deltaTime);
            if (time < 0)
            {
                time = 1f;
                isleft = true;
            }
        }
        else
        {
            time -= Time.deltaTime;
            transform.Translate(Vector3.right*Time.deltaTime);
            if (time < 0)
            {
                time = 1f;
                isleft = false;
            }
        }
    }
    public void Ontakedamage(Func<CharacterManager, int> Str, CharacterManager character)
    {
        int damage = Str(character);
        GameObject _text = Instantiate(text, canvas);
        _text.transform.position = transform.position;
        _text.GetComponent<TMP_Text>().text = damage.ToString();
        _text.GetComponent<Rigidbody2D>().AddForce(Vector2.up);
        Destroy(_text,0.4f);

    }
}
