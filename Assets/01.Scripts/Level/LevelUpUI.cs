
    using System;
    using DG.Tweening;
    using UnityEngine;

    public class LevelUpUI:MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Transform textTransform;

        private Vector2 originPos;

        private void Awake()
        {
            originPos = textTransform.localPosition;
            gameObject.SetActive(false);
        }

        public void Play()
        {
            gameObject.SetActive(true);
            
            canvasGroup.alpha = 0;
            textTransform.localPosition = originPos;
            textTransform.localScale = Vector3.zero;
            
            Sequence seq = DOTween.Sequence();
            
            seq.Append(canvasGroup.DOFade(1, 0.2f));
            seq.Join(textTransform.DOScale(1f,0.2f).SetEase(Ease.OutBack));
            seq.Join(textTransform.DOLocalMoveY(originPos.y + 0.5f, 0.4f));

            seq.AppendInterval(0.5f);

            seq.Append(canvasGroup.DOFade(0f, 0.3f));

            seq.OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        }
    }
