using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Debug.LogWarning("Double-clique-moi dessus, Louis ! :D");
    }

    /*Comment jouer ?
        ZQSD ou les fl�ches directionnelles pour se d�placer.
        Avec la souris tu peux cliquer sur des tiles quand elles sont s�lectionn�es (rapproche-t-en avec le perso pour rentrer
        dans leur zone de d�tection de la souris) comme celles du champs ou le lit (le carr� rose (oui c'est un lit (il a l'air confortable (miam)))).
        Tu peux switcher d'item �quip� avec la molette de la souris.
        Clic droit �a utilise l'objet s�lectionn� et clic gauche �a va int�ragir avec l'�l�ment s�lectionn� (dormir dans le lit sus-mentionn�, r�colter les
        plantations, caresser un monstre afin qu'il puisse nous aider dans la gestion du champs et par la suite battre le boss final apr�s avoir trouv� toutes
        les pierres l�gendaires gard�es par les 8 gardiens ancestraux (je m'avance ptet un peu trop pour tout �a))

     Bugs connus
        La s�lection des tiles qui gal�re
        Les tiles qui des fois oublient de revenir dans leur couleur d'origine, du coup elles peuvent avoir des couleurs pas pr�vues (en m�me
        temps j'avais qu'� pas faire un foutoir comme je l'ai fait pour les couleurs des tiles omega oof)
        Boh et puis j'arrive pas � update mon hud d'inventaire quand on ajoute ou enl�ve un item, tout �a
     */
}