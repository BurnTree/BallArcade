using System;
using System.Collections;
using System.Collections.Generic;
using Constants;
using UnityEngine;

public class ScoreLevelPortal : LevelPortal
{
    [SerializeField] private float scoreLimit = 100;
    [SerializeField] private TextMesh _text;
    private DamageObject _target;
    private Material _material;
    private bool _canUse = true;

    private void Start()
    {
        _material = gameObject.GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (ReferenceEquals(_target, null))
        {
            GameObject player = GameObject.FindGameObjectWithTag(Tags.Player);
            if (!ReferenceEquals(player, null))
                _target = player.GetComponent<DamageObject>();
        }
        else
        {
            if (_target.score < scoreLimit)
            {
                if (_canUse)
                {
                    _canUse = false;
                    _text.text = "Need more scores";
                    _material.color = new Color(0.7f, 0.2f, 0.2f, 0.4f);
                }
            }
            else
            {
                if (!_canUse)
                {
                    _canUse = true;
                    _text.text = "The end";
                    _material.color = new Color(0.2f, 0.8f, 0.7f, 0.4f);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.Player) && _canUse)
            NextLevel();
    }
}