using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //muuttuja edustakoon yksinkertaista tilakonetta
        enum MusicPlays
        {
            Stop,
            Play,
            Pause
        }
        MusicPlays musicplays;
        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }
        private void IniMyStuff()
        {
            //tänne kootaan ohjelman yhteydessä tarvitsevat alustukset
            musicplays = MusicPlays.Stop;
        }
        private void SetButtons()
        {
            switch (musicplays)
            {
                case MusicPlays.Stop:
                    btnPlay.IsEnabled = true;
                    btnStop.IsEnabled = false;
                    btnPause.IsEnabled = false;
                    break;
                case MusicPlays.Play:
                    btnPlay.IsEnabled = false;
                    btnStop.IsEnabled = true;
                    btnPause.IsEnabled = true;
                    break;
                case MusicPlays.Pause:
                    btnPlay.IsEnabled = true;
                    btnStop.IsEnabled = false;
                    btnPause.IsEnabled = false;
                    break;
                default:
                    break;
            }

        }
        #endregion
        #region EVENTHANDLER

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            //tämä metodi = tapahtuman käsittelijä, joka suoritetaan joka kerta kun play nappulaa klikataan
            try
            {
                //tutkitaan onko annettu oikea tiedoston nimi
                if(txtFilename.Text.Length > 0 && System.IO.File.Exists(txtFilename.Text))
                {
                    //nyt rokit soimaan
                    // loaded behavior täytyyy olla manual jotta voidaan kontrolloida media play / stop metodeja
                    if (musicplays == MusicPlays.Stop)
                    {
                        medElement.Source = new Uri(txtFilename.Text);
                    }
                    medElement.Source = new Uri(txtFilename.Text);
                    medElement.Play();
                    musicplays = MusicPlays.Play;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            medElement.Stop();
            musicplays = MusicPlays.Stop;
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            medElement.Pause();
            musicplays = MusicPlays.Pause;
        }
    }
}
