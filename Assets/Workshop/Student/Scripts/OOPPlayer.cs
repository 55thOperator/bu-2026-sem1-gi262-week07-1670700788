using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Solution
{

    public class OOPPlayer : Character
    {
        public Inventory inventory;
        public ActionHistoryManager actionHistoryManager;
        private InputAction moveAction;
        private InputAction fireAction;

        public bool isAutoMoving = false; // Flag to control auto-movement

        public override void SetUP()
        {
            base.SetUP();
            PrintInfo();
            GetRemainEnergy();
            inventory = GetComponent<Inventory>();
            moveAction = InputSystem.actions.FindAction("Move");
            fireAction = InputSystem.actions.FindAction("Attack");

        }

        public void Update()
        {
            // Manual input is only processed if not in auto-move mode
            if (isAutoMoving)
            {
                return;
            }

            if (moveAction.triggered)
            {
                Move(moveAction.ReadValue<Vector2>());
            }
            Keyboard keyboard = Keyboard.current;
            bool firePressed = fireAction.triggered;
            if (keyboard != null)
            {
                firePressed |= keyboard.eKey.wasPressedThisFrame;
            }
            if (firePressed)
            {
                UseFireStorm();
            }

            if (keyboard == null)
            {
                return;
            }

            if (keyboard.zKey.wasPressedThisFrame)
            {
                actionHistoryManager.UndoLastMove(this);
            }
            if (keyboard.qKey.wasPressedThisFrame)
            {
                actionHistoryManager.StartAutoMoveSequence(this);
            }
        }
        public override void Move(Vector2 direction)
        {
            base.Move(direction);
            mapGenerator.MoveEnemies();
            // Save the state AFTER the move
            Vector2 newPosition = new Vector2(this.positionX, this.positionY);
        }

        

        
       
        public void UseFireStorm()
        {
            if (inventory.HasItem("FireStorm",1))
            {
                inventory.UseItem("FireStorm",1);
                OOPEnemy[] enemies = SortEnemiesByRemainningEnergy1();
                int count = 3;
                if (count > enemies.Length)
                {
                    count = enemies.Length;
                }
                for (int i = 0; i < count; i++)
                {
                    enemies[i].TakeDamage(10);
                }
            }
            else
            {
                Debug.Log("No FireStorm in inventory");
            }
        }
        public OOPEnemy[] SortEnemiesByRemainningEnergy1()
        {
            var enemies = mapGenerator.GetEnemies();

            for (int i = 0; i < enemies.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < enemies.Length; j++)
                {
                    if (enemies[j].energy < enemies[minIndex].energy)
                    {
                        minIndex = j;
                    }
                }
                var temp = enemies[i];
                enemies[i] = enemies[minIndex];
                enemies[minIndex] = temp;
            }

            return enemies;
        }

        public OOPEnemy[] SortEnemiesByRemainningEnergy2()
        {
            var enemies = mapGenerator.GetEnemies();

            Array.Sort(enemies, (a, b) => a.energy.CompareTo(b.energy));


            return enemies;
        }
        public void Attack(OOPEnemy _enemy)
        {
            _enemy.TakeDamage(AttackPoint);
            Debug.Log(_enemy.name + " is energy " + _enemy.energy);
        }
        protected override void CheckDead()
        {
            base.CheckDead();
            if (energy <= 0)
            {
                Debug.Log("Player is Dead");
            }
        }

    }

}
