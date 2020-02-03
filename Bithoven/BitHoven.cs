using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Media;

using NAudio.Midi;
using NAudio.Utils;

// Include COM reference to Windows Media Player (msdxm.tlb)

namespace WindowsFormsApplication1
{
    public partial class BitHoven : Form
    {

        private MidiControl m_midiControl;
        private MidiSelection selIndex;

        public BitHoven()
        {
            InitializeComponent();
            m_midiControl = new MidiControl();
            selIndex = MidiSelection.SOURCE ;
            Harmonizer h = new Harmonizer();
            System.Console.WriteLine(h.testAngle());
        }

      
        private void makeProgress(int increment)
        {
            prgProcessing.Value += increment;
        }

        private int getTranspositionForKey(int key)
        {
            switch (key)
            {
                case 0:
                    return 0;
                case 1: // G Major
                    return -7;
                case 2: // D Major
                    return -2;
                case 3: // A Major
                    return -9;
                case 4: // E Major
                    return -4;
                case 5: // B Major
                    return -11;
                case 6: // F#
                    return -6;
                case 7: // C#
                    return -1;
                case -1: // F
                    return -5;
                case -2: // Bb
                    return -10;
                case -3: // Eb
                    return -3;
                case -4: // Ab
                    return -8;
                case -5: // Db
                    return -1;
                case -6: // Gb
                    return -6;
                case -7: // Cb
                    return -11;
            }
            return 0;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
           onStartClick();
        }

        private void openMenu_Click(object sender, EventArgs e)
        {
            onOpenMenuClick();
        }

        private void selOriginal_CheckedChanged(object sender, EventArgs e)
        {
            selIndex = MidiSelection.SOURCE;
        }

        private void selFull_CheckedChanged(object sender, EventArgs e)
        {
            selIndex = MidiSelection.RESULT;
        }

        private void selHarmony_CheckedChanged(object sender, EventArgs e)
        {
            selIndex = MidiSelection.HARMONY_ONLY;

        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            onPlayClick();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            onSaveClick();
        }

        protected void onStartClick()
        {
            prgProcessing.Visible = true;
            setProcessingState();

            // Analysis Stage

            makeProgress(5);
            Analyzer a = new Analyzer();

            makeProgress(5);
            a.initialize(m_midiControl.getMidiData(MidiSelection.SOURCE));

            lblAvgVel.Text = a.getAverageVelocity().ToString();
            lblTempo.Text = a.getTempo().ToString();

            makeProgress(5);
            picKeySig.ImageLocation = "KeySig\\" + (a.getKey().ToString()) + ".png";


            timeSignNum.ImageLocation = a.getTimeSignatureNumerator().ToString() + ".png";
            timeSigDenom.ImageLocation = ((int)Math.Pow(a.getTimeSignatureDenominator(), 2)).ToString() + ".png";

            // Transposition

            makeProgress(5);
            int key = a.getKey();

            int interval = getTranspositionForKey(key);

            System.Console.WriteLine(key);
            MidiEventCollection t = Transposer.transpose(m_midiControl.getMidiData(selIndex), interval);
            makeProgress(20);

            // Harmonization
            Harmonizer h = new Harmonizer(t);
            MidiEventCollection result = h.process(0, 0, 0, 0, 0);

            makeProgress(40);

            // Inverse Transposition
            MidiEventCollection tRet = Transposer.transpose(result, -1 * interval);

            makeProgress(10);

            m_midiControl.setMidiData(tRet, MidiSelection.RESULT);
            m_midiControl.setMidiData(tRet, MidiSelection.HARMONY_ONLY);

            makeProgress(10);

            setProcessedState();
        }

        protected void onPlayClick()
        {
            m_midiControl.play(selIndex);
        }

        protected void onSaveClick()
        {
            m_midiControl.save(selIndex);
        }

        protected void onOpenMenuClick()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "MIDI Files|*.mid";
            ofd.Title = "Select a MIDI file to open...";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                m_midiControl.open(0, ofd.FileName);
                lblCurFile.Text = ReducePathString(ofd.FileName, lblCurFile.Width);
                setReadyState();
            } 
        }

        private void setReadyState()
        {
            // Update the size of the Window frame. 
            this.Size = new System.Drawing.Size(this.Size.Width, 421);
            selOriginal.Enabled = true;
            playBtn.Enabled = true;
            startBtn.Enabled = true;
        }
        
        private void setProcessingState()
        {
            playBtn.Enabled = false;
            startBtn.Enabled = false;
        }

        private void setProcessedState()
        {
            selOriginal.Enabled = true;
            playBtn.Enabled = true;
            startBtn.Enabled = true;
            selHarmony.Enabled = true;
            selFull.Enabled = true;
            saveBtn.Enabled = true;
            saveMenu.Enabled = true;
            prgProcessing.Value = 0;
            prgProcessing.Visible = false;
        }
        
   
        protected void onExitMenuClick()
        {
            this.Close();
            
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            onExitMenuClick();
        }

        private void BitHoven_FormClosing(object sender, FormClosingEventArgs e)
        {
            lblStatus.Text = "Exiting Application...";
            prgProcessing.Value = 0;

        }

        private String ReducePathString(String s, int width)
        {
            String ret = String.Copy(s);
            TextRenderer.MeasureText(ret, this.Font, new System.Drawing.Size(width, 0), TextFormatFlags.ModifyString | TextFormatFlags.PathEllipsis);
            return ret;
        }

        private void saveMenu_Click(object sender, EventArgs e)
        {
            onSaveClick();
        }

      

    }
}
