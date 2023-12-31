using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] public float _movSpeed = 5f;
    [SerializeField] public GameObject characterSprite;
    private float _xAxis, _yAxis;

    [Header("Values")]
    [SerializeField] public float _life;
    [SerializeField] public  bool  _character;
    [SerializeField] public  bool _playerIsMoving = false;
                     public int _whichRoom;

    public Rigidbody2D _PlayerRb;
    public Vector2 _moveInput;
    private Vector2 _actualVec;
    [SerializeField] private BarlifeModifer barLife;
    Healpotion Hp;

    [Header("Timers")]
    [SerializeField] private int characterIndex;

    private void Start()
    {
        barLife.initialBarLife(_life);
    }
    private void Awake()
    {
        _PlayerRb = GetComponent<Rigidbody2D>();
        
    }
    
    private void Update()
    {
        
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        _moveInput = new Vector2(moveX, moveY).normalized;


        if (_life > 0)
        {
            isMoving(moveX, moveY);
            move(moveX, moveY);
            rotations(moveX, moveY);
        }else
        {
            Destroy(gameObject);
            restartScene();

        }
    }
   
    public void move( float X, float Y)
    {
        _PlayerRb.MovePosition(_PlayerRb.position + _moveInput * _movSpeed);

    }

    public void isMoving(float X, float Y)
    {

        if( X == 0 && Y == 0)
        {          
            _playerIsMoving = false;
        }else
        {
            _playerIsMoving = true;
        }
    }
    void rotations(float X, float Y)
    {
        #region Y rotation 
        if (Y == -1)
        {
        transform.rotation = Quaternion.Euler(0,0,-180);
        characterSprite.transform.rotation = Quaternion.Euler(0,0,0);
        }else if (Y == 1)
        {
        transform.rotation = Quaternion.Euler(0,0,0);
        characterSprite.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        #endregion    
        #region X rotation       
        if (X == 1)
        {
        transform.rotation = Quaternion.Euler(0,0,-90);
        characterSprite.transform.rotation = Quaternion.Euler(0,0,0);
        }else if (X == -1)
        {
        transform.rotation = Quaternion.Euler(0,0,90);
        characterSprite.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        #endregion    

    }
    public void getDmg(float dmg)
    {
        _life -= dmg;
        barLife.changeActulLife(_life);
    }
    void restartScene()
    {
        SceneManager.LoadScene("main menu");
    }
  }
