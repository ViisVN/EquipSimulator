using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public CharacterData _charData;
    public string _characterName;
    public int Health,Str,Spd,Def;
    public BoxCollider2D _collider2D;
    public bool changeOffset = false;
    
    private void Awake() 
    {
        _characterName = _charData.name;
        Health = _charData.Health;
        Str = _charData.Str; 
        Spd = _charData.Spd;
        Def = _charData.Def;
    }   
    private void OnTriggerEnter2D(Collider2D other) 
    {
       GameObject enemy = other.gameObject;
       enemy.GetComponent<Slime>().Ontakedamage(str => Str,this.gameObject.GetComponent<CharacterManager>());
    }
    private void OnCollider()
    {
        if(!changeOffset)
        {
        _collider2D.offset = new Vector2(0.5f,0f);
        _collider2D.size = new Vector2(1.4f,1f);
        changeOffset = true;
        }
        else
        {
            _collider2D.offset = new Vector2(0f,0f);
        _collider2D.size = new Vector2(0.5f,1f);
             changeOffset = false;
        }
    }
}
