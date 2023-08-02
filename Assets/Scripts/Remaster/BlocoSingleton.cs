using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class BlocoSingleton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static BlocoSingleton Instance { get; private set; }

    public List<int> Linha;
    public List<int> Coluna;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void DefinirLinha(Dropdown dropdown)
    {
        Linha.Add(dropdown.value);
    }
    private void DefinirColuna(Dropdown dropdown)
    {
        Coluna.Add(dropdown.value);
    }

    #region IBeginDragHandler implementation
    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region IDragHandler implementation
    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
        throw new NotImplementedException();
    }
    #endregion

    #region IEndDragHandler implementation
    public void OnEndDrag(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }
    #endregion


}

