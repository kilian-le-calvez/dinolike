using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ActionType = State.DinoState_STATIC.ActionType;
using SkinType = Anim.DinoAnim_STATIC.SkinType;
using AnimationType = Anim.DinoAnim_STATIC.AnimationType;

namespace Anim
{
    public class DinoAnim_STATIC
    {
        public enum SkinType
        {
            BLUE,
            RED,
            GREEN,
            YELLOW
        };

        public enum AnimationType
        {
            IDLE,
            WALKING
        };

        public Dictionary<SkinType, Dictionary<AnimationType, string>> DinoDictionary;

        public DinoAnim_STATIC()
        {
            DinoDictionary = new Dictionary<SkinType, Dictionary<AnimationType, string>>();
            // Blue
            DinoDictionary[SkinType.BLUE] = new Dictionary<AnimationType, string>();
            DinoDictionary[SkinType.BLUE][AnimationType.IDLE] = "blue_idle_dino";
            DinoDictionary[SkinType.BLUE][AnimationType.WALKING] = "blue_walking_dino";

            // Red
            DinoDictionary[SkinType.RED] = new Dictionary<AnimationType, string>();
            DinoDictionary[SkinType.RED][AnimationType.IDLE] = "red_idle_dino";
            DinoDictionary[SkinType.RED][AnimationType.WALKING] = "red_walking_dino";

            // green
            DinoDictionary[SkinType.GREEN] = new Dictionary<AnimationType, string>();
            DinoDictionary[SkinType.GREEN][AnimationType.IDLE] = "green_idle_dino";
            DinoDictionary[SkinType.GREEN][AnimationType.WALKING] = "green_walking_dino";

            // Yellow
            DinoDictionary[SkinType.YELLOW] = new Dictionary<AnimationType, string>();
            DinoDictionary[SkinType.YELLOW][AnimationType.IDLE] = "yellow_idle_dino";
            DinoDictionary[SkinType.YELLOW][AnimationType.WALKING] = "yellow_walking_dino";
        }

        public string stringFromType(SkinType skinType, AnimationType animType)
        {
            return DinoDictionary[skinType][animType];
        }
    }

    public class DinoAnim : MonoBehaviour
    {
        private DinoAnim_STATIC anim;

        // Need comp on object
        private Animator animator;

        public State.DinoState state;
        public SkinType skinType;

        void Start()
        {
            anim = new DinoAnim_STATIC();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (state.hasChanged())
            {
                string animName = anim.stringFromType(skinType, stateToAnimType());
                animator.Play(animName);
            }
        }

        public AnimationType stateToAnimType()
        {
            switch (state.actionState)
            {
                case ActionType.WALKING:
                    return AnimationType.WALKING;
            }
            return AnimationType.IDLE;
        }
    }

}