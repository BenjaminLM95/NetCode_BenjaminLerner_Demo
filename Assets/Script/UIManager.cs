using Unity.Netcode.Transports.UTP;
using UnityEngine;


public enum GameState 
{
    Menu,
    Options,
    Gameplay,
    Win,
    Pause,
    NetworkConnection,
    RelayConnection,
    None
}

public class UIManager : MonoBehaviour
{
    public GameObject _menuUI;
    public GameObject _options; 
    public GameObject _gameplayUI;
    public GameObject _pauseUI;
    public GameObject _winUI;
    public GameObject _localNetworkConnection;
    public GameObject _relayNetworkConnection; 

    public GameState _currentGameState = GameState.None;
    public GameState _previousGameState = GameState.None;

    public UnityTransport _UnityTransport;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ActiveMenu(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeStates(GameState gameState) 
    {      
        _previousGameState = _currentGameState;         

        switch (gameState) 
        {
            case GameState.Menu:
                Debug.Log("Menu");
                break;
            case GameState.Options:
                Debug.Log("Options");
                break; 
            case GameState.Gameplay:
                Debug.Log("Gameplay");
                break;
            case GameState.Pause:
                Debug.Log("Pause");
                break;
            case GameState.NetworkConnection:                 
                Debug.Log("NetworkConnection");                
                break;
            case GameState.RelayConnection:                
                Debug.Log("RelayConnection");
                break; 
            case GameState.Win:
                Debug.Log("Win");
                break;
        }

        _currentGameState = gameState; 
    }

    public void ActiveMenu() 
    {
        DisactivateUIs();
        _menuUI.SetActive(true);
        ChangeStates(GameState.Menu); 
    }

    public void ActivePause() 
    {
        DisactivateUIs();
        _pauseUI.SetActive(true);
        ChangeStates(GameState.Pause);
    }

    public void ActiveGameplay() 
    {
        DisactivateUIs();
        _gameplayUI.SetActive(true);
        ChangeStates(GameState.Gameplay);
    }

    public void ActiveWin() 
    {
        DisactivateUIs();
        _gameplayUI.SetActive(true);
        ChangeStates(GameState.Win);
    }

    public void ActiveLocalConnection() 
    {
        DisactivateUIs();
        _localNetworkConnection.SetActive(true);
        ChangeStates(GameState.NetworkConnection);
    }

    public void ActiveRelayConnection() 
    {
        DisactivateUIs();
        _relayNetworkConnection.SetActive(true);
        ChangeStates(GameState.RelayConnection);
    }

    public void ActiveOptions() 
    {
        DisactivateUIs();
        _options.SetActive(true);
        ChangeStates(GameState.Options);
    }

    public void DisactivateUIs() 
    {
        _menuUI.SetActive(false);
        _options.SetActive(false); 
        _gameplayUI.SetActive(false);
        _pauseUI.SetActive(false);
        _winUI.SetActive(false);
        _localNetworkConnection.SetActive(false);
        _relayNetworkConnection.SetActive(false); 
    }

}
