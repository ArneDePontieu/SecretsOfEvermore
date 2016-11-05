using UnityEngine;
using System.Collections;

public class VisualCharacter : MonoBehaviour
{

    //----------------------
    //PRIVATE VARIABLES
    //----------------------

    private float _followDistance = 2.0f;
    private bool _isFollowing = false;

    //----------------------
    //PUBLIC VARIABLES
    //----------------------

    public Avatar Info;
    public VisualCharacter SelectedChar;
    public Vector3 ForwardVector;

    //----------------------
    //PRIVATE METHODS
    //----------------------

    void Update()
    {
        //Debug forward vector
        Debug.DrawLine(this.gameObject.transform.position, this.gameObject.transform.position + ForwardVector, Color.red);

        if (Info != null)
        {
            //Update the counter for attacking
            Info.AttackCounter += Time.deltaTime;
            //Move the character
            Move();
            //Attack if selected
            if (Info.IsSelected)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    BasicAttack();
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SpecialAttack();
                }

            }
        }
    }

    //----------------------
    //PUBLIC METHODS
    //----------------------

    public void Move()
    {
        //Move with keys if IsSelected is true, otherwise move automatically    
        if (Info.IsSelected)
        {
            //Move with the arrow keys
            var move = new Vector3();
            move.x = Input.GetAxis("Horizontal");
            move.y = Input.GetAxis("Vertical");
            transform.position += move * Info.MovementSpeed * Time.deltaTime;

            if (move != new Vector3(0, 0, 0))
            {
                ForwardVector = move.normalized;
            }
        }

        if (SelectedChar != null)
        {
            //Distance between the character and the selecterdcharacter
            var distanceVector = GetDistanceVector(SelectedChar.transform.transform.position);

            //Follow if very far and come close
            if (_isFollowing)
            {
                if (distanceVector.magnitude < _followDistance)
                {
                    _isFollowing = false;
                }
            }
            else
            {
                if (distanceVector.magnitude > _followDistance + 4.0f)
                {
                    _isFollowing = true;
                }
            }

            if (_isFollowing)
            {
                transform.position = transform.position + (distanceVector.normalized * Time.deltaTime * (Info.MovementSpeed + 1.0f));
            }
        }

    }

    public void BasicAttack()
    {
        //Only attack if the counter is higher
        if (Info.AttackCounter >= Info.AttackDelay)
        {
            if (Info.Name == "Boy")
            {
                var weapon = GameManager.Instance.CharacterInventory.GetWeapon();

                switch (weapon.TypeOfWeapon)
                {
                    case Weapon.WeaponType.Axe:
                        var axe = weapon as Axe;
                        axe.BasicAttack();
                        break;
                    case Weapon.WeaponType.Spear:
                        var spear = weapon as Spear;
                        spear.BasicAttack();
                        break;
                    case Weapon.WeaponType.Sword:
                        var sword = weapon as Sword;
                        sword.BasicAttack();
                        break;
                }
            }
            else
            {
                //Do a raycast to check if an enemy is in front of you
                RaycastHit2D hit = Physics2D.Raycast(
                    transform.position,
                   ForwardVector,
                    5.0f,
                    LayerMask.GetMask("EnemyLayer"));

                if (hit.collider != null)

                {
                    //Hit the enemy with standard damage
                    if (hit.collider.gameObject.tag == "Enemy" && hit.distance <= 1.0f)
                    {
                        hit.collider.gameObject.GetComponent<VisualEnemy>().Info.TakeDamage(GameManager.Instance.CharManagerInstance.GetSelectedCharacterDamage());
                    }
                }
            }

            //Reset the counter
            Info.AttackCounter = 0.0f;
        }
    }

    public void SpecialAttack()
    {
        //Only attack if the counter is higher
        if (Info.AttackCounter >= Info.AttackDelay)
        {
            if (Info.Name == "Boy")
            {
                var weapon = GameManager.Instance.CharacterInventory.GetWeapon();

                switch (weapon.TypeOfWeapon)
                {
                    case Weapon.WeaponType.Axe:
                        var axe = weapon as Axe;
                        axe.SpecialAttack();
                        break;
                    case Weapon.WeaponType.Spear:
                        var spear = weapon as Spear;
                        spear.SpecialAttack();
                        break;
                    case Weapon.WeaponType.Sword:
                        var sword = weapon as Sword;
                        sword.SpecialAttack();
                        break;
                }
            }
            else
            {
                //Do a raycast to check if an enemy is in front of you
                RaycastHit2D hit = Physics2D.Raycast(
                    transform.position,
                    ForwardVector,
                    5.0f,
                    LayerMask.GetMask("EnemyLayer"));

                if (hit.collider != null)

                {
                    //Hit the enemy with standard damage
                    if (hit.collider.gameObject.tag == "Enemy" && hit.distance <= 1.0f)
                    {
                        hit.collider.gameObject.GetComponent<VisualEnemy>().Info.TakeDamage(GameManager.Instance.CharManagerInstance.GetSelectedCharacterDamage());
                    }
                }
            }

            //Reset the counter
            Info.AttackCounter = 0.0f;
        }
    }


    //PRIVATE METHODS
    private Vector3 GetDistanceVector(Vector3 target)
    {
        return target - transform.position;
    }
}
