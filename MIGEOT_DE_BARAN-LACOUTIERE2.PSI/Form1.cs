using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MIGEOT_DE_BARAN_LACOUTIERE2.PSI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string NomImageUtilise;
        string phrase;

        #region ClickMenu

        #region ClickModifiationImage

        /// <summary>
        ///  Affiche l'interface de modification d'image ainsi que l'image coco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cocoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox1.Image = Image.FromFile("coco.bmp");
            MyImage image = new MyImage("coco.bmp");
            image.Aggrandir(1, "image.bmp");
            Titre.Text = "Vous avez décidé de modifier coco";
            GroupeTraitementImage.Visible = true;
            groupBoxFractale.Visible = false;
            groupBoxInnovation.Visible = false;
            groupBoxQRCode2.Visible = false;
            this.NomImageUtilise = "coco.bmp";
        }

        /// <summary>
        ///  Affiche l'interface de modification d'image ainsi que l'image lac
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lacToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox1.Image = Image.FromFile("lac.bmp");
            MyImage image = new MyImage("lac.bmp");
            image.Aggrandir(1, "image.bmp");
            Titre.Text = "Vous avez décidé de modifier lac";
            GroupeTraitementImage.Visible = true;
            groupBoxFractale.Visible = false;
            groupBoxInnovation.Visible = false;
            groupBoxQRCode2.Visible = false;
            this.NomImageUtilise = "lac.bmp";
        }

        /// <summary>
        ///  Affiche l'interface de modification d'image ainsi que l'image lena
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lenaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox1.Image = Image.FromFile("lena.bmp");
            MyImage image = new MyImage("lena.bmp");
            image.Aggrandir(1, "image.bmp");
            Titre.Text = "Vous avez décidé de modifier lena";
            GroupeTraitementImage.Visible = true;
            groupBoxFractale.Visible = false;
            groupBoxInnovation.Visible = false;
            groupBoxQRCode2.Visible = false;
            this.NomImageUtilise = "lena.bmp";
        }

        /// <summary>
        ///  Affiche l'interface de modification d'image ainsi que l'image planete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void planeteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox1.Image = Image.FromFile("planete.bmp");
            MyImage image = new MyImage("planete.bmp");
            image.Aggrandir(1, "image.bmp");
            Titre.Text = "Vous avez décidé de modifier planete";
            GroupeTraitementImage.Visible = true;
            groupBoxFractale.Visible = false;
            groupBoxQRCode2.Visible = false;
            groupBoxInnovation.Visible = false;
            this.NomImageUtilise = "planete.bmp";
        }


        /// <summary>
        ///  Affiche l'interface de modification d'image ainsi que l'image papillon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void papillonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox1.Image = Image.FromFile("papillon.bmp");
            MyImage image = new MyImage("papillon.bmp");
            image.Aggrandir(1, "image.bmp");
            Titre.Text = "Vous avez décidé de modifier papillon";
            GroupeTraitementImage.Visible = true;
            groupBoxFractale.Visible = false;
            groupBoxQRCode2.Visible = false;
            groupBoxInnovation.Visible = false;
            this.NomImageUtilise = "papillon.bmp";
        }

        /// <summary>
        ///  Affiche l'interface de modification d'image ainsi que l'image éléphant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void elephantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox1.Image = Image.FromFile("elephant.bmp");
            MyImage image = new MyImage("elephant.bmp");
            image.Aggrandir(1, "image.bmp");
            Titre.Text = "Vous avez décidé de modifier elephant";
            GroupeTraitementImage.Visible = true;
            groupBoxFractale.Visible = false;
            groupBoxQRCode2.Visible = false;
            groupBoxInnovation.Visible = false;
            this.NomImageUtilise = "elephant.bmp";
        }


        /// <summary>
        ///  Affiche l'interface de modification d'image ainsi que l'image couleur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void couleurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox1.Image = Image.FromFile("couleur.bmp");
            MyImage image = new MyImage("couleur.bmp");
            image.Aggrandir(1, "image.bmp");
            Titre.Text = "Vous avez décidé de modifier couleur";
            GroupeTraitementImage.Visible = true;
            groupBoxFractale.Visible = false;
            groupBoxQRCode2.Visible = false;
            groupBoxInnovation.Visible = false;
            this.NomImageUtilise = "couleur.bmp";
        }

        /// <summary>
        ///  Affiche l'interface de modification d'image ainsi que l'image couché de soleil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void coucherSoleilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox1.Image = Image.FromFile("CoucherSoleil.bmp");
            MyImage image = new MyImage("CoucherSoleil.bmp");
            image.Aggrandir(1, "image.bmp");
            Titre.Text = "Vous avez décidé de modifier coucher de soleil";
            GroupeTraitementImage.Visible = true;
            groupBoxFractale.Visible = false;
            groupBoxQRCode2.Visible = false;
            groupBoxInnovation.Visible = false;
            this.NomImageUtilise = "CoucherSoleil.bmp";
        }

        /// <summary>
        /// Affiche l'interface de modification d'image ainsi que l'image vague
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vaguesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox1.Image = Image.FromFile("Vagues.bmp");
            MyImage image = new MyImage("Vagues.bmp");
            image.Aggrandir(1, "image.bmp");
            Titre.Text = "Vous avez décidé de modifier Vagues";
            GroupeTraitementImage.Visible = true;
            groupBoxFractale.Visible = false;
            groupBoxInnovation.Visible = false;
            groupBoxQRCode2.Visible = false;
            this.NomImageUtilise = "Vagues.bmp";
        }



        #endregion


        #region ClickFractale

        /// <summary>
        /// Affiche l'interfce MandeBrot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fractaleDeMandelBrotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Titre.Text = "Vous avez décidé de créer des fractales de Mandelbrot";
            pictureBox1.Image = null;
            pictureBox1.Image =  Image.FromFile("MandelBrot.bmp");
            GroupeTraitementImage.Visible = false;
            groupBoxFractale.Visible = true;
            buttonValiderMandelBrot.Visible = true;
            groupBoxQRCode2.Visible = false;
            groupBoxInnovation.Visible = false;
            BoutonJuliaOff();
        }

        /// <summary>
        /// Affiche l'interface Julia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void juliaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox1.Image = Image.FromFile("Julia.bmp");
            GroupeTraitementImage.Visible = false;
            groupBoxFractale.Visible = true;
            Titre.Text = "Vous avez décidé de créer des fractales de Julia";
            buttonValiderMandelBrot.Visible = false;
            groupBoxQRCode2.Visible = false;
            groupBoxInnovation.Visible = false;
            BoutonJuliaOn();
        }







        #endregion


        #region ClickQRCode
        /// <summary>
        /// Affiche l'interface QRCode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void créationDunQRCodeToolStripMenuItem_Click(object sender, EventArgs e)
            
        {
            Titre.Text = "Vous avez décidé de créer des QRCodes";
            pictureBox1.Image = null;
            groupBoxFractale.Visible = false;
            groupBoxQRCode2.Visible = true;
            GroupeTraitementImage.Visible = false;
            groupBoxInnovation.Visible = false;
        }

        #endregion


        #endregion

        #region FonctionUtile

        /// <summary>
        /// permet la fermerture du fichier et essaye de supprimer tout les QRCodes crée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fermetureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            string path = "./QRCodeFichier";
            string[] filenames = Directory.GetFiles(path, "*.bmp", SearchOption.TopDirectoryOnly);
            foreach (string fName in filenames)
            {
                try
                {
                    File.Delete(fName);
                }
                catch(Exception)
                {

                }
            }
        }

        /// <summary>
        /// Affichae les boutons Poiur la modification de Julia
        /// </summary>
        private void BoutonJuliaOn()
        {
            buttonValiderJulia1.Visible = true;
            buttonValiderJulia2.Visible = true;
            buttonValiderJulia3.Visible = true;
            buttonValiderJulia4.Visible = true;
            buttonValiderJulia5.Visible = true;
            pictureBoxJulia1.Visible = true;
            pictureBoxJulia2.Visible = true;
            pictureBoxJulia3.Visible = true;
            pictureBoxJulia4.Visible = true;
            pictureBoxJulia5.Visible = true;
        }

        /// <summary>
        /// Cache les boutons pour la modification de Julia
        /// </summary>
        private void BoutonJuliaOff()
        {
            buttonValiderJulia1.Visible =false;
            buttonValiderJulia2.Visible = false;
            buttonValiderJulia3.Visible = false;
            buttonValiderJulia4.Visible = false;
            buttonValiderJulia5.Visible = false;
            pictureBoxJulia1.Visible = false;
            pictureBoxJulia2.Visible = false;
            pictureBoxJulia3.Visible = false;
            pictureBoxJulia4.Visible = false;
            pictureBoxJulia5.Visible = false;
        }

        #endregion


        /// <summary>
        ///  applique la fonction de rétrecir  en fonction du coef choisit par l'utilisateur et l'affiche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region BoutonModificationImage
        private void Réduire_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            MyImage image = new MyImage("image.bmp");
            int coef = trackbarAggrandirRetrecir.Value;
            image.Retrecir(coef, "image.bmp");
            pictureBox1.Image = Image.FromFile("image.bmp");     
        }



        /// <summary>
        /// applique la fonction de aggrandir en fonction du coef choisit par l'utilisateur et l'affiche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAggrandir_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            MyImage image = new MyImage("image.bmp");
            int coef = trackbarAggrandirRetrecir.Value;
            image.Aggrandir(coef, "image.bmp");
            pictureBox1.Image = Image.FromFile("image.bmp");       
        }

        /// <summary>
        /// applique la fonction de Gris et l'affiche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGris_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            MyImage image = new MyImage("image.bmp");
            image.Gris("image.bmp");
            pictureBox1.Image = Image.FromFile("image.bmp");      

        }

        /// <summary>
        /// applique la fonction de nori et blanc et l'affiche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNoirEtBlanc_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            MyImage image = new MyImage("image.bmp");
            image.Noir_Et_Blanc("image.bmp");
            pictureBox1.Image = Image.FromFile("image.bmp");
        }

        /// <summary>
        /// Réinitialise l'image en train d'être modifier par celle de base
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e) //buttonreinialiser
        {
            pictureBox1.Image = null;
           
            
                pictureBox1.Image = Image.FromFile(NomImageUtilise);
                MyImage image = new MyImage(NomImageUtilise);
                image.Aggrandir(1, "image.bmp");
            
        }

        /// <summary>
        /// Fait un rotation choisit par l'utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRotation_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            MyImage image = new MyImage("image.bmp");
            int coef = trackBarRotation.Value;
            image.Rotation2("image.bmp",coef);
            pictureBox1.Image = Image.FromFile("image.bmp");
        }

        /// <summary>
        /// Affiche l'image en miroir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMiroir_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            MyImage image = new MyImage("image.bmp");
            image.Effet_Miroir("image.bmp");
            pictureBox1.Image = Image.FromFile("image.bmp");
        }

        /// <summary>
        /// Affiche l'histogramme de l'image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHistogramme_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            MyImage image = new MyImage("image.bmp");
            image.Histogramme("image.bmp");
            pictureBox1.Image = Image.FromFile("image.bmp");
        }

        /// <summary>
        /// applique la fonction détection de contour et l'affiche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonContour_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            MyImage image = new MyImage("image.bmp");
            image.DetectionDeContour("image.bmp");
            pictureBox1.Image = Image.FromFile("image.bmp");
        }

        /// <summary>
        /// applique la fonction de renforcement et l'affiche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRenforcement_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            MyImage image = new MyImage("image.bmp");
            image.Renforcement("image.bmp");
            pictureBox1.Image = Image.FromFile("image.bmp");
        }

        /// <summary>
        /// applique la fonction de flou et l'affiche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFlou_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            MyImage image = new MyImage("image.bmp");
            image.Flou("image.bmp");
            pictureBox1.Image = Image.FromFile("image.bmp");
        }

        /// <summary>
        /// Applique la fonction de repoussage et l'affiche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRepoussage_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            MyImage image = new MyImage("image.bmp");
            image.Repoussage("image.bmp");
            pictureBox1.Image = Image.FromFile("image.bmp");
        }

        /// <summary>
        /// Cache une image dans l'image actuelle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCacherImage_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            MessageBox.Show("Nous avons caché une image, allez vous réussir à la retrouver");
            MyImage image = new MyImage("image.bmp");
            MyImage image2 = new MyImage("coco.bmp");
            image.CacherImage("image.bmp",image2);
            pictureBox1.Image = Image.FromFile("image.bmp");
            buttonReveler.Visible = true;
        }

        /// <summary>
        /// Revele l'image caché
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReveler_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            MyImage image = new MyImage("image.bmp");
            image.RetrouverImage("image.bmp", "image2.bmp");
            pictureBox1.Image = Image.FromFile("image2.bmp");
            buttonReveler.Visible = false;

        }



     
        #endregion

        #region FractaleClick
        /// <summary>
        /// Créer et affichage la fractale de mandelbrot en fonction des couleurs choisi par l'utilisateur sur les trackbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonValiderMandelBrot_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            int valeurRouge = trackBarRouge.Value;
            int valeurBleu = trackBarBleu.Value;
            int valeurVert = trackBarVert.Value;
            MyImage image = new MyImage(800, 800);
            image.FractaleMandel("image.bmp", 800, 800, valeurRouge, valeurVert, valeurBleu,50);
            pictureBox1.Image = Image.FromFile("image.bmp");
        }

        /// <summary>
        /// Créer et affichage la fractale de mandelbrot en fonction des couleurs choisi par l'utilisateur sur les trackbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonValiderJulia_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            int valeurRouge = trackBarRouge.Value;
            int valeurBleu = trackBarBleu.Value;
            int valeurVert = trackBarVert.Value;
            MyImage image = new MyImage(800, 800);
            image.FractaleJulia("image.bmp", 800, 800,0.285,0.01, valeurRouge, valeurVert, valeurBleu,200);
            pictureBox1.Image = Image.FromFile("image.bmp");
        }

        private void buttonValiderJulia2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            int valeurRouge = trackBarRouge.Value;
            int valeurBleu = trackBarBleu.Value;
            int valeurVert = trackBarVert.Value;
            MyImage image = new MyImage(800, 800);
            image.FractaleJulia("image.bmp", 800, 800, -1.417022285618, 0.099534, valeurRouge, valeurVert, valeurBleu,50);
            pictureBox1.Image = Image.FromFile("image.bmp");
        }

        private void buttonValiderJulia3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            int valeurRouge = trackBarRouge.Value;
            int valeurBleu = trackBarBleu.Value;
            int valeurVert = trackBarVert.Value;
            MyImage image = new MyImage(800, 800);
            image.FractaleJulia("image.bmp", 800, 800, -0.4, 0.6, valeurRouge, valeurVert, valeurBleu,100);
            pictureBox1.Image = Image.FromFile("image.bmp");
        }

        private void buttonValiderJulia4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            int valeurRouge = trackBarRouge.Value;
            int valeurBleu = trackBarBleu.Value;
            int valeurVert = trackBarVert.Value;
            MyImage image = new MyImage(800, 800);
            image.FractaleJulia("image.bmp", 800, 800, -0.8 , 0.156, valeurRouge, valeurVert, valeurBleu,200);
            pictureBox1.Image = Image.FromFile("image.bmp");
        }

        private void buttonValiderJulia5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            int valeurRouge = trackBarRouge.Value;
            int valeurBleu = trackBarBleu.Value;
            int valeurVert = trackBarVert.Value;
            MyImage image = new MyImage(800, 800);
            image.FractaleJulia("image.bmp", 800, 800, -0.038088, 0.9754633, valeurRouge, valeurVert, valeurBleu,50);
            pictureBox1.Image = Image.FromFile("image.bmp");
        }


        #endregion

        /// <summary>
        /// Créer et affiche le QRCode avec le texte choisit par l'utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonValiderQRCode_Click(object sender, EventArgs e)
        {

            pictureBox1.Image = null;
            phrase = textBox1.Text;
            
            Random aleatoire = new Random();
            int entier = aleatoire.Next(1,100);
            QRCode test = new QRCode(phrase);
            test.AffichageQRCode("./QRCodeFichier/"+entier + ".bmp");
            try
          {
                pictureBox1.Image = Image.FromFile("./QRCodeFichier/"+entier + ".bmp");
           }
            catch (Exception)
            {
                MessageBox.Show("Trop de caractères");
            }
        }

    
        /// <summary>
        /// Affiche l'interface innovation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            groupBoxInnovation.Visible = true;
            pictureBox1.Image = null;
            pictureBox1.Image = Image.FromFile(NomImageUtilise);
            MyImage image = new MyImage(NomImageUtilise);
            Titre.Text = "Vous avez décidez de modifier avec l'innovation";
            GroupeTraitementImage.Visible = false;
            groupBoxFractale.Visible = false;
            groupBoxQRCode2.Visible = false;
            label18.Text = "La taille de l'image est " + image.Largeur + " en largeur et de " + image.Hauteur + " en hauteur";
          
        }
        /// <summary>
        /// Créer et affiche l'image rognée (innovation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInnovation_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            MyImage image = new MyImage("image.bmp");

            try
            {
                image.Innovation("image.bmp", Convert.ToInt32(textBoxCordYdebut.Text), Convert.ToInt32(textBoxCordyFin.Text), Convert.ToInt32(textBoxXdebut.Text), Convert.ToInt32(textBoxCordXfin.Text));
            }
            catch(Exception)
            {
                MessageBox.Show("Coordonnées non valide");
            }
            pictureBox1.Image = Image.FromFile("image.bmp");
        }

        /// <summary>
        /// Réinitailse l'image  que l'utilisateur modifiait avec celle de base
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox1.Image = Image.FromFile(NomImageUtilise);
            MyImage image = new MyImage(NomImageUtilise);
            image.Aggrandir(1, "image.bmp");
        }

        /// <summary>
        /// Revient sur la page de modification d'image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRetour_Click(object sender, EventArgs e)
        {
            groupBoxInnovation.Visible = false;
            GroupeTraitementImage.Visible = true;
            pictureBox1.Image = null;
            pictureBox1.Image = Image.FromFile(NomImageUtilise);
            Titre.Text = "Vous avez décidez de modifier "+NomImageUtilise;


        }

        /// <summary>
        ///Affiche l'innovation avec les paramètre choisi par l'utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInnovationRond_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            MyImage image = new MyImage("image.bmp");
            try
            {
                image.InnovationRond("image.bmp", Convert.ToInt32(textBoxRayon.Text), Convert.ToInt32(textBoxCentrex.Text), Convert.ToInt32(textBoxCentrey.Text)); 
            }
            catch (Exception)
            {
                MessageBox.Show("Coordonnées non valide");
            }
            pictureBox1.Image = Image.FromFile("image.bmp");
        }

        private void buttonDécoder_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
           // MyImage image = new MyImage("image.bmp");
            QRCode qrcode = new QRCode(phrase);
         
            string coucou = qrcode.Decodage();
            MessageBox.Show(coucou);
        }

        
    }
}
