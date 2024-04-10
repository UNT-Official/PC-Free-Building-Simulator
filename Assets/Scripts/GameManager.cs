using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UNT.Tools;

public class GameManager : MonoBehaviour
{
    [Header("Room parametrs")]
    [SerializeField] private Transform _roomPosition;
    [SerializeField] private GameObject _roomPrefab;
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private GameObject _playerPrefab;

    private void Start()
    {
        InitRoom();
    }

    [EditorButton("Init room")]
    public void InitRoom()
    {
        Instantiate(_roomPrefab, _roomPosition.position, Quaternion.identity, transform.parent);
        Instantiate(_playerPrefab, _playerPosition.position, Quaternion.identity, transform.parent);

        Destroy(_roomPosition.gameObject);
        Destroy(_playerPosition.gameObject);
    }
}