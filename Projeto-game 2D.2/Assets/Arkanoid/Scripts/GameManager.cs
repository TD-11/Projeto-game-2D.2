using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int vidas = 2;
    public int TijolosRestantes;

    public GameObject playerPrefab;
    public GameObject ballPrefab;
    public Transform playerSpawnPoint;
    public Transform ballSpawnPoint;

    public PlayerB playerAtual;
    public BallB ballAtual;

    public TextMeshProUGUI contadorDeVidas;
    public TextMeshProUGUI msgFinal;

    public bool segurando;
    private Vector3 offset;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        SpawnarNovoJogador();
        AtualizarContador();
    }
    public void AtualizarContador()
    {
        contadorDeVidas.text = $"Vidas: {vidas}";
    }
    public void SpawnarNovoJogador()
    {
        GameObject playerObj = Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity);
        GameObject ballObj = Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);

    }

    public void GameOver()
    {
        Invoke(nameof(Recarregar), time: 1);
    }
    void Recarregar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
