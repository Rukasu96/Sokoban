using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelClearUI : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Transform levelClearTransform;
    [SerializeField] private TextMeshProUGUI levelClearText;
    [SerializeField] private Transform movesCountTransform;
    [SerializeField] private TextMeshProUGUI movesCountText;
    [SerializeField] private Transform[] stars;
    [SerializeField] private Transform[] buttons;

    [SerializeField] private RatingCalculator ratingCalculator;
    [SerializeField] private SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = sceneLoader.GetComponent<SceneLoader>();
        movesCountText.text = Player.movesCount.ToString();
        startAnim();
    }

    private async void startAnim()
    {
        var tasks = new List<Task>
        {
            background.DOFade(0.68f, 0.5f).SetDelay(1f).AsyncWaitForCompletion(),
            levelClearText.DOFade(1f, 0.5f).AsyncWaitForCompletion(),
            levelClearTransform.DOScale(1.2f, 0.5f).AsyncWaitForCompletion(),
            levelClearTransform.DOLocalMoveY(450, 1f).SetEase(Ease.Linear).AsyncWaitForCompletion(),
            movesCountText.DOFade(1f, 0.5f).SetDelay(1.5f).AsyncWaitForCompletion(),
            movesCountTransform.DOScale(1.2f, 0.5f).SetLoops(2,LoopType.Yoyo).SetDelay(1.5f).AsyncWaitForCompletion(),
        };

        await Task.WhenAll(tasks);

        PlayRatingAnimation();
    }

    private void PlayRatingAnimation()
    {
        var RatingSequence = DOTween.Sequence();

        foreach(Transform star in stars)
        {
            star.GetComponent<Image>().DOFade(1f, 1f);
        }

        for (int i = 0; i < ratingCalculator.GetRating(); i++)
        {
            RatingSequence.Append(stars[i].GetChild(0).GetComponent<Image>().DOFade(1f,0.2f));
            RatingSequence.Append(stars[i].DOScale(1.4f, 0.2f).SetLoops(2, LoopType.Yoyo));
        }

        RatingSequence.OnComplete(() => PlayButtonsAnim());
    }

    private void PlayButtonsAnim()
    {
        var buttonSequence = DOTween.Sequence();

        foreach (Transform button in buttons)
        {
            buttonSequence.Append(button.GetComponent<Image>().DOFade(1f, 0.01f));
            buttonSequence.Append(button.GetChild(0).GetComponent<TextMeshProUGUI>().DOFade(1f, 0.02f));
            buttonSequence.Append(button.DOScale(1.2f, 0.3f).SetLoops(2, LoopType.Yoyo));
        }
    }

    public void Continue()
    {
        int sceneId = SceneManager.GetActiveScene().buildIndex + 1;
        if(sceneId == SceneManager.sceneCountInBuildSettings)
        {
            StartCoroutine(sceneLoader.LoadCustomLevel(0));
        }
        StartCoroutine(sceneLoader.LoadCustomLevel(sceneId));
    }

    public void Restart()
    {
        int sceneId = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(sceneLoader.LoadCustomLevel(sceneId));
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
