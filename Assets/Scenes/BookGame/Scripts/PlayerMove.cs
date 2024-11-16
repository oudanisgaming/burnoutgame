using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private Custominput input = null;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D rb = null;
    private float moveSpeed = 10f;
    private SpawnManager _spawn;
    private Animator animator = null;

    [SerializeField]
    private int points = 0;

    [SerializeField]
    private TextMeshProUGUI pointsText; // Reference to the TextMeshProUGUI component

    void Start()
    {
        transform.position = new Vector3(0.2f, -1.66f, 0);

        _spawn = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if (_spawn == null)
        {
            Debug.LogError("The spawn manager is null");
        }

        UpdatePointsText(); // Initial points display
    }

    private void Awake()
    {
        input = new Custominput();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCancelled;
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
        transform.localScale = new Vector3(moveVector.x > 0 ? 0.5f : -0.5f, 0.5f, 0.5f);
        animator.SetBool("IsWalkingRight", true);
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
        ClampPosition();
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
        animator.SetBool("IsWalkingRight", false);
    }

    private void ClampPosition()
    {
        Vector3 playerPosition = transform.position;
        playerPosition.x = Mathf.Clamp(playerPosition.x, -7, 7);
        transform.position = playerPosition;
    }

    public void PlayerPoints()
    {
        points++;
        UpdatePointsText(); // Update the displayed points

        if (points >= 10)
        {
            _spawn.FullPoints();
            PlayerPrefs.SetInt("ReturningFromTable", 1);
            SceneManager.LoadScene("The_Room");

            StressBarManager.Instance.CompletedMiniGame("BookMiniGame");
        }
    }

    public void DecreasePoints()
    {
        points = Mathf.Max(0, points - 1); // Decrease points, but do not go below 0
        UpdatePointsText(); // Update points display after decreasing
    }

    private void UpdatePointsText()
    {
        if (pointsText != null)
        {
            pointsText.text = "Points: " + points;
        }
    }
}
