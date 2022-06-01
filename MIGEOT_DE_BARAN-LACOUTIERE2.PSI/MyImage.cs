using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MIGEOT_DE_BARAN_LACOUTIERE2.PSI
{
    class MyImage
    {

        #region Attributs
        string type;
        int taille;
        int tailleoffset;
        int hauteur;
        int largeur;
        int nb_bits_by_colour;
        Pixel[,] image;

        #endregion

        #region Constructeur

        /// <summary>
        /// Transformation d'un fichier en une instance de la classe MyImage
        /// </summary>
        /// <param name="myfile">nom du fichier ou l'on veut récuprer les informations</param>
        public MyImage(string myfile)
        {
            if (myfile != null)
            {
                byte[] info = File.ReadAllBytes(myfile);
                //Commencons par les informations du header, jusqu'a 14
                // Console.Write(info[0]);
                if (info[0] == 66 && info[1] == 77)
                {
                    type = "BM";
                    //  Console.WriteLine("Bitmap");
                }
                byte[] tab = new byte[4];
                for (int i = 2; i < 6; i++)
                {
                    tab[i - 2] = info[i];
                    //  Console.Write(tab[i - 2]+" ");
                }
                int taille = Convertir_Endian_ToInt(tab);
                //  Console.WriteLine("Taille : " + taille);
                this.taille = taille;
                byte[] tab2 = new byte[4];
                for (int i = 10; i < 14; i++)
                {
                    tab2[i - 10] = info[i];
                    //Console.Write(tab2[i - 10] + " ");
                }
                this.tailleoffset = Convertir_Endian_ToInt(tab2);
                //  Console.WriteLine("Taile de l'en tête : " + tailleoffset);

                byte[] tablargeur = new byte[4];


                //largeur 
                for (int i = 18; i < 22; i++)
                {
                    tablargeur[i - 18] = info[i];
                    //Console.Write(tablargeur[i - 18] + " ");
                }
                int largeur = Convertir_Endian_ToInt(tablargeur);
                //  Console.WriteLine("Largeur : " + largeur);
                this.largeur = largeur;

                //longueur 
                byte[] tablongueur = new byte[4];
                for (int i = 22; i < 26; i++)
                {
                    tablongueur[i - 22] = info[i];
                    //   Console.Write(tablongueur[i - 22] + " ");

                }
                this.hauteur = Convertir_Endian_ToInt(tablongueur);
                //  Console.Write("Longueur : " + hauteur);

                //nbrpixel
                byte[] nombresbits = new byte[4];
                for (int i = 28; i < 32; i++)
                {
                    nombresbits[i - 28] = info[i];

                }

                this.nb_bits_by_colour = Convertir_Endian_ToInt(nombresbits);
                this.nb_bits_by_colour = nb_bits_by_colour / 3;

                //Matrice pixel
                this.image = new Pixel[this.hauteur, this.largeur];
                int index = 54;
                for (int i = 0; i < hauteur; i++)
                {
                    for (int j = 0; j < 3 * largeur; j = j + 3)
                    {
                        int a = hauteur - 1 - i;
                        int b = j / 3;

                        this.image[a, b] = new Pixel(info, index + j);

                    }
                    index = index + 3 * largeur;
                }

                byte[] tableau = new byte[4];
                tableau = Convertir_Int_ToEndian(taille);
                Console.WriteLine("Taille en Int");
                foreach (byte element in tableau)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
                // File.WriteAllBytes("Sortie.bmp", info); Test pour ecrire 
            }
            else
            {
                this.image = null;
                this.type = null;
                this.taille = 0;
                this.tailleoffset = 0;
                this.largeur = 0;
                this.hauteur = 0;
                this.nb_bits_by_colour = 0;

            }


        }


        /// <summary>
        /// Constructeur qui crée une copie d'une image
        /// </summary>
        /// <param name="monimage">Image à copier</param>
        public MyImage(MyImage monimage)
        {
            this.type = null;
            this.taille = 0;
            this.tailleoffset = 0;
            this.hauteur = 0;
            this.largeur = 0;
            this.nb_bits_by_colour = 0;
            this.image = null;
            type = monimage.Type;
            taille = monimage.Taille;
            tailleoffset = monimage.Tailleoffset;
            hauteur = monimage.Hauteur;
            largeur = monimage.Largeur;
            nb_bits_by_colour = monimage.Nb_bits_by_colour;
            image = monimage.Image;

        }

        /// <summary>
        /// Constructeur qui crée une image à partir d'une matrice de pixel
        /// </summary>
        /// <param name="monimage">matrice de pixel</param>
        public MyImage(Pixel[,] monimage)
        {
            this.nb_bits_by_colour = 8;
            this.largeur = monimage.GetLength(1);
            this.hauteur = monimage.GetLength(0);
            this.type = "BM";
            this.taille = monimage.GetLength(1) * monimage.GetLength(0) + 54;
            this.tailleoffset = 54;
            this.image = monimage;
        }

        /// <summary>
        /// Constructeur qui crée une image à partir d'une hauteur et une largeur
        /// </summary>
        /// <param name="hauteur">hauteur de l'image</param>
        /// <param name="largeur">largeur de l'image</param>
        public MyImage(int hauteur, int largeur)
        {
            this.type = "BM";
            this.tailleoffset = 54;
            this.taille = this.tailleoffset + hauteur * largeur;
            this.hauteur = hauteur;
            this.largeur = largeur;
            this.nb_bits_by_colour = 8; //à vérifier je suis plus sûre
            this.image = new Pixel[hauteur, largeur];

        }

        #endregion

        #region Propriétés
        /// <summary>
        /// Propriété pour obtenir le type d'une image
        /// </summary>
        public string Type
        {
            get { return this.type; }
        }
        /// <summary>
        /// Propriété pour obtenir la taille d'une iamge
        /// </summary>
        public int Taille
        {
            get { return this.taille; }
        }

        /// <summary>
        /// Propriété pour obtenir la taille offset d'une image
        /// </summary>
        public int Tailleoffset
        {
            get { return this.tailleoffset; }
        }

        /// <summary>
        /// Propriété pour obtenir la hauteur d'une image
        /// </summary>
        public int Hauteur
        {
            get { return this.hauteur; }
        }
        /// <summary>
        /// Propriété pour obtenir la largeur d'une image
        /// </summary>
        public int Largeur
        {
            get { return this.largeur; }
        }

        /// <summary>
        /// Propriété pour otebnir le nb de bits par couleur d'une image
        /// </summary>
        public int Nb_bits_by_colour
        {
            get { return this.nb_bits_by_colour; }
        }


        public Pixel[,] Image
        {
            get { return this.image; }
        }



        #endregion

        #region Méthodes

        #region TD2

        /// <summary>
        /// Méthode qui affiche les propriétés de l'image et les pixels de l'image
        /// </summary>
        /// <returns> chaine de caractère</returns>
        public string toString()
        {
            string pixel = null;
            if (this.image != null)
            {
                string s = null;
                for (int i = 0; i < hauteur; i++)
                {
                    for (int j = 0; j < largeur; j++)
                    {
                        s += this.image[i, j].toString() + " ";
                    }
                    s += "\n";
                }

                pixel = ("Type : " + Type + "\nTaille du fichier : " + taille + "\nTaille offset : " + tailleoffset + "\nLargeur : " + largeur + "\nhauteur : " + hauteur + "\nNombres de bits par couleur : " + nb_bits_by_colour + "\n\n" + s);
            }
            else pixel = "Image nulle" + taille;
            return pixel;

        }


        /// <summary>
        /// Méthode qui convertit une séquence d'octets en un format entier.
        /// </summary>
        /// <param name="tab">tableau à convertir en int</param>
        /// <returns>valeur du int voulue</returns>
        public int Convertir_Endian_ToInt(byte[] tab)
        {
            double resultat = 0;
            int j = 1;
            for (int i = 0; i < tab.Length; i++)
            {

                resultat += tab[i] * j;
                j = j * 256;
            }
            int resultat2 = Convert.ToInt32(resultat);
            return resultat2;
        }


        /// <summary>
        /// Méthode qui converit un format entier en une séquence d'octets
        /// </summary>
        /// <param name="nombre">int à convertir en litte endian</param>
        /// <returns>tableau en little endian </returns>
        public byte[] Convertir_Int_ToEndian(int nombre)
        {
            byte[] resultat = new byte[4];
            int PartieEntiere = 0;
            int j = 16777216; //256^3
            for (int i = 3; i >= 0; i--)
            {
                PartieEntiere = nombre / j;
                nombre = nombre % j;
                resultat[i] = Convert.ToByte(PartieEntiere);
                j = j / 256;
            }
            return resultat;

        }


        /// <summary>
        /// Méthode qui prend une instance de MyImage et la transforme en fichier binaire respectant la structure du fichier.bmp
        /// </summary>
        /// <param name="file">nom du fichier ou l'image va être enregistée</param>
        public void From_Image_To_File(string myfile_test)
        {
            List<byte> write = new List<byte>();

            write.Add(66); //B
            write.Add(77);//M
            for (int i = 0; i < 4; i++)
            {
                write.Add(Convertir_Int_ToEndian(taille)[i]); //taille
            }
            for (int i = 0; i < 4; i++)
            {
                write.Add(0);
            }
            for (int i = 0; i < 4; i++)
            {
                write.Add(Convertir_Int_ToEndian(tailleoffset)[i]); //taille de l(en tete
            }
            write.Add(40); //taille du headerinfo
            write.Add(0);
            write.Add(0);
            write.Add(0);
            for (int i = 0; i < 4; i++)
            {
                write.Add(Convertir_Int_ToEndian(largeur)[i]); //largeur
            }
            for (int i = 0; i < 4; i++)
            {
                write.Add(Convertir_Int_ToEndian(hauteur)[i]); //hauteur
            }
            write.Add(1);
            write.Add(0);
            write.Add(24);
            for (int i = 0; i < 5; i++)
            {
                write.Add(0);
            }
            for (int i = 0; i < 4; i++)
            {
                write.Add(Convertir_Int_ToEndian(taille - tailleoffset)[i]);
            }
            while (write.Count() < 54)
            {
                write.Add(0);
            }
            int enplus = largeur % 4;
            for (int i = hauteur - 1; i >= 0; i--)
            {
                for (int j = 0; j < largeur; j++)
                {
                    write.Add(image[i, j].Bleu);
                    write.Add(image[i, j].Vert);
                    write.Add(image[i, j].Rouge);
                }
                for (int k = 0; k < enplus; k++)
                {
                    write.Add(0);
                }
            }

            byte[] tab = new byte[write.Count];
            for (int i = 0; i < write.Count; i++)
            {
                tab[i] = write[i];
            }

            try
            {
                File.WriteAllBytes(myfile_test, tab);
            }
            catch(Exception e)
            {
                
            }
        }

        #endregion

        #region TD3

        /// <summary>
        /// Méthode qui renvoie l'image en gris
        /// </summary>
        /// <param name="filename">nom du fichier ou l'image va être enregistée</param>
        public void Gris(string filename)
        {
            for (int i = 0; i < image.GetLength(0); i++)
            {
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    byte gris = Convert.ToByte((image[i, j].Bleu + image[i, j].Rouge + image[i, j].Vert) / 3);

                    image[i, j] = new Pixel(gris, gris, gris);


                }
            }
            From_Image_To_File(filename);

        }


        /// <summary>
        /// Méthode qui renvoie l'image en noir et blanc
        /// </summary>
        /// <param name="filename">nom du fichier ou l'image va être enregistée</param>
        public void Noir_Et_Blanc(string filename)
        {
            Gris(filename);
            for (int i = 0; i < image.GetLength(0); i++)
            {
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    if (image[i, j].Bleu < 128)
                    {
                        byte noir = 0;
                        image[i, j] = new Pixel(noir, noir, noir);
                    }
                    else
                    {
                        image[i, j] = new Pixel(255, 255, 255);
                    }



                }
            }
            From_Image_To_File(filename);
        }


        /// <summary>
        /// Méthode qui effectue une rotation à droite
        /// </summary>
        /// <param name="filename">nom du fichier ou l'image va être enregistée</param>
        public void RotationD(string filename)
        {
            Pixel[,] image2 = new Pixel[this.largeur, this.hauteur];
            for (int i = 0; i < image2.GetLength(0); i++)
            {
                for (int j = 0; j < image2.GetLength(1); j++)
                {
                    image2[i, j] = this.image[hauteur - 1 - j, i];
                }
            }
            image = image2;
            this.hauteur = image2.GetLength(0);
            this.largeur = image2.GetLength(1);
            From_Image_To_File(filename);
        }


        /// <summary>
        /// Méthode qui effectue une rotation à gauche
        /// </summary>
        /// <param name="filename">nom du fichier ou l'image va être enregistée</param>
        public void RotationG(string filename)
        {
            Pixel[,] image2 = new Pixel[this.largeur, this.hauteur];
            for (int i = 0; i < image2.GetLength(0); i++)
            {
                for (int j = 0; j < image2.GetLength(1); j++)
                {
                    image2[i, j] = this.image[j, largeur - 1 - i];
                }
            }
            image = image2;
            this.hauteur = image2.GetLength(0);
            this.largeur = image2.GetLength(1);
            From_Image_To_File(filename);
        }


        /// <summary>
        /// Méthode qui effectue une rotation de 180°
        /// </summary>
        /// <param name="filename"></param>
        public void Rotation180(string filename)
        {
            Pixel[,] image2 = new Pixel[this.hauteur, this.largeur];
            {
                for (int i = 0; i < image2.GetLength(0); i++)
                {
                    for (int j = 0; j < image2.GetLength(1); j++)
                    {
                        image2[i, j] = this.image[hauteur - i - 1, largeur - 1 - j];
                    }
                }
                image = image2;
                From_Image_To_File(filename);
            }
        }


        /// <summary>
        /// Méthode qui effectue une rotation de 180°
        /// </summary>
        /// <param name="filename"></param>
        public void Rotation1802(string filename)
        {
            RotationD(filename);
            RotationD(filename);
        }


        /// <summary>
        /// Méthode qui revient l'image en effet miroir
        /// </summary>
        /// <param name="filename">nom du fichier ou l'image va être enregistée</param>
        public void Effet_Miroir(string filename)
        {
            for (int i = 0; i < image.GetLength(0); i++)
            {
                for (int j = 0; j < image.GetLength(1) / 2; j++)
                {
                    Pixel save = image[i, j];
                    image[i, j] = image[i, image.GetLength(1) - 1 - j];
                    image[i, image.GetLength(1) - 1 - j] = save;
                }
            }
            From_Image_To_File(filename);
        }


        /// <summary>
        /// Méthode qui aggranditt une image
        /// </summary>
        /// <param name="multiplication">coefficient d'aggrandissement</param>
        /// <param name="filename">nom du fichier ou l'image va être enregistée</param>
        public void Aggrandir(int multiplication, string filename) // Pour l'instant ne marche que pour des valeurs entieres
        {
            largeur = largeur * multiplication;
            hauteur = hauteur * multiplication;
            taille = hauteur * largeur + tailleoffset;
            Pixel[,] imagefinal = new Pixel[hauteur, largeur];
            for (int i = 0; i < hauteur; i = i + multiplication)
            {
                for (int j = 0; j < largeur; j = j + multiplication)
                {
                    for (int k = i; k < i + multiplication; k++)
                    {
                        for (int f = j; f < j + multiplication; f++)
                        {
                            imagefinal[k, f] = image[i / multiplication, j / multiplication];
                        }

                    }

                }
            }
            image = imagefinal;
            From_Image_To_File(filename);

        }


        /// <summary>
        /// Méthode qui rétrécit l'image en fonction d'un coefficient
        /// </summary>
        /// <param name="division">coéefficient de rétrecissement </param>
        /// <param name="filename">nom du fichier ou l'image va être enregistée</param>
        public void Retrecir(int division, string filename)
        {
            largeur = largeur / division;
            hauteur = hauteur / division;
            taille = hauteur * largeur + tailleoffset;
            Pixel[,] imagefinal = new Pixel[hauteur, largeur];
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    imagefinal[i, j] = image[i * division, j * division];
                }
            }
            image = imagefinal;
            From_Image_To_File(filename);
        }


        #region 1er test de la rotation total
        /// <summary>
        /// Méthode qui permet la rotation d'un angle quelconque de l'image (A FINIR)
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="filename"></param>
        public void Rotation(double angle, string filename)
        {
            int nouvellehauteur = 1000;
            int nouvellelargeur = 1000;
            int milieux = largeur / 2;
            int milieuy = hauteur / 2;
            Pixel[,] imagefinal = new Pixel[nouvellehauteur, nouvellelargeur];
            for (int i = 0; i < nouvellehauteur; i++)
            {
                for (int j = 0; j < nouvellelargeur; j++)
                {
                    imagefinal[i, j] = new Pixel(0, 0, 0);
                }
            }

            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    imagefinal[i * (int)Math.Cos(angle), j * (int)Math.Sin(angle)] = image[i, j];
                }
            }
            largeur = nouvellelargeur;
            hauteur = nouvellehauteur;
            taille = hauteur * largeur + tailleoffset;
            image = imagefinal;
            From_Image_To_File(filename);
        }
        #endregion


        /// <summary>
        /// Méthode qui effectue une rotation dans le sens trigonométrique à partir d'un angle quelconque
        /// </summary>
        /// <param name="filename">nom du fichier ou l'image va être enregistée</param>
        /// <param name="angle">Angle choisit pour la rotation</param>
        public void Rotation2(string filename, int angle)
        {
            double angle2 = Math.PI * angle / 180;

            int nouvellehauteur = Math.Abs(Convert.ToInt32(Math.Cos(angle2) * hauteur)) + Math.Abs(Convert.ToInt32(Math.Sin(angle2) * largeur));
            int nouvellelargeur = Math.Abs(Convert.ToInt32(Math.Sin(angle2) * hauteur)) + Math.Abs(Convert.ToInt32(Math.Cos(angle2) * largeur));

            double milieuhauteur = nouvellehauteur / 2;
            double milieulargeur = nouvellelargeur / 2;
            Pixel[,] imagenouvelle = new Pixel[nouvellehauteur, nouvellelargeur];
            for (int i = 0; i < nouvellehauteur; i++)
            {
                for (int j = 0; j < nouvellelargeur; j++)
                {
                    imagenouvelle[i, j] = new Pixel(0, 0, 0);

                }
            }
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    double x1 = milieuhauteur + Math.Cos(angle2) * (i - hauteur / 2) + Math.Sin(angle2) * (j - largeur / 2);
                    double y1 = milieulargeur + Math.Sin(angle2) * (i - hauteur / 2) - Math.Cos(angle2) * (j - largeur / 2);
                    if (x1 > 0 && y1 > 0 && x1 < nouvellehauteur - 1 && y1 < nouvellelargeur - 1) imagenouvelle[Convert.ToInt32(x1), Convert.ToInt32(y1)] = image[i, j];
                }
            }
        

            this.hauteur = nouvellehauteur;
            this.largeur = nouvellelargeur;
            this.image = imagenouvelle;    
            for (int i = 1; i < hauteur - 1; i++)
            {
                for (int j = 1; j < largeur - 1; j++)
                {
                    if (image[i, j].Bleu == 0 && image[i, j].Rouge == 0 && image[i, j].Vert == 0)
                    {
                        image[i, j] = image[i + 1, j];

                    }
                }
            }
            From_Image_To_File(filename);

        }


        #endregion

        #region TD4 : Matrices de convolution

        /// <summary>
        /// Méthode qui vérifie que l'entier peut être converti en byte et le converti
        /// </summary>
        /// <param name="valeur">valeur entiere a convertir </param>
        /// <param name="coef">division en fonction de la matrice de convolution utilisé</param>
        /// <returns>renvoie le byte associé </returns>
        public byte CalculByte(int valeur, int coef)
        {
            byte vb = 0;
            if (valeur / coef > 255)
            {
                vb = 255;
            }
            else if (valeur < 0)
            {
                vb = 0;
            }
            else
            {
                vb = Convert.ToByte(valeur / coef);
            }
            return vb;
        }


        /// <summary>
        /// Méthode qui applique une matrice de convolution circulaire sur l'image
        /// </summary>
        /// <param name="conv">matrice de convolution appliqué sur l'image</param>
        /// <param name="ligne">index ligne </param>
        /// <param name="colonne">index colonne</param>
        /// <param name="coef">coef pour le convertisseur en Byte</param>
        /// <returns></returns>
        public Pixel ConvoCirculaire(int[,] conv, int ligne, int colonne, int coef)
        {
            int demilongueur = conv.GetLength(0) / 2;
            int vv = 0;
            int vb = 0;
            int vr = 0;
            for (int i = 0; i < conv.GetLength(0); i++)
            {
                for (int j = 0; j < conv.GetLength(1); j++)
                {

                    int x = ligne - demilongueur + i;
                    int y = colonne - demilongueur + j;
                    if (x < 0) x = x + demilongueur;
                    if (x >= hauteur) x = x - demilongueur;
                    if (y >= largeur) y = y - demilongueur;
                    if (y < 0) y = y + demilongueur;
                    vb += image[x, y].Bleu * conv[i, j];
                    vr += image[x, y].Rouge * conv[i, j];
                    vv += image[x, y].Vert * conv[i, j];

                }
            }
            vv = CalculByte(vv, coef);
            vr = CalculByte(vr, coef);
            vb = CalculByte(vb, coef);
            Pixel val = new Pixel((byte)vr, (byte)vv, (byte)vb);
            return val;
        }


        /// <summary>
        /// Méthode qui applique un filtre de détection de contour sur l'image
        /// </summary>
        /// <param name="filename">nom du fichier ou l'image va être enregistée</param>
        public void DetectionDeContour(string filename)
        {
            int[,] matriceConv = { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } };
            Pixel[,] imagefinal = new Pixel[hauteur, largeur];
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    imagefinal[i, j] = ConvoCirculaire(matriceConv, i, j, 1);
                }
            }
            image = imagefinal;

            From_Image_To_File(filename);
        }


        /// <summary>
        /// Méthode qui applique un filtre de repoussage sur l'image
        /// </summary>
        /// <param name="filename">nom du fichier ou l'image va être enregistée</param>
        public void Repoussage(string filename)
        {
            int[,] matriceConv = { { -2, -1, 0 }, { -1, 1, 1 }, { 0, 1, 2 } };
            Pixel[,] imagefinal = new Pixel[hauteur, largeur];
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    imagefinal[i, j] = ConvoCirculaire(matriceConv, i, j, 1);
                }
            }
            image = imagefinal;

            From_Image_To_File(filename);
        }


        /// <summary>
        /// Méthode qui applique un filtre de floutage sur l'image
        /// </summary>
        /// <param name="filename">nom du fichier ou l'image va être enregistée</param>
        public void Flou(string filename)
        {
            int[,] matriceConv = { { 0, 0, 0, 0, 0 }, { 0, 1, 1, 1, 0 }, { 0, 1, 1, 1, 0 }, { 0, 1, 1, 1, 0 }, { 0, 0, 0, 0, 0 } };
            Pixel[,] imagefinal = new Pixel[hauteur, largeur];
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    imagefinal[i, j] = ConvoCirculaire(matriceConv, i, j, 9);
                }
            }
            image = imagefinal;

            From_Image_To_File(filename);
        }


        /// <summary>
        /// Méthode qui applique un filtre de renforcement des bords sur l'image
        /// </summary>
        /// <param name="filename">nom du fichier ou l'image va être enregistée</param>
        public void Renforcement(string filename)
        {
            int[,] matriceConv = { { 0, 0, 0 }, { -1, 1, 0 }, { 0, 0, 0 } };
            Pixel[,] imagefinal = new Pixel[hauteur, largeur];
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    imagefinal[i, j] = ConvoCirculaire(matriceConv, i, j, 1);
                }
            }
            image = imagefinal;

            From_Image_To_File(filename);
        }

        #endregion

        #region TD5

        #region Fractales

        /// <summary>
        /// Méthode qui créée une fractale de Mandel
        /// </summary>
        /// <param name="filename">nom du fichier ou l'image va être enregistée</param>
        /// <param name="hauteur">hauteur de la fractale crée</param>
        /// <param name="largeur">largeur de la fractale crée</param>
        public void FractaleMandel(string filename, int hauteur, int largeur, int VR,int VV,int VB,int coef)
        {
            Pixel[,] imagefinale = new Pixel[hauteur, largeur];
            double xmin = -2;
            double xmax = 0.5;
            double ymin = -1.25;
            double ymax = 1.25;
            for (int y = 0; y < hauteur; y++)
            {
                for (int x = 0; x < largeur; x++)
                {
                    double cx = (x * (xmax - xmin) / (largeur) + xmin);
                    double cy = (y * (ymin - ymax) / (hauteur) + ymax);
                    double xn = 0;
                    double yn = 0;
                    int n = 0;
                    while (xn * xn + yn * yn < 4 && n < coef)
                    {
                        double tmp_x = xn;
                        double tmp_y = yn;
                        xn = tmp_x * tmp_x - tmp_y * tmp_y + cx; //fait le carré sur le x et ajoute cx
                        yn = 2 * tmp_y * tmp_x + cy; // Remplace le calcul c^2+z
                        n = n + 1;
                    }
                    if (n ==coef)
                    {
                        imagefinale[y, x] = new Pixel(0, 0, 0);
                    }
                    else
                    {
                        //imagefinale[y,x] = new Pixel(255, 255, 255); // Noir et Blanc
                        imagefinale[y, x] = new Pixel(Convert.ToByte(VR * n % 256), Convert.ToByte(VV * n % 256), Convert.ToByte(VB * n % 256)); // Couleur
                    }
                }
            }
            this.image = imagefinale;
            From_Image_To_File(filename);
        }


        /// <summary>
        /// Méthode qui créée une fractale de Julia
        /// </summary>
        /// <param name="filename">nom du fichier ou l'image va être enregistée</param>
        /// <param name="hauteur">hauteur de la fractale créée</param>
        /// <param name="largeur">largeur de la fractale créée</param>
        /// <param name="cx">coefficient réel permettant de faire différent type de fractale julia</param>
        /// <param name="cy">coefficient imagainre permettant de faire différent type de fractale Julia</param>
        public void FractaleJulia(string filename, int hauteur, int largeur, double cx, double cy,int VR,int VV,int VB, int coef)
        {
            Pixel[,] imagefinale = new Pixel[largeur, hauteur];
            double xmin = -1.25;
            double xmax = 1.25;
            double ymin = -1.25;
            double ymax = 1.25;
            for (int y = 0; y < hauteur; y++)
            {
                for (int x = 0; x < largeur; x++)
                {
                    double xn = (x * (xmax - xmin) / (largeur) + xmin);
                    double yn = (y * (ymin - ymax) / (hauteur) + ymax);

                    int n = 0;
                    while (xn * xn + yn * yn < 4 && n < coef) //50
                    {
                        double tmp_x = xn;
                        double tmp_y = yn;
                        xn = tmp_x * tmp_x - tmp_y * tmp_y + cx; //fait le carré sur le x et ajoute cx
                        yn = 2 * tmp_y * tmp_x + cy; // Remplace le calcul c^2+z
                        n = n + 1;
                    }
                    if (n == coef)

                    {
                        imagefinale[y, x] = new Pixel(0, 0, 0);
                    }
                    else
                    {
                        //imagefinale[y,x] = new Pixel(255, 255, 255); // Noir et Blanc
                        imagefinale[y, x] = new Pixel(Convert.ToByte((VR * n) % 256), Convert.ToByte((VV * n) % 256), Convert.ToByte((VB * n) % 256)); // Couleur10 0 5
                    }
                }
            }
            this.image = imagefinale;
            From_Image_To_File(filename);
        }

        #endregion

        #region Histogramme

        /// <summary>
        /// Méthode qui créée l'histogramme de l'image passée en paramètre
        /// </summary>
        /// <param name="filename">nom du fichier ou l'image va être enregistée</param>
        public void Histogramme(string filename)
        {
            Pixel[,] imagefinale = new Pixel[256, 256];
            double[] bleu = new double[256];
            double[] rouge = new double[256];
            double[] vert = new double[256];
            double maximum = 0;
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    bleu[image[i, j].Bleu]++;
                    rouge[image[i, j].Rouge]++;
                    vert[image[i, j].Vert]++;

                }
            }
            for (int i = 0; i < 256; i++)
            {
                if (maximum < bleu[i]) maximum = bleu[i];
                if (maximum < rouge[i]) maximum = rouge[i];
                if (maximum < vert[i]) maximum = vert[i];
            }

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    byte vertfinal = 0;
                    byte bleufinal = 0;
                    byte rougefinal = 0;
                    double valeurbleu = 256 * bleu[j] / (maximum); //idée de diviser par (hauteur*largeur

                    double valeurrouge = 256 * rouge[j] / (maximum);
                    double valeurvert = 256 * vert[j] / (maximum);
                    // Console.WriteLine(valeurvert);
                    if (i < valeurbleu) bleufinal = 255; // et de regarder i/256 (double attention)
                    if (i < valeurvert) vertfinal = 255;
                    if (i < valeurrouge) rougefinal = 255;
                    imagefinale[255 - i, j] = new Pixel(rougefinal, vertfinal, bleufinal);

                }
            }


            this.image = imagefinale;
            this.largeur = 256;
            this.hauteur = 256;
            From_Image_To_File(filename);

        }

        #endregion

        #region ImageCachée

        /// <summary>
        /// Méthode qui convertit des bytes en tableau d'entier
        /// </summary>
        /// <param name="i">index i</param>
        /// <param name="j">index j</param>
        /// <param name="couleur">couleur qui peut etre bleu vert ou rouge</param>
        /// <param name="image2">image a cachée</param>
        /// <returns>tableau correspond au byte passe en entrée</returns>
        public int[] ConvertByteToTab(int i, int j, string couleur, Pixel[,] image2)
        {
            int[] tab = new int[8];
            int diviseur = 128;
            int reste = 0;
            if (couleur == "rouge") reste = image2[i, j].Rouge;
            if (couleur == "bleu") reste = image2[i, j].Bleu;
            if (couleur == "vert") reste = image2[i, j].Vert;
            for (int k = 0; k < 8; k++)
            {
                tab[k] = reste / diviseur;
                reste = reste % diviseur;
                diviseur = diviseur / 2;
            }

            return tab;
        }


        /// <summary>
        /// Méthode qui convertit un tableau d'entier en byte
        /// </summary>
        /// <param name="tab">tableau que le convertir en byte</param>
        /// <returns>un byte en fonction du tableu passé en entrée</returns>
        public static byte ConvertTabToByte(int[] tab)
        {
            int somme = 0;
            int multiplicateur = 128;
            for (int i = 0; i < 8; i++)
            {
                somme = somme + tab[i] * multiplicateur;
                multiplicateur = multiplicateur / 2;
            }


            byte somme2 = Convert.ToByte(somme);
            return somme2;
        }


        /// <summary>
        /// Méthode qui cache un image dans une autre
        /// </summary>
        /// <param name="filename">nom du fichier ou l'image va être enregistée</param>
        /// <param name="image2">image à cacher dans l'image passé en paramètre</param>
        public void CacherImage(string filename, MyImage image2)
        {
            Pixel[,] Imagefinal = new Pixel[hauteur, largeur];
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {

                    int[] tabR1 = ConvertByteToTab(i, j, "rouge", image);
                    int[] tabB1 = ConvertByteToTab(i, j, "bleu", image);
                    int[] tabV1 = ConvertByteToTab(i, j, "vert", image);
                    int[] tabR2 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    int[] tabV2 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    int[] tabB2 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    if (i < image2.hauteur && j < image2.largeur)
                    {
                        tabR2 = ConvertByteToTab(i, j, "rouge", image2.image);
                        tabB2 = ConvertByteToTab(i, j, "bleu", image2.image);
                        tabV2 = ConvertByteToTab(i, j, "vert", image2.image);
                    }
                    int[] tabR = new int[8];
                    int[] tabV = new int[8];
                    int[] tabB = new int[8];
                    for (int k = 0; k < 4; k++)
                    {
                        tabB[k] = tabB1[k];
                        tabB[k + 4] = tabB2[k];
                        tabR[k] = tabR1[k];
                        tabR[k + 4] = tabR2[k];
                        tabV[k] = tabV1[k];
                        tabV[k + 4] = tabV2[k];
                    }
                    Imagefinal[i, j] = new Pixel(ConvertTabToByte(tabR), ConvertTabToByte(tabV), ConvertTabToByte(tabB));


                }
            }
            this.image = Imagefinal;
            From_Image_To_File(filename);
        }


        /// <summary>
        /// Méthode qui retrouve l'image cachée dans une autre
        /// </summary>
        /// <param name="filename1">nom du fichier ou l'image de fond va être enregistée</param>
        /// <param name="filename2">nom du fichier ou l'image caché  va être enregistée</param>
        public void RetrouverImage(string filename1, string filename2)
        {
            Pixel[,] imagedevant = new Pixel[hauteur, largeur];
            Pixel[,] imagederriere = new Pixel[hauteur, largeur];
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    int[] tabR1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    int[] tabV1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    int[] tabB1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    int[] tabR2 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    int[] tabV2 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    int[] tabB2 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    int[] tabR = ConvertByteToTab(i, j, "rouge", image);
                    int[] tabB = ConvertByteToTab(i, j, "bleu", image);
                    int[] tabV = ConvertByteToTab(i, j, "vert", image);
                    for (int k = 0; k < 4; k++)
                    {
                        tabR1[k] = tabR[k];
                        tabR2[k] = tabR[k + 4];
                        tabV1[k] = tabV[k];
                        tabV2[k] = tabV[k + 4];
                        tabB1[k] = tabB[k];
                        tabB2[k] = tabB[k + 4];
                    }

                    imagedevant[i, j] = new Pixel(ConvertTabToByte(tabR1), ConvertTabToByte(tabV1), ConvertTabToByte(tabB1));
                    imagederriere[i, j] = new Pixel(ConvertTabToByte(tabR2), ConvertTabToByte(tabV2), ConvertTabToByte(tabB2));

                }
            }
            this.image = imagedevant;
            From_Image_To_File(filename1);
            this.image = imagederriere;
            From_Image_To_File(filename2);



        }

        #endregion

        #endregion

        #region Innovation
        /// <summary>
        /// Cette innovation rogne un image grace au coordonnées de début et de fin 
        /// </summary>
        /// <param name="filename">Fichier ou l'image sera enregistre</param>
        /// <param name="idebut">coordonée i début</param>
        /// <param name="ifin">coordonnée i fin</param>
        /// <param name="jdebut">coordonnée j debut</param>
        /// <param name="jfin">coordonnée j fin</param>
        public void Innovation(string filename,int idebut, int ifin,int jdebut, int  jfin)
        {
            int newlargeur = jfin - jdebut;
            int newhauteur = ifin - idebut;
            Pixel[,] matricefin = new Pixel[newhauteur, newlargeur];
            int indexi=0;
            int indexj=0;
            for(int i=0; i<newhauteur;i++)
            {
                for(int j=0;j<newlargeur;j++)
                {
                    matricefin[i, j] = image[i+idebut, j+jdebut];
                    indexj++;
                }
                indexi++;
            }


            this.largeur = newlargeur;
            this.hauteur = newhauteur;
            this.image = matricefin;
            From_Image_To_File(filename);
        }

        public void InnovationRond(string filename,int rayon,int centrex,int centrey)
        {
            Pixel[,] matricefin = new Pixel[this.hauteur, this.largeur];
            for(int i=0;i<hauteur;i++)
            {
                for(int j=0;j<largeur;j++)
                {
                         matricefin[i, j] = image[i, j];
                }
            }
            for(int i=0;i<hauteur;i++)
            {
                for(int j=0;j<largeur;j++)
                {
                    if(Math.Sqrt((i-centrey)*(i-centrey)+(j-centrex)*(j-centrex))>rayon)
                    {
                        matricefin[i, j] = new Pixel(0,0,0);
                    }

                }
            }
            
                this.image = matricefin;
            From_Image_To_File(filename);
        }


        #endregion

        #endregion
    }
}
