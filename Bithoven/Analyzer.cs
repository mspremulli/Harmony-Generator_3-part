using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using NAudio.Midi;
using NAudio.Utils;

namespace WindowsFormsApplication1
{
    class Analyzer
    {
        // Store the MidiEvent data we are analyzing.. 
        private MidiEventCollection m_data;
        private TimeSignatureEvent m_timeSig;

        public Analyzer()
        {
            
        }

        public Analyzer(MidiEventCollection m)
        {
            // Pass it along
            initialize(m);
        }

        public void initialize(MidiEventCollection m)
        {
            // Initialize the internal MIDI data
            m_data = m;
            getTimeSignature();
            return;
        }

        public int getKey()
        {
            // Assume C
            int key = 0;

            // For each track in the file
            for (int track = 0; track < m_data.Tracks; track++)
            {
                // For each MidiEvent in the track
                foreach (MidiEvent e in m_data[track])
                {
                   
                    // If this is a MetaEvent
                    if (e.CommandCode == MidiCommandCode.MetaEvent)
                    {
                        // Check if the type of event is KeySignatureEvent
                        if (e is KeySignatureEvent)
                        {
                            // Good. We have a key! Cast it. 
                            KeySignatureEvent n = (KeySignatureEvent) e;

                            // Representation is:
                            // -: # of flats (to -7)
                            // 0: C
                            // +: # of sharps (to +7)

                            // Directly read in the value
                            key = n.SharpsFlats;

                            // HACKHACK: The documentation for NAUDIO
                            // is incorrect. Flat keys are stored as 255
                            // minus a key adjustment amount. This corrects
                            // it down to the -7 to 0 range expected. 
                            if (key > 7)
                            {
                                key = -1*(255 - key+1);
                            }

                        }
                    }
                }
            }

            // Return it
            return key;
        }

        public int getTempo()
        {
            // 120 BPM is the assumed default if no tempo events
            // are found in the midi data. 
            int retTempo = 120;

            // There are 60000000 microseconds in a minute. 

            // BUGBUG: can be decimal?
            // AWNSER: yes it can, but we will ignore it. 

            // Loop through all the tracks
            for (int track = 0; track < m_data.Tracks; track++)
            {
                // For each MidiEvent in the track
                foreach (MidiEvent e in m_data[track])
                {
                    // Look for a MetaEvent
                    if (e.CommandCode == MidiCommandCode.MetaEvent)
                    {
                        // Found a MetaEvent
                        // Is the type TempEvent?
                        if (e is TempoEvent)
                        {
                            // Yes. Cast it.
                            TempoEvent n = (TempoEvent) e;

                            // Store the tempo value in BPM
                            retTempo = (int) n.Tempo;
                        }
                    }
                }
            }

            // Return
            return retTempo;
        }

        public int getTimeSignatureNumerator()
        {
            return m_timeSig.Numerator;
        }

        public int getTimeSignatureDenominator()
        {
            return m_timeSig.Denominator;
        }

        // BAD. Should have one for numerator, one for denominator
        private TimeSignatureEvent getTimeSignature()
        {
            // should there be a default state?
            for (int track = 0; track < m_data.Tracks; track++)
            {
                foreach (MidiEvent e in m_data[track])
                {
                    if (e.CommandCode == MidiCommandCode.MetaEvent)
                    {
                        if (e is TimeSignatureEvent)
                        {
                            TimeSignatureEvent n = (TimeSignatureEvent) e;
                           
                            m_timeSig = n;
                            break; // not allowing time signature changes
                        }
                    }
                }
            }
            return m_timeSig;
        }

        public int getOctaveEstimate()
        {
            // Midi musicnote numbers go from #21 to #108
            int noteNumberSum = 0;
            int noteCount = 0;

            for (int track = 0; track < m_data.Tracks; track++)
            {
                foreach (MidiEvent e in m_data[track])
                {
                    TimeSignatureEvent t;


                    if (e.CommandCode == MidiCommandCode.NoteOn)
                    {
                        NoteOnEvent n = (NoteOnEvent)e;

                        if (n.OffEvent != null)
                        {
                            ++noteCount;
                            noteNumberSum += n.NoteNumber;
                            // It is an event!

                        }
                    }
                }
            }

            int avgNoteVal = (int)(noteNumberSum/noteCount);

            return avgNoteVal % 7;
        }

        public int getAverageVelocity()
        {
            int velocitySum = 0;
            int velocityCount = 0;
            
            for (int track = 0; track < m_data.Tracks; track++)
            {
                foreach (MidiEvent e in m_data[track])
                {
                    TimeSignatureEvent t;
                  
                    
                    if (e.CommandCode == MidiCommandCode.NoteOn)
                    {
                        NoteOnEvent n = (NoteOnEvent)e;
                        
                        if (n.OffEvent != null)
                        {
                            ++velocityCount;
                            velocitySum += n.Velocity;
                            // It is an event!

                        }
                    }
                }
            }

            return (int) (velocitySum/velocityCount);

        }

        public int getNumberOfBars()
        {
            return 0;
        }

    }
}
