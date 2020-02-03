using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.IO;

using NAudio.Midi;
using NAudio.Utils;

using System.Media;

namespace WindowsFormsApplication1
{
 
    // This is the enumeration that determines which 
    // track we are playing. 
    public enum MidiSelection
    {
        SOURCE          = 0,
        RESULT          = 1,
        HARMONY_ONLY    = 2
    }

   
    class MidiControl
    {

        // This uses the system MediaPlayer to play MIDI files.
        // This means that we *must* store data on disk.
        private MediaPlayer.MediaPlayer m_mediaPlayer;
        
        // Holds an array of filename strings. These represent
        // the location on-disk of the MIDI data, whether
        // permanent or in a temp file...
        private String[] fileNames;

        // Holds an array of MidiEventCollection objects.
        // This is what is actually storing MIDI data for us. 
        private MidiEventCollection[] midiData;


        // 
        public MidiControl()
        {
            initializeMidiStorage();
        }

        private void initializeMidiStorage()
        {
            // Any initialization will be done here.

            // Initialize arrays. 
            midiData = new MidiEventCollection[3];
            fileNames = new string[3];

            // Initialize Media Player
            m_mediaPlayer = new MediaPlayer.MediaPlayer();
        }

        public bool play(MidiSelection e)
        {
            if (m_mediaPlayer != null)
            {
                // Setup and load the file into the media player
                m_mediaPlayer.FileName = fileNames[(int)e];
                m_mediaPlayer.Open(fileNames[(int)e]);

                // Play it
                m_mediaPlayer.Play();
            }
            return true;
        }

        public bool open(MidiSelection e, string fileName)
        {
            // Should we verify if something is already open?

            // Load the midi file. 
            MidiFile m = new MidiFile(fileName, true);

            if (m != null)
            {
                // Set the filename and Midi slots...
                midiData[(int) e] = m.Events;
                fileNames[(int) e] = fileName;
                return true;
            }

            return false;
        }

        public bool save(MidiSelection e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
            sfd.Filter = "MIDI Files|*.mid";
            sfd.FilterIndex = 1;
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.Copy(fileNames[(int)e], sfd.FileName, true);       
            }

            return true;
        }


        public MidiEventCollection getMidiData(MidiSelection e)
        {
            // Return the MidiEventCollection at position e
            return midiData[(int)e];
        }

        public void setMidiData(MidiEventCollection m, MidiSelection e)
        {
            // Get a temporary filename for the MIDI file.
            // We do this because we don't want to save to the
            // user's folders unless they request it. 
            String temp = getTemporaryMidiFileName();

            if (e == MidiSelection.HARMONY_ONLY)
            {
                // Store the incoming MIDI data, but strip out
                // track 0
                m.RemoveTrack(0);
                midiData[(int)e] = m;
            }
            else
            {
                // Store the incoming MIDI data
                midiData[(int)e] = m;
            }

           
            
            // Export the temp copy...
            // NOTE: this is how we save MIDI files...
            m.PrepareForExport();
            MidiFile.Export(temp, m);

            // And update the filename so we remember where the
            // MIDI temp file is...
            fileNames[(int) e] = temp;

            return;
           
        }

       

        private String getTemporaryMidiFileName()
        {
            // 1. Get the temp path
            // 2. Use a GUID for the filename
            // 3. Append the ".mid" extension and return. 
            return System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".mid";
        }

    }
}
