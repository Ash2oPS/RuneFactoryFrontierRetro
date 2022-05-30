using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpriteOnClick : OnClick
{
    #region PrivateVariables

    [SerializeField]
    private SpriteRenderer _spriteRendererToManipulate;

    [SerializeField]
    private DisplayInfoText _displayInfoTextPrefab;

    private float _r, _g, _b, _a;

    private bool _mouseHasBeenOnTheTile;

    #endregion PrivateVariables

    #region GettersAndSetters

    protected SpriteRenderer SpriteRendererToManipulate { get => _spriteRendererToManipulate; set => _spriteRendererToManipulate = value; }
    protected float R { get => _r; set => _r = value; }
    protected float G { get => _g; set => _g = value; }
    protected float B { get => _b; set => _b = value; }
    protected float A { get => _a; set => _a = value; }

    #endregion GettersAndSetters

    #region InheritedFunctions

    protected override void Start()
    {
        base.Start();

        R = SpriteRendererToManipulate.color.r;
        G = SpriteRendererToManipulate.color.g;
        B = SpriteRendererToManipulate.color.b;
        A = SpriteRendererToManipulate.color.a;
    }

    protected override void OnMouseEnter()
    {
        if (canBeSelected)
        {
            MouseIsOnTheTile();
            _mouseHasBeenOnTheTile = true;

            if (this.GetType() == typeof(FieldTile))
            {
                _pm.SelectedFieldTile = this as FieldTile;
            }
        }
    }

    protected override void OnMouseExit()
    {
        if (canBeSelected && _mouseHasBeenOnTheTile)
        {
            MouseIsNotOnTheTile();
            _mouseHasBeenOnTheTile = false;

            if (this.GetType() == typeof(FieldTile))
            {
                FieldTile thisAsFT = this as FieldTile;
                if (thisAsFT == _pm.SelectedFieldTile)
                {
                    _pm.SelectedFieldTile = null;
                }
            }
        }
    }

    #endregion InheritedFunctions

    #region Functions

    protected void MouseIsOnTheTile()
    {
        ChangeSpriteColor(0.2f, 0.2f, 0.2f, 0);
    }

    protected void MouseIsNotOnTheTile()
    {
        ChangeSpriteColor(-0.2f, -0.2f, -0.2f, 0);
    }

    protected void ChangeSpriteColor(float newR, float newG, float newB, float newA)
    {
        R += newR;
        G += newG;
        B += newB;
        A += newA;

        SpriteRendererToManipulate.color = new Vector4(R, G, B, A);
    }

    protected void DisplayInformation(string textToDisplay, Color textColor)
    {
        DisplayInfoText dit = Instantiate(_displayInfoTextPrefab, transform);

        dit.GetComponent<TextMesh>().text = textToDisplay;
        dit.GetComponent<TextMesh>().color = textColor;
    }

    #endregion Functions
}