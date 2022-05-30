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
        ZQSD ou les flèches directionnelles pour se déplacer.
        Avec la souris tu peux cliquer sur des tiles quand elles sont sélectionnées (rapproche-t-en avec le perso pour rentrer
        dans leur zone de détection de la souris) comme celles du champs ou le lit (le carré rose (oui c'est un lit (il a l'air confortable (miam)))).
        Tu peux switcher d'item équipé avec la molette de la souris.
        Clic droit ça utilise l'objet sélectionné et clic gauche ça va intéragir avec l'élément sélectionné (dormir dans le lit sus-mentionné, récolter les
        plantations, caresser un monstre afin qu'il puisse nous aider dans la gestion du champs et par la suite battre le boss final après avoir trouvé toutes
        les pierres légendaires gardées par les 8 gardiens ancestraux (je m'avance ptet un peu trop pour tout ça))

     Bugs connus
        La sélection des tiles qui galère
        Les tiles qui des fois oublient de revenir dans leur couleur d'origine, du coup elles peuvent avoir des couleurs pas prévues (en même
        temps j'avais qu'à pas faire un foutoir comme je l'ai fait pour les couleurs des tiles omega oof)
        Boh et puis j'arrive pas à update mon hud d'inventaire quand on ajoute ou enlève un item, tout ça
     */
}