using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpriteOnClick : OnClick
{
    #region PrivateVariables

    [SerializeField]
    private SpriteRenderer _spriteRendererToManipulate;

    #endregion PrivateVaribables

    #region GettersAndSetters

    protected SpriteRenderer SpriteRendererToManipulate { get => _spriteRendererToManipulate; set => _spriteRendererToManipulate = value; }

    #endregion GettersAndSetters

    #region InheritedFunctions

    protected override void OnMouseEnter()
    {
        MouseIsOnTheTile();
    }

    protected override void OnMouseExit()
    {
        MouseIsNotOnTheTile();
    }

    #endregion InheritedFunctions

    #region Functions

    protected void MouseIsOnTheTile()
    {
        ChangeSpriteColor(0.2f, 0, 0, 0);
    }
    protected void MouseIsNotOnTheTile()
    {
        ChangeSpriteColor(-0.2f, 0, 0, 0);
    }
    protected void ChangeSpriteColor(float newR, float newG, float newB, float newA)
    {
        float r = SpriteRendererToManipulate.color.r + newR;
        float g = SpriteRendererToManipulate.color.g + newG;
        float b = SpriteRendererToManipulate.color.b + newB;
        float a = SpriteRendererToManipulate.color.a + newA;

        SpriteRendererToManipulate.color = new Vector4(r, g, b, a);
    }

    #endregion Functions
}
