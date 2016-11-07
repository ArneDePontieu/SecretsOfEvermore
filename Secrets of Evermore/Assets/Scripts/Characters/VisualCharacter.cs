using UnityEngine;
using System.Collections;

public class VisualCharacter : MonoBehaviour
{

    //----------------------
    //PRIVATE VARIABLES
    //----------------------

    private float _followDistance = 2.0f;
    private float _digTimer = 0.0f;
    private float _digTime = 1.0f;
    private float _alchemySearchRadius = 2.0f;

    private bool _isFollowing = false;
    private bool _hasFoundObject = false;

    private Alchemy _foundObject;


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

            //Find alchemy objects if you're a dog
            if (Info.Name == "Dog")
            {
                FindAlchemyObjects();
            }

            //Move the character
            Move();
            //Attack if selected
            if (Info.IsSelected)
            {
                if (!_hasFoundObject)
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
    }

    //Get the distance between the target and the current position
    private Vector3 GetDistanceVector(Vector3 target)
    {
        return target - transform.position;
    }

    //Check if any alchemy objects are close
    private void FindAlchemyObjects()
    {
        foreach (var item in GameManager.Instance.LevelManagerInstance.GetItemSpawnList())
        {
            if (item.item.TypeItem == Item.ItemType.Alchemy)
            {
                if ((item.item as Alchemy).IsHidden == true)
                {
                    if (GetDistanceVector(item.item.VItem.transform.position).magnitude <= _alchemySearchRadius)
                    {
                        _hasFoundObject = true;
                        _foundObject = item.item as Alchemy;
                    }
                }
            }
        }
    }

    //Move the character
    private void Move()
    {
        //Move normally unless you found an alchemy object
        if (!_hasFoundObject)
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
        else
        {
            //Vector between the character and the alchemy object
            var distanceVector = GetDistanceVector(_foundObject.VItem.transform.position);

            //Check if the dog is close to the item, if not, move to it
            if (distanceVector.magnitude >= 0.5f)
            {
                transform.position = transform.position + (distanceVector.normalized * Time.deltaTime * Info.MovementSpeed);
            }
            else
            {
                _digTimer += Time.deltaTime;
                if (_digTimer >= _digTime)
                {
                    //Character can move freely again
                    _foundObject.IsHidden = false;
                    //Unhide the sprite
                    _foundObject.VItem.GetComponent<SpriteRenderer>().enabled = true;
                    //Found the object
                    _hasFoundObject = false;
                    //Reset the digtimer
                    _digTimer = 0.0f;
                }
            }
        }
    }

    //Basic attack
    private void BasicAttack()
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
                DogAttack();
            }

            //Reset the counter
            Info.AttackCounter = 0.0f;
        }
    }

    //Special attack
    private void SpecialAttack()
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
                DogAttack();
            }

            //Reset the counter
            Info.AttackCounter = 0.0f;
        }
    }

    //Attack when dog is selected
    private void DogAttack()
    {
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
}
