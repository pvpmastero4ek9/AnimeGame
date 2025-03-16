using UnityEngine;
using Core.MenuManagers;
using UnityEngine.UI;

public class JoinRoomButton : MonoBehaviour
{
    [SerializeField] private MenuManager _menuManager;
    [SerializeField] private Button _button;

    private void Start()
    {
        _button.onClick.AddListener(ClickButton);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ClickButton);
    }

    private void ClickButton()
    {
        _menuManager.JoinRoom();
    }
}
