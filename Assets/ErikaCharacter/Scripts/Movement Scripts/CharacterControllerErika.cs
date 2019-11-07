using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerErika : MonoBehaviour
{
    public GameObject characterGameObject;
    private Rigidbody characterRigidBody;
    private CapsuleCollider characterCollider;
    private Animator characterAnimator;
    public float moveSpeed;
    public float rotSpeed;
    public float jumpPower;
    float speedMultiplier;
    public LayerMask groundLayer;
    private bool bowEquipped;
    private Transform bow;

    void Start()
    {
        speedMultiplier = 1;
        characterGameObject = GameObject.FindGameObjectWithTag("Player");
        characterRigidBody = characterGameObject.GetComponent<Rigidbody>();
        characterCollider = characterGameObject.GetComponent<CapsuleCollider>();
        characterAnimator = characterGameObject.GetComponent<Animator>();
        bow = characterGameObject.transform.Find("Erika_Archer_Meshes").Find("Erika_Archer_Bow_Mesh");
        bowEquipped = false;
    }
    void FixedUpdate()
    {
        Move();
        HandleBow();
        Attack();
    }

    #region Main Body of Movement
    public void Move()
    {
        float h, v;
        bool isJump, isSprint;
        float vertical, horizontal;
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        isJump = Input.GetKeyDown(KeyCode.Space);
        isSprint = Input.GetKey(KeyCode.LeftShift);
        vertical = v * moveSpeed * speedMultiplier;
        horizontal = h * rotSpeed;

        // Rotation of the character
        LocomotionRotate(horizontal);

        // update animator along with movements
        UpdateAnimator(vertical, horizontal, isJump, isSprint);
    }
    #endregion

    #region Movement
    public void LocomotionForward(float vertical)
    {
        characterGameObject.transform.Translate(0, 0, vertical * Time.deltaTime);
    }

    public void LocomotionRotate(float horizontal)
    {
        characterGameObject.transform.Rotate(0, horizontal * Time.deltaTime, 0);
    }
    #endregion

    #region Ground Status Check
    public bool CheckGroundStatus()
    {
        return Physics.CheckCapsule(characterCollider.bounds.center, new Vector3(characterCollider.bounds.center.x,characterCollider.bounds.min.y, 
            characterCollider.bounds.center.z),characterCollider.radius,groundLayer);
    }
    #endregion

    #region Locomotion Animation Events
    public void Jump()
    {
        if (CheckGroundStatus())
        {
            characterRigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            characterRigidBody.AddForce(Physics.gravity * (characterCollider.center.y/2));
        } 
    }

    public void JumpColliderFunction()
    {
        characterCollider.height /= 2f;
        characterCollider.center = new Vector3(characterCollider.center.x, characterCollider.center.y + .8f, characterCollider.center.z);
    }

    public void LandColliderFunction()
    {
        characterCollider.height *= 2f;
        characterCollider.center = new Vector3(characterCollider.center.x, characterCollider.center.y - .8f, characterCollider.center.z);
    }
    #endregion

    #region Locomotion Animation Update
    public void UpdateAnimator(float vertical, float horizontal, bool isJump, bool isSprint)
    {
        if(vertical > 0)
        {
            characterAnimator.SetFloat("forward", vertical);
            LocomotionForward(vertical);
            if (isSprint)
            {
                if(speedMultiplier < 3)
                    speedMultiplier += .1f ;
            }

            else
            {
                if(speedMultiplier > 1)
                    speedMultiplier -= .1f ;
            }
            vertical = 0f;
        }

        else if(vertical < 0)
        {
            characterAnimator.SetFloat("backward", vertical * -1);
            LocomotionForward(vertical);
            if (isSprint)
            {
                if (speedMultiplier < 3)
                    speedMultiplier += .1f;
            }

            else
            {
                if (speedMultiplier > 1)
                    speedMultiplier -= .1f;
            }
            vertical = 0f;
        }

        if (isJump)
        {
            characterAnimator.SetBool("jump",isJump);
        }

        if (!isJump)
        {
            characterAnimator.SetBool("jump", isJump);
        }
    }
    #endregion

    #region Weaponry
    public void HandleBow()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (bowEquipped)
            {
                Debug.Log("Bow Equipped");
            }

            else
            {
                Debug.Log("Bow Unequipped");
            }

            characterAnimator.SetBool("bowEquipped", bowEquipped);
            bowEquipped = !bowEquipped;
        }
    }

    public void DisarmBow() {
        bow.gameObject.SetActive(false);
    }

    public void ArmBow(){
        bow.gameObject.SetActive(true);
    }
    #endregion

    #region All Attacks
    public void Attack()
    {
        bool bowEquipped;
        bowEquipped = characterAnimator.GetBool("bowEquipped");
        if (!bowEquipped)
        {
            if (Input.GetMouseButtonDown(0))
            {
                characterAnimator.SetTrigger("perform_attack1");
            }
        }
    }
    #endregion

    #region Helper Functions
    IEnumerator Wait(float num)
    {
        yield return new WaitForSeconds(num);
    }
    #endregion
}