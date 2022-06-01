using System;
using System.Collections.Generic;
using System.Linq;

namespace MIGEOT_DE_BARAN_LACOUTIERE2.PSI
{
    public class QRCode
    {
        #region Attributs
        int nbCara;
        string phrase;
        int mode = 2;
        int[] masque = new int[] { 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0 };
        int taille; // pour taille 1 ou 2
        Pixel[,] matQRCode;
        bool[,] matricebooléen;
        #endregion

        #region Constructeur
        /// <summary>
        /// Initalise et remplit les attributs de la classe QRCode d'une phrase
        /// </summary>
        /// <param name="phrase">phrase que passe en paramètre</param>
        public QRCode(string phrase)
        {
            this.phrase = phrase.ToUpper();
            Console.WriteLine("Phrase taille " + phrase.Length);
            if (phrase.Length < 47) nbCara = phrase.Length;
            else nbCara = -1; // montrera une erreur lors de l'affichage du QrCode
            if (phrase.Length < 25)
            {
                taille = 1;
                this.matQRCode = new Pixel[21, 21];
                this.matricebooléen = new bool[21, 21];
            }
            else if (phrase.Length < 47)
            {
                this.matQRCode = new Pixel[25, 25];
                this.matricebooléen = new bool[25, 25];
                taille = 2;
            }
      
         
        }

        #endregion

        #region Propriete

        #endregion

        #region Méthodes

        /// <summary>
        /// Méthode qui prend un entier et le convertit en binaire
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public int[] ConvertIntToBinaire(int nombre, int i)
        {
            int[] result = new int[i];
            double diviseur = Math.Pow(2, i - 1);
            int diviseur2 = Convert.ToInt32(diviseur);

            for (int k = 0; k < i; k++)
            {
                result[k] = nombre / diviseur2;
                nombre = nombre % diviseur2;
                diviseur2 = diviseur2 / 2;
            }

            return result;
        }


        /// <summary>
        /// Méthode qui prend une list d'entier(dans notre cas des 0 ou 1) et le convertit en tableau de byte
        /// </summary>
        /// <param name="maliste">liste que l'on prend et que l'on converti en int. </param>
        /// <returns>tableau de int </returns>
        public byte[] ConvertBinaireToByte(List<int> maliste)
        {
            byte[] tabfinal = new byte[maliste.Count / 8];
            for (int i = 0; i < tabfinal.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    tabfinal[i] += (byte)(maliste[i * 8 + j] * Math.Pow(2, 7 - j));
                }
            }

            return tabfinal;
        }

        /// <summary>
        /// Méthode qui convertit un binaire en entier
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        public int ConvertBinaireToInt(int [] tab)
        {
            int entier = 0;
            for (int i = tab.Length - 1; i >= 0; i--)
            {
                entier += tab[tab.Length - 1 - i] * Convert.ToInt32(Math.Pow(2, i));
            }
            return entier;
        }


        /// <summary>
        /// Méthode qui convertit un charactère en entier (langage alphanumérique)
        /// </summary>
        /// <param name="c">le caractère à convertir</param>
        /// <returns>le int correspondant en alphanumérique</returns>
        public int ConvertCharToInt(char c)
        {
            //  Dictionary<>
            int result = 0;
            result = Convert.ToInt32(c);
            Console.Write(c + " " + result);
            if (48 <= result && result < 58) result = result - 48;
            if (65 <= result && result < 91) result = result - 55;
            switch (c)
            {
                case ' ': //espace;
                    result = 36;
                    break;

                case '&': //dollars
                    result = 37;
                    break;

                case '%': //pourcent
                    result = 38;
                    break;

                case '*': //*
                    result = 39;
                    break;

                case '+': //+
                    result = 40;
                    break;

                case '-': //-
                    result = 41;
                    break;

                case '.': //.
                    result = 42;
                    break;

                case '/': // /
                    result = 43;
                    break;

                case ':':// :
                    result = 44;
                    break;




            }
            Console.WriteLine(" " + result);
            return result;
        }


        /// <summary>
        /// Méthode qui renvoie la somme de deux caratères (pour convertir après ce nombre en une chaîne binaire de 11 bits)
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public int Somme(char c1, char c2)
        {
            int result = 0;
            if (c1 != '&') result = 45 * ConvertCharToInt(c1) + ConvertCharToInt(c2);
            else
            {
                result = ConvertCharToInt(c2);
                Console.WriteLine("Coucou + " + c2);
            }

            return result;

        }

