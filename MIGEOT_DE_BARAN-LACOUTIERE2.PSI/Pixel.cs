using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIGEOT_DE_BARAN_LACOUTIERE2.PSI
{
    public class Pixel
    {
        #region attributs

        byte rouge;
        byte bleu;
        byte vert;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constucteur qui crée un pixel dans un tableau de byte, il est utile pour la recuperation de données d'une image
        /// </summary>
        /// <param name="info">tablau de byte ou l'on cherche les composantes du pixel</param>
        /// <param name="index">premier index des couleurs bleu vert puis rouge</param>
        public Pixel(byte[] info, int index)
        {

            this.bleu = info[index];
            this.vert = info[index + 1];
            this.rouge = info[index + 2];

        }

        /// <summary>
        /// Constucteur qui crée un pixel avec ses trois composantes, rouge vert bleu
        /// </summary>
        /// <param name="rouge">intensité de rouge voulu dans le pixel</param>
        /// <param name="vert">intensité de vert voulu dans le pixel</param>
        /// <param name="bleu">intensité de bleu voulu dans le pixel</param>
        public Pixel(byte rouge, byte vert, byte bleu)
        {
            this.bleu = bleu;
            this.rouge = rouge;
            this.vert = vert;
        }

        /// <summary>
        /// Constructeur qui permet d'initaliser un pixel blanc ou noir avec un string, il est utilisé pour les qrcodes
        /// </summary>
        /// <param name="couleur"> blanc ou noir, permet de choisir la couleur du pixel</param>
        public Pixel(string couleur)
        {
            if (couleur == "noir")
            {
                this.bleu = 0;
                this.rouge = 0;
                this.vert = 0;
            }
            if (couleur == "blanc")
            {
                this.bleu = 255;
                this.rouge = 255;
                this.vert = 255;
            }
        }

        #endregion

        #region Propriétés
        /// <summary>
        /// Propriété permettant de récuperer ou changer la valeur rouge d'un pixel
        /// </summary>
        public byte Rouge
        {
            get { return this.rouge; }
            set { this.rouge = value; }
        }

        /// <summary>
        /// Propriété permettant de récuperer ou changer la valeur rouge d'un pixel
        /// </summary>
        public byte Bleu
        {
            get { return this.bleu; }
            set { this.bleu = value; }
        }

        /// <summary>
        /// Propriété permettant de récuperer ou changer la valeur rouge d'un pixel
        /// </summary>
        public byte Vert
        {
            get { return this.vert; }
            set { this.vert = value; }

        }



        #endregion

        #region Méthode
        /// <summary>
        /// Méthode qui renvoie les informations d'un pixel
        /// </summary>
        /// <returns>chaine de caractère </returns>
        public string toString()
        {
            return "R" + rouge + "G" + vert + "B" + bleu;
        }
        /// <summary>
        /// Méthode qui renvoie vrai si les deux pixels sont les mêmes et faux s'ils sont différents
        /// </summary>
        /// <param name="pixel2">pixel numero avec qui tester l'égalité</param>
        /// <returns>vrai ou faux</returns>
        public bool Egale(Pixel pixel2)
        {
            bool b = false;
            if (pixel2.bleu == bleu && pixel2.vert == vert && pixel2.rouge == rouge)
            {
                b = true;
            }
            return b;

        }



        #endregion
    }
}
