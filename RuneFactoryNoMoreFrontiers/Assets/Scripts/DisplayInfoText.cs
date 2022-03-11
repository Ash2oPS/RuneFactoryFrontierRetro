using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInfoText : MonoBehaviour
{
    #region PrivateVariables

    [SerializeField]
    private TextMesh _textMeshToAnimate;

    [SerializeField]
    [Range(0, 1)]
    private float _alphaToAnimate;

    #endregion PrivateVaribables

    #region GettersAndSetters

	public TextMesh TextMeshToAnimate { get => _textMeshToAnimate; set => _textMeshToAnimate = value; }
    public float AlphaToAnimate { get => _alphaToAnimate; set => _alphaToAnimate = value; }

    #endregion GettersAndSetters

    #region InheritedFunctions

    private void Update()
    {
        float r = TextMeshToAnimate.color.r;
        float g = TextMeshToAnimate.color.g;
        float b = TextMeshToAnimate.color.b;

        float a = AlphaToAnimate;

        TextMeshToAnimate.color = new Vector4(r, g, b, a);
    }

    #endregion InheritedFunctions

    #region Functions

    private void DetroySelf()
    {
        Destroy(gameObject);
    }

    #endregion Functions
}
