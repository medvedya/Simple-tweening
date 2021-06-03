using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace SimpleTweening
{
    public class AnimationClipTween : BaseTween, IAnimationClipSource
    {

#pragma warning disable
        [SerializeField] 
        AnimationClip clip;
#pragma warning restore
        [SerializeField]
        Animator animator;

        PlayableGraph playableGraph;
        AnimationClipPlayable clipPlayable;
        void OnEnable()
        {
            if (animator == null)
            {
                animator = GetComponent<Animator>();
            }
            if (animator == null || clip == null) return;
            playableGraph = PlayableGraph.Create();

            playableGraph.SetTimeUpdateMode(DirectorUpdateMode.Manual);

            var playableOutput = AnimationPlayableOutput.Create(playableGraph, "AnimationClipTween", animator);

            clipPlayable = AnimationClipPlayable.Create(playableGraph, clip);

            playableOutput.SetSourcePlayable(clipPlayable);

        }
        void OnDisable()
        {
            if (playableGraph.IsValid())
            {
                playableGraph.Destroy();
            }
        }
        public void GetAnimationClips(List<AnimationClip> results)
        {
            if (this.clip != null)
            {
                results.Add(clip);
            }
        }
        protected override void OnSetValue(float t)
        {
            if (this.enabled)
            {
                if (animator != null && playableGraph.IsValid())
                {
                    clipPlayable.SetTime(t * clip.length);
                    playableGraph.Evaluate();
                }
            }
        }
    }
}
