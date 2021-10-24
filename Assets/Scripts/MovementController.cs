using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 8;
    public float jumpHeight = 2.5f;
    public float gravity = -20;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private CharacterController character = null;
    private Vector3 velocity;
    private bool isGrounded;

    private Inventory inventory;
    private GameObject UI;
    private DisplayGems _finalDoor;
    public Vector3 checkpoint;
    private GameObject _lastCheckpoint;
    private GameObject _unlockedDoor;

    private List<string> respawnMessages = new List<string>
    {
        "You Died.",
        "Ouf. That was Embarassing",
        "Newsflash: Lava kills you.",
        "Come on, the Game's not that Hard.",
        "Lmaoo git gud noob",
        "Maybe Stick to playing Candy Crush",
        "A Real Gamer Wouldn't Have Died There"
    };

    void Awake()
    {
        character = GetComponent<CharacterController>();
        inventory = gameObject.GetComponent<Inventory>();
        UI = GameObject.Find("UI_Text");
        _finalDoor = GameObject.Find("DoorEnd").GetComponent<DisplayGems>();
    }

    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (xMovement != 0 || zMovement != 0)
        {
            Vector3 moveDirection = transform.right * xMovement * moveSpeed + transform.forward * zMovement * moveSpeed;
            character.Move(moveDirection * Time.deltaTime);
        }

        //jumping & falling
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        velocity.y += gravity * Time.deltaTime;
        character.Move(velocity * Time.deltaTime);

        if (character.transform.position.y < -60) Respawn();
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
                } else if (_gameObject != _unlockedDoor)
                {
                    DisplayMessage("It's Locked");
                }
                break;
            case "Lava":
                Respawn();
                break;
            case "Bullet":
                Respawn();
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
                string color = _gameObject.name.Split(char.Parse("_"))[1];
                _finalDoor.AddGem(color);
                break;
            case "FinalDoor":
                if (inventory.gems >= 5)
                {
                    var door = _gameObject.GetComponent<AnimateDoor>();
                    door.Open();
                    DisplayMessage("Door Unlocked");
                } else
                {
                    if (inventory.gems == 4)
                    {
                        DisplayMessage($"{5 - inventory.gems} Gem Required");
                    } else
                    {
                        DisplayMessage($"{5 - inventory.gems} Gems Required");
                    }
                }
                break;
            case "EndZone":
                //TODO: add a nice scene transition effect
                UnityEditor.SceneManagement.EditorSceneManager.LoadScene("PrefabGarden");
                Debug.Log("You win");
                break;
            case "Lever":
                DisplayMessage("Lever Activated");
                break;
        }
    }

    private void Respawn()
    {
        transform.position = checkpoint;
        transform.Translate(0, 3, 0);
        transform.parent = null;
        transform.rotation = Quaternion.Euler(0, -90, 0);
        velocity.y -= 20;

        int i = Random.Range(0, respawnMessages.Count);
        DisplayMessage(respawnMessages[i]);

        //TODO: add screen transition and sound effect 
    }

    private void OnTriggerExit(Collider other)
    {
            transform.parent = null;
    }

    private void DisplayMessage(string text)
    {
        UI.GetComponent<Text>().text = text;
        UI.GetComponent<Animator>().SetBool("FadeIn", true);
        Debug.Log(text);
    }

}
