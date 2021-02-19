using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class MusicPlayer : Form
    {
        String[] paths, files;
        bool shuffleTracks = false, repeatTracks = false;

        public MusicPlayer()
        {
            InitializeComponent();
        }

        private void btnSelectSongs_Click(object sender, EventArgs e)
        {
            //Select Songs
            var ofd = new OpenFileDialog();
            ofd.Multiselect = true; //Select Multiple Files
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                files = ofd.SafeFileNames; //Save the names of the track in files array
                paths = ofd.FileNames; //Save the paths of the tracks in path array
                //Display the music titles in the listbox
                for(var i = 0; i < files.Length; i++)
                {
                    listBoxSongs.Items.Add(files[i]); //Display songs into the list.
                }
            }
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            shuffleTracks = true;
        }

        private void btnRepeat_Click(object sender, EventArgs e)
        {
            repeatTracks = true;
        }

        private void listBoxSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Play Music
            axWindowsMediaPlayerMusic.URL = paths[listBoxSongs.SelectedIndex];
            axWindowsMediaPlayerMusic.settings.setMode("shuffle", shuffleTracks);
            axWindowsMediaPlayerMusic.settings.setMode("loop", repeatTracks);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            //Click to close the application
            this.Close();
        }
    }
}
