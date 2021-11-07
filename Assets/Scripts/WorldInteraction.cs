using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldInteraction : MonoBehaviour
{
    private CharacterController character = null;
    private Vector3 velocity;

    private Inventory inventory;
    private GameObject UI;
    [SerializeField] GameObject audioSource;
    private AudioSource sfx;

    private DisplayGems _finalDoor;
    public Vector3 checkpoint;
    private GameObject _lastCheckpoint;
    private GameObject _unlockedDoor;
    private BlackoutTransition _blackoutTransition;

    [SerializeField] AudioClip _collectable;
    [SerializeField] AudioClip _death;

    private List<string> respawnMessages = new List<string>
    {
        "You Died.",
        "Ouf. That was Embarassing...",
        "Newsflash: Lava kills you.",
        "Come on, the Game's not that Hard.",
        "Lmaoo git gud",
        "Maybe Stick to playing Candy Crush",
        "A Real Gamer Wouldn't Have Died There"
    };

    void Awake()
    {
        character = GetComponent<CharacterController>();
        inventory = gameObject.GetComponent<Inventory>();
        UI = GameObject.Find("UI_Text");;

        _finalDoor = GameObject.Find("DoorEnd").GetComponent<DisplayGems>();
        _blackoutTransition = GetComponentInChildren<BlackoutTransition>();
        sfx = audioSource.GetComponent<AudioSource>();

        checkpoint = character.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject _gameObject = other.gameObject;

        switch (_gameObject.tag)
        {
            case "MovingPlatform":
                transform.parent = other.transform;
                break;
            case "Key":
                inventory.AddKey();
                Destroy(_gameObject);
                sfx.PlayOneShot(_collectable, 0.1f);
                DisplayMessage("Key Acquired");
                break;
            case "Door":
                if (inventory.hasKey)
                {
                    var door = _gameObject.GetComponent<AnimateDoor>();
                    inventory.UseKey();
                    door.Open();
                    DisplayMessage("Door Unlocked");
                    _unlockedDoor = _gameObject;
                }
                else if (_gameObject != _unlockedDoor)
                {
                    DisplayMessage("It's Locked");
                }
                break;
            case "Lava":
                _blackoutTransition.Play();
                sfx.PlayOneShot(_death, 0.13f);
                Invoke("Respawn", 1f);
                break;
            case "Bullet":
                _blackoutTransition.Play();
                sfx.PlayOneShot(_death, 0.13f);
                Invoke("Respawn", 1f);
                break;
            case "Checkpoint":
                checkpoint = character.transform.position;
                if (_gameObject != _lastCheckpoint)
                {
                    _lastCheckpoint = _gameObject;
                    DisplayMessage("Checkpoint Reached");
                }
                break;
            case "Gem":
                inventory.gems++;
                Destroy(_gameObject);
                DisplayMessage("Gem Acquired " + inventory.gems + " / 5");
                sfx.PlayOneShot(_collectable, 0.1f);
                string color = _gameObject.name.Split(char.Parse("_"))[1];
                _finalDoor.AddGem(color);
                break;
            case "FinalDoor":
                if (inventory.gems >= 5 && _unlockedDoor != _gameObject)
                {
                    var door = _gameObject.GetComponent<AnimateDoor>();
                    door.Open();
                    DisplayMessage("Door Unlocked");
                    _unlockedDoor = _gameObject;
                }
                else if (_unlockedDoor != _gameObject)
                {
                    if (inventory.gems == 4)
                    {
                        DisplayMessage($"{5 - inventory.gems} Gem Required");
                    }
                    else
                    {
                        DisplayMessage($"{5 - inventory.gems} Gems Required");
                    }
                }
                break;
            case "EndZone":
                _blackoutTransition.Play();
                Invoke("GoToEndScreen", 1f);
                break;
            case "Lever":
                DisplayMessage("Lever Activated");
                break;
        }
    }

    private void GoToEndScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("PrefabGarden");
    }

    private void Respawn()
    {
        transform.position = checkpoint;
        transform.Translate(0, 4, 0);
        transform.parent = null;
        transform.rotation = Quaternion.Euler(0, -90, 0);
        velocity.y -= 20;

        int i = Random.Range(0, respawnMessages.Count);
        DisplayMessage(respawnMessages[i]);
    }

    private void OnTriggerExit(Collider other)
    {
        transform.parent = null;
    }

    private void DisplayMessage(string text)
    {
        UI.GetComponent<Text>().text = text;
        UI.GetComponent<Animator>().SetBool("FadeIn", true);
    }

    private void Update()
    {
        if (character.transform.position.y < -60) Respawn();
    }
}
