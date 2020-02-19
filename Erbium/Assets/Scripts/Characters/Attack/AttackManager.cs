﻿using Animators;
using Characters.Movement;
using UnityEngine;

namespace Characters.Attack {
    public class AttackManager : IAttackManager {
        private int currentCombo;
        private bool combo;
        private readonly IAnimatorFacade animatorFacade;
        private readonly ICharacter character;

        public AttackManager(IAnimatorFacade animatorFacade, ICharacter character) {
            this.animatorFacade = animatorFacade;
            this.character = character;
        }

        public void attack(bool fast) {
            Debug.Log(currentCombo);
            Debug.Log(combo);
                if (character.getMovement() is AttackingMovement == false) {
                    character.changeMovement(MovementEnum.Attack);
                }
                if (combo == false) {
                    animatorFacade.startAttacking(fast,false);
                }
                else {
                    animatorFacade.startAttacking(fast,true);
                }
        }

        public void addCombo() {
            combo = true;
            currentCombo++;
        }

        public void resetCombo() {
            combo = false;
            currentCombo = 0;
            animatorFacade.resetAttacks();
            character.changeMovement(MovementEnum.Ground);
        }

    }
}