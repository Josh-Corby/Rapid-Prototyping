using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JMC : MonoBehaviour
{

    ///<summary>
    ///shuffle a list using unity's random
    /// </summary>
    /// <typeparam name="T">The data type</typeparam>
    /// <param name="_list">The list to shuffle</param>
    /// <returns></returns>
   

    public static List<T> ShuffleList<T>(List<T> _list)
    {
        for (int i = 0; i < _list.Count; i++)
        {
            T temp = _list[i];
            int randomIndex = UnityEngine.Random.Range(i, _list.Count);
            _list[i] = _list[randomIndex];
            _list[randomIndex] = temp;

        }
        return _list;
    }

    /// <summary>
    /// Gets a random colour
    /// </summary>
    /// <returns>A random colour</returns>
    public Color GetRandomColour()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    public void FadeInCanvas(CanvasGroup _cvg)
    {
        _cvg.DOFade(1, 0.5f);
        _cvg.interactable = true;
        _cvg.blocksRaycasts = true;
    }

    public void FadeOutCanvas(CanvasGroup _cvg)
    {
        _cvg.DOFade(0, 0.5f);
        _cvg.interactable = true;
        _cvg.blocksRaycasts = true;
    }
}