        /// <summary>
        /// Méthode qui convertit le masque1 (renvoie un pixel blanc pour 0 et un pixel noir pour 1)
        /// </summary>
        /// <param name="valeur"></param>
        /// <returns></returns>
        public Pixel Convertisseur(int valeur)
        {
            Pixel result = null;

            if (valeur == 0)
            {
                result = new Pixel("blanc");
            }

            if (valeur == 1)
            {

                result = new Pixel("noir");
            }
            return result;
        }





        /// <summary>
        /// Méthode qui créée la structure du QRCode de taille 1 ou 2
        /// </summary>
        public void CreationBase1QRCode()
        {

            for (int i = 0; i < matQRCode.GetLength(0); i++)
            {
                for (int j = 0; j < matQRCode.GetLength(1); j++)
                {
                    matQRCode[i, j] = new Pixel(120, 120, 120);
                    matricebooléen[i, j] = false;
                }
            }
            //Création du motif  noir en bas à gauche
            matQRCode[matQRCode.GetLength(0) - 8, 8] = new Pixel(0, 0, 0);

            // création des 3 observateurs
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (((i == 1 || i == 5) && j > 0 && j < 6) || ((j == 1 || j == 5) && i > 0 && i < 6))
                    {
                        matQRCode[i, j] = new Pixel("blanc");//en haut a gauche
                        matQRCode[matQRCode.GetLength(0) - 1 - i, j] = new Pixel("blanc"); // en bas a gauche
                        matQRCode[i, matQRCode.GetLength(1) - 1 - j] = new Pixel("blanc");// en haut a droite
                        matricebooléen[i, j] = true;
                        matricebooléen[matQRCode.GetLength(0) - 1 - i, j] = true;
                        matricebooléen[i, matQRCode.GetLength(1) - 1 - j] = true;
                    }
                    else
                    {
                        matQRCode[i, j] = new Pixel("noir"); // On fait un carré noir de 7/7 sur les 3 coins , en haut a gauche
                        matQRCode[matQRCode.GetLength(0) - 1 - i, j] = new Pixel("noir"); // en bas a gauche
                        matQRCode[i, matQRCode.GetLength(1) - 1 - j] = new Pixel("noir");// en haut a droite
                        matricebooléen[i, j] = true;
                        matricebooléen[matQRCode.GetLength(0) - 1 - i, j] = true;
                        matricebooléen[i, matQRCode.GetLength(1) - 1 - j] = true;
                       
                    }

                    if (i == 6) // on remplie la ligne extérieur de blanc
                    {
                        matQRCode[i + 1, j] = new Pixel("blanc");//en haut a gauche
                        matQRCode[matQRCode.GetLength(0) - 1 - (i + 1), j] = new Pixel("blanc"); // en bas a gauche
                        matQRCode[i + 1, matQRCode.GetLength(1) - 1 - j] = new Pixel("blanc");// en haut a droite
                        matricebooléen[i+1, j] = true;
                        matricebooléen[matQRCode.GetLength(0) - 1 - (i + 1), j] = true;
                        matricebooléen[i + 1, matQRCode.GetLength(1) - 1 - j] = true;


                        if (j == 6) // remplir le coin de blanc
                        {
                            matQRCode[i + 1, j + 1] = new Pixel("blanc");//en haut a gauche
                            matQRCode[matQRCode.GetLength(0) - 1 - (i + 1), j + 1] = new Pixel("blanc"); // en bas a gauche
                            matQRCode[i + 1, matQRCode.GetLength(1) - 1 - (j + 1)] = new Pixel("blanc");// en haut a droite
                            matricebooléen[i + 1, j+1] = true;
                            matricebooléen[matQRCode.GetLength(0) - 1 - (i + 1), j + 1] = true;
                            matricebooléen[i + 1, matQRCode.GetLength(1) - 1 - (j + 1)] = true;
                        }
                    }

                    if (j == 6) // on remplie la colonne extérieur de blanc
                    {
                        matQRCode[i, j + 1] = new Pixel("blanc");
                        matQRCode[matQRCode.GetLength(0) - 1 - i, j + 1] = new Pixel("blanc"); // en bas a gauche
                        matQRCode[i, matQRCode.GetLength(1) - 1 - (j + 1)] = new Pixel("blanc");// en haut a droite
                        matricebooléen[i , j + 1] = true;
                        matricebooléen[matQRCode.GetLength(0) - 1 - i, j + 1] = true;
                        matricebooléen[i, matQRCode.GetLength(1) - 1 - (j + 1)] = true;
                    }

                }
            }

            for (int i = 8; i < matQRCode.GetLength(0) - 8; i++)
            {
                if (i % 2 == 0)
                {
                    matQRCode[6, i] = new Pixel("noir");
                    matQRCode[i, 6] = new Pixel("noir");
                    matricebooléen[6, i] = true;
                    matricebooléen[i,6] = true;
                }

                else
                {
                    matQRCode[6, i] = new Pixel("blanc");
                    matQRCode[i, 6] = new Pixel("blanc");
                    matricebooléen[6, i] = true;
                    matricebooléen[i, 6] = true;
                }

            }

            //On rajoute le masque + correcteur
            //la ligne
            int constante = 0;
            for (int j = 0; j < 8; j++)
            {
                Pixel gris = new Pixel(120, 120, 120);
                if (matQRCode[8, j].Egale(gris))
                {
                    matQRCode[8, j] = Convertisseur(masque[j - constante]);
                    matricebooléen[8, j] = true;
                   
                }
                else
                {
                    constante++;
                }
            }

            for (int j = 0; j < 8; j++)
            {
                matQRCode[8, matQRCode.GetLength(1) - j - 1] = Convertisseur(masque[masque.Length - 1 - j]);
                matricebooléen[8, matQRCode.GetLength(1) - j - 1] = true;
            }
            // la colonne
            int valeur = 0;
            if (taille == 1) valeur = 5;
            if (taille == 2) valeur = 9;

            for (int i = 0; i < masque.Length; i++)
            {

                if (i < 7) //Partie en bas
                {
                    matricebooléen[matQRCode.GetLength(0) - 1 - i, 8] = true;
                    matQRCode[matQRCode.GetLength(0) - 1 - i, 8] = Convertisseur(masque[i]);

                }
                else // partie en haut
                {
                    if (i == 9) valeur++;
                    matQRCode[matQRCode.GetLength(0) - 1 - i - valeur, 8] = Convertisseur(masque[i]);
                    matricebooléen[matQRCode.GetLength(0) - 1 - i, 8] = true;
                }

            }

            //on ajoute le motif d'allignement pour la taille 2
            if (taille == 2)
            {
                for (int i = 16; i < 21; i++)
                {
                    for (int j = 16; j < 21; j++)
                    {
                        matricebooléen[i, j] = true;
                        if ((i == 17 || i == 19) && (j != 16 && j != 20) || (i == 18 && (j == 17 || j == 19))) matQRCode[i, j] = new Pixel("blanc");
                        else matQRCode[i, j] = new Pixel("noir");
                    }
                }

            }
        }


        /// <summary>
        /// Méthode qui centralise toutes les données à remplir dans le QRCode
        /// </summary>
        /// <returns></returns>
        public List<int> RecuperationDonnees()
        {
            List<int> liste = new List<int>();
            int[] tabmode = ConvertIntToBinaire(mode, 4); // on ajoute le mode d'abord 0100

            foreach (int element in tabmode)
            {
                liste.Add(element);
            }

            int[] tabchar = ConvertIntToBinaire(nbCara, 9); //on ajoute l'indicateur du nombre de caractères sur 9 bits ;

            foreach (int element in tabchar) liste.Add(element);

            for (int i = 0; i < nbCara; i = i + 2)
            {
                if (i + 1 < nbCara)
                {
                    int[] tab = ConvertIntToBinaire(Somme(phrase[i], phrase[i + 1]), 11); //on crée des tableau de 11 par deux lettres
                    foreach (int element in tab) liste.Add(element);
                }
                else
                {
                    int[] tab = ConvertIntToBinaire(Somme('&', phrase[i]), 6); //si le nombre est impair cas different , le '&' montre l'erreur
                    Console.Write(" ");
                    foreach (int element in tab)
                    {

                        Console.Write("  " + element);

                        liste.Add(element);
                    }

                }
            }

            //Rajouter les 0 ? Si <148 ajoute 4 0 ensuite on complete pour faire un multiple de 8 et on ajoute le chaine 237/17

            if (liste.Count > 147 && taille == 1) // cas entre 148 et 152
            {
                int reste1 = liste.Count - 148;
                while (reste1 != 0)
                {
                    liste.Add(0);
                    reste1--;
                }

            }
            else if (liste.Count > 267 && taille == 2)
            {

                int reste2 = liste.Count - 260;
                while (reste2 != 0)
                {
                    liste.Add(0);
                    reste2--;
                }
            }
            else // cas pour l
            {
                for (int i = 0; i < 4; i++) liste.Add(0); // on ajoute 4 0
                while (liste.Count % 8 != 0)
                {
                    liste.Add(0);
                }

            }

            // taille 1 pour le remplissage avec 237/17
            int reste = 0;
            if (taille == 1) reste = (152 - liste.Count) / 8;
            if (taille == 2) reste = (272 - liste.Count) / 8;
            //else reste = (272 - liste.Count) / 8;
            for (int i = 0; i < reste; i++)
            {
                if (i % 2 == 0)
                {
                    int[] tab = ConvertIntToBinaire(236, 8);
                    foreach (int element in tab) liste.Add(element);
                }
                else
                {
                    int[] tab = ConvertIntToBinaire(17, 8);
                    foreach (int element in tab) liste.Add(element);
                }
            }


            //Récuperation des données du correcteur
            List<int> maliste2 = RedSolomon(liste);
            foreach (int element in maliste2)
            {
                int[] tab = ConvertIntToBinaire(element, 8);
                foreach (int element2 in tab) liste.Add(element2);
            }

            return liste;
        }



        /// <summary>
        /// Méthode qui renvoie le correcteur grâce à RedSolomon
        /// </summary>
        /// <param name="info">chaine de bits écrite en amon</param>
        /// <returns>renvoie une liste de int </returns>
        public List<int> RedSolomon(List<int> info)
        {
            List<int> liste = new List<int>();
            int nombre = 7;
            if (taille == 2) nombre = 10;
            byte[] mesdonnes = ConvertBinaireToByte(info);
            byte[] result = ReedSolomonAlgorithm.Encode(mesdonnes, nombre, ErrorCorrectionCodeType.QRCode);
            //byte[] result1 = ReedSolomonAlgorithm.Decode(bytesb, result);   Decoage pas encore fais
            foreach (byte val in result) liste.Add(Convert.ToInt32(val));

            return liste;
        }




        /// <summary>
        /// Méthode qui remplit tout le QRCode
        /// </summary>
        public void RemmplissageTexte()
        {
            Pixel gris = new Pixel(120, 120, 120);
            List<int> maliste = RecuperationDonnees();
            Console.WriteLine("Nombres d'éléments : " + maliste.Count());
            for (int i = 0; i < maliste.Count / 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    Console.Write(maliste[k + i * 8]);
                }
                Console.Write("   ");
            }
            int j = matQRCode.GetLength(1) - 1;
            int index = matQRCode.GetLength(0) - 1;
            string sens = "monte"; // ou descend
            for (int i = 0; i < maliste.Count(); i += 2)
            {
                Console.WriteLine(maliste.Count + " maliste" + " i :" + i);
                if (i == maliste.Count - 1)
                {
                    matQRCode[index, j] = ConvertisseurMasque(maliste[i], index, j);
                }
                else
                {
                    if (sens == "monte")
                    {
                        if (taille == 2 && j == 16 && (index == 20 || index == 18))
                        {
                            if (index == 20)
                            {
                                matQRCode[index, j - 1] = ConvertisseurMasque(maliste[i], index, j - 1);
                                matQRCode[index - 1, j - 1] = ConvertisseurMasque(maliste[i + 1], index - 1, j - 1);
                                index = index - 2;
                            }
                            if (index == 18)
                            {
                                matQRCode[index, j - 1] = ConvertisseurMasque(maliste[i], index, j - 1);
                                matQRCode[index - 1, j - 1] = ConvertisseurMasque(maliste[i + 1], index - 1, j - 1);
                                matQRCode[index - 2, j - 1] = ConvertisseurMasque(maliste[i + 2], index - 2, j - 1);
                                i = i + 3;
                                index = index - 3;
                            }

                        }
                        else
                        {
                            while (matQRCode[index, j].Egale(gris) == false)
                            {
                                index = index - 1;
                            }
                            matQRCode[index, j] = ConvertisseurMasque(maliste[i], index, j);
                            matQRCode[index, j - 1] = ConvertisseurMasque(maliste[i + 1], index, j - 1);
                            int k = 1;
                            while (index - k >= 0 && matQRCode[index - k, j].Egale(gris) == false)

                            {
                                k = k + 1;
                            }
                            if (index - k == -1) // si l'index vaut -1 , alors on se déplace de 2 colonnes puisque celle actuelle l'est deja
                            {
                                j = j - 2;
                                sens = "descend";
                                index = 0;
                            }
                            else
                            {
                                if (taille == 2 && j == 16 && (index - 1 == 20 || index - 1 == 18)) index = index - 1;
                                else index = index - k;
                            }
                        }
                    }

                    else if (sens == "descend")
                    {
                        if (j == 6) j = j - 1;
                        while (matQRCode[index, j].Egale(gris) == false)
                        {
                            index = index + 1;
                        }

                        matQRCode[index, j] = ConvertisseurMasque(maliste[i], index, j);
                        matQRCode[index, j - 1] = ConvertisseurMasque(maliste[i + 1], index, j - 1);
                        int k = 1;
                        while (index + k < matQRCode.GetLength(0) && matQRCode[index + k, j].Egale(gris) == false)
                        {
                            k = k + 1;
                        }
                        if (index + k == matQRCode.GetLength(0))
                        {
                            j = j - 2;
                            sens = "monte";
                            index = matQRCode.GetLength(0) - 1;
                        }
                        else
                        {
                            index = index + k;
                        }

                    }
                }



            }
        }




        /// <summary>
        /// Méthode qui le pixel de la matrice en blanc s'il est gris et complète le QRCode de la Version 2
        /// </summary>
        public void RemplissageV2()
        {
            Pixel gris = new Pixel(120, 120, 120);
            for (int i = 0; i < matQRCode.GetLength(0); i++)
            {
                for (int j = 0; j < matQRCode.GetLength(1); j++)
                {
                    if (matQRCode[i, j].Egale(gris))
                    {
                        matQRCode[i, j] = new Pixel("blanc");
                    }
                }
            }
        }


     

 

        /// <summary>
        /// Méthode qui revoit un pixel un fonction de la valeur (0 ou 1 ) et de si la somme de i et j est pair.
        /// C'est l'aplication du masquage 0, il y a une inversion du blanc ou du noir si i+j%2=0
        /// </summary>
        /// <param name="valeur">valeur du byte</param>
        /// <param name="i">ligne i</param>
        /// <param name="j">colonne</param>
        /// <returns>Pixel blanc ou noir</returns>
        public Pixel ConvertisseurMasque(int valeur, int i, int j)

        {
            Pixel result = null;
            if (valeur == 0)
            {
                if ((i + j) % 2 == 0)
                {
                    Console.WriteLine("oui i : " + i + " j : " + j);
                    result = new Pixel("noir");
                }
                else result = new Pixel("blanc");
            }

            if (valeur == 1)
            {
                if ((i + j) % 2 == 0) result = new Pixel("blanc");
                else result = new Pixel("noir");
            }
            return result;
        }


        /// <summary>
        /// Méthode qui affiche le QRCode en créant une image
        /// </summary>
        /// <param name="filename">Fichier ou l'image(le QRCode) va être enregistré</param>
        public void AffichageQRCode(string filename)
        {

            if (nbCara != -1)
            {
                CreationBase1QRCode();
                RemmplissageTexte();
                RemplissageV2();
                MyImage image = new MyImage(matQRCode);
                image.Aggrandir(10, filename);
            }
            else Console.WriteLine("Trop de caractère");


        }

        /// <summary>
        /// Converti un pixel qui est une couleur en 0 ou 1 en fonction de sa valeur et du masque
        /// </summary>
        /// <param name="pixel"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public static  int ConvertisseurPixelToInt(Pixel pixel,int i,int j)
        {
            int result = 0;
            if(pixel.Egale(new Pixel ("blanc"))==true)
            {
                if((i+j)%2==0)
                {
                    result = 1;
                }
               
            }
            else
            {
                if ((i + j) % 2 != 0)
                {
                    result = 1;
                }
            }

            return result;
        }


        /// <summary>
        /// Decode un QRCODE
        /// </summary>
        /// <returns>renvoie la chaine de caractère qui correspond au QRCode</returns>
        public string  Decodage()
        {
            CreationBase1QRCode();
            RemmplissageTexte();
            RemplissageV2();
            string chainedecara= null;


            List<int> maliste = new List<int>();

            string sens = "monte";
            for(int j=matQRCode.GetLength(0)-1;j>1;j=j-2)
            {

                if (sens == "monte")
                {
                  
                    for (int i = matQRCode.GetLength(1) - 1; i >= 0; i--)
                    {
                        if (j == matQRCode.GetLength(1) - 1 - 8 && taille == 2 && i >= matQRCode.GetLength(0) - 1 - 8 && i <= matQRCode.GetLength(1) - 1 - 4)
                        {
                            maliste.Add(ConvertisseurPixelToInt(matQRCode[i, j - 1], i, j - 1));
                        }
                        else
                        {
                            if (matricebooléen[i, j] == false)
                            {
                                maliste.Add(ConvertisseurPixelToInt(matQRCode[i, j], i, j));
                            }
                            if (matricebooléen[i, j - 1] == false)
                            {
                                maliste.Add(ConvertisseurPixelToInt(matQRCode[i, j - 1], i, j - 1));
                            }
                        }
                    }
                    sens = "descend";
                }

                else
                {
                    for(int i=0;i<matQRCode.GetLength(1);i++)
                    {
                        if (matricebooléen[i, j] == false)
                        {
                            maliste.Add(ConvertisseurPixelToInt(matQRCode[i, j], i, j));
                        }
                        if (matricebooléen[i, j - 1] == false)
                        {
                            maliste.Add(ConvertisseurPixelToInt(matQRCode[i, j - 1], i, j - 1));
                        }
                    }
                    sens = "monte";
                }
        
            }
            int[] tab = new int[9];
            for (int i=4;i<13;i++)
            {
                tab[i - 4] = maliste[i];
            }
            int nombrecara = ConvertBinaireToInt(tab);
            int compteur= 0;
            if (nombrecara % 2 == 0)
            {
                compteur = (nombrecara/2) * 11;
                for (int i = 13; i < compteur + 13; i = i + 11)
                {
                    int result2 = 0;
                    int puissance = 1024;
                    for (int j = 0; j < 11; j++)
                    {
                        result2 = result2 + maliste[i + j] * puissance;
                        puissance = puissance / 2;
                    }
                    char cara1 = Obtenir_Caractere(result2 / 45);
                    char cara2 = Obtenir_Caractere(result2 % 45);
                    chainedecara += cara1;
                    chainedecara += cara2;
                }
            }
            else
            {
                compteur = ((nombrecara - 1)/2) * 11 + 6;
                for (int i = 13; i < compteur + 13 - 6; i = i + 11)
                {
                    int result2 = 0;
                    int puissance = 1024;
                    for (int j = 0; j < 11; j++)
                    {
                        result2 = result2 + maliste[i + j] * puissance;
                        puissance = puissance / 2;
                    }
                    char cara1 = Obtenir_Caractere(result2 / 45);
                    char cara2 = Obtenir_Caractere(result2 % 45);
                    chainedecara += cara1;
                    chainedecara += cara2;
                }
                int result3 = 0;
                int puissance2 = 32;
                for (int j = compteur + 13 - 6; j < compteur + 13; j++)
                {
                    result3 = result3 + maliste[j] * puissance2;
                    puissance2 = puissance2 / 2;
                }
                char cara3 = Obtenir_Caractere(result3);
                chainedecara += cara3;

            }
            Console.WriteLine(nombrecara);
            Console.WriteLine(chainedecara);

            return chainedecara;


        }

       /// <summary>
       /// Converti un caractère en fonction de son code en alphanumérique
       /// </summary>
       /// <param name="code">code est le numéro en alphanumérique</param>
       /// <returns>renvoie le caractère correspondant </returns>
        public char Obtenir_Caractere(int code)
        {
            char[] tab = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N','O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', ' ', '$', '%', '*', '+', '-', '.', '/', ':' };

          
                char caractere = tab[code];
            

            return caractere;
        }








        #endregion

    }
}
