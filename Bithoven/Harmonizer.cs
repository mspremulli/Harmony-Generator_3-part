using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio.Midi;
using NAudio.Utils;

using System.Windows.Media.Media3D;

namespace WindowsFormsApplication1
{
    class Harmonizer
    {
        

        // Initialize 3D vectors for chord tones
       

        private Vector3D[] chordVectors;
        private Vector3D mostRecentChord;

        private MidiEventCollection melody;

        public Harmonizer()
        {
            initKnowledge();
        }

        public Harmonizer(MidiEventCollection m)
        {
            melody = m;
            initKnowledge();
        }

        private void initKnowledge()
        {
            chordVectors = new Vector3D[7];

            chordVectors[0] = new Vector3D(0, 4, 7);
            chordVectors[1] = new Vector3D(2, 5, 9);
            chordVectors[2] = new Vector3D(4, 7, 11);
            chordVectors[3] = new Vector3D(5, 9, 0);
            chordVectors[4] = new Vector3D(7, 11, 2);
            chordVectors[5] = new Vector3D(9, 0, 4);
            chordVectors[6] = new Vector3D(11, 2, 5);

            // Assume we start at C Major
            mostRecentChord = chordVectors[0];
        }

        private double compareVectorAgainstInversions(Vector3D u, Vector3D v)
        {
            // u is the incoming chord
            // v is potential matches (must get inverted)

            Vector3D ua = new Vector3D(u.X+12, u.Y+12, u.Z+12);

            Vector3D va = new Vector3D(v.X +12, v.Y+12, v.Z + 12); ;
            Vector3D vb = new Vector3D(v.X+12, v.Y+12, v.Z);
            Vector3D vc = new Vector3D(v.X+12, v.Y, v.Z );

            double ang1 = Vector3D.AngleBetween(ua, va);
            double ang2 = Vector3D.AngleBetween(ua, vb);
            double ang3 = Vector3D.AngleBetween(ua, vc);

            return (Math.Min(Math.Min(ang1, ang2), ang3));
        }

        private Vector3D[] getHarmonizationCandidatesForNote(int note)
        {
            Vector3D[] candidates = new Vector3D[3];
            int currentIndex = 0;

            for (int i = 0; i < 7; ++i)
            {
                if ((chordVectors[i].X == note) || (chordVectors[i].Y == note) || (chordVectors[i].Z == note))
                {
                    candidates[currentIndex++] = chordVectors[i];
                }
            }
            return candidates;
        }

        private Vector3D getCandidateChordDisplacementVector(Vector3D u, Vector3D v)
        {
            // Step 1. Compute all arrangements of v
            Vector3D[] vi = new Vector3D[6];
            vi[0] = new Vector3D(v.X, v.Y,v.Z);
            vi[1] = new Vector3D(v.Z, v.X, v.Y);
            vi[2] = new Vector3D(v.Y, v.Z, v.X);
            vi[3] = new Vector3D(v.X, v.Z, v.Y);
            vi[4] = new Vector3D(v.Y, v.X, v.Z);
            vi[5] = new Vector3D(v.Z, v.Y, v.X);

            double[] xyz = new double[3]{u.X, u.Y, u.Z};
            double[] temp = new double[3]{0,0,0};

            Vector3D candidate = new Vector3D(100, 100, 100);

            // For each of the arrangements of the candidate chord
            for (int i = 0; i < 6; ++i)
            {
                double[] vxyz = new double[3] { vi[i].X, vi[i].Y, vi[i].Z };
                // For each of the scale tones in source chord
                for (int j = 0; j < 3; ++j )
                {
                    // Compare difference
                    double t = (vxyz[j] - xyz[j]);

                    // Adjust for octaves if needed
                    if (t > 6)
                    {
                        t = (-1)*(12 - t);
                    }
                    else if (t < -6)
                    {
                        t += 12;
                    }

                    // Store temp vector component
                    temp[j] = t;
                }

                if (Math.Abs(temp[0])  + Math.Abs(temp[1]) + Math.Abs(temp[2]) <
                    candidate.X + candidate.Y + candidate.Z)
                {
                    // Store this as the candidate
                    candidate.X = temp[0];
                    candidate.Y = temp[1];
                    candidate.Z = temp[2];
                }
            }

            return candidate;

        }

        private Vector3D minCandidateSum(Vector3D u, Vector3D v)
        {
            // Special case hack for zero-sums
            if (u.X + u.Y + u.Z == 0)
                return v;

            if (v.X + v.Y + v.Z == 0)
                return u;

            if (u.X + u.Y + u.Z < v.X + v.Y + v.Z)
                return u;

            return v;
        }

        private Vector3D harmonizeNote(int noteNumber, Vector3D prev, Vector3D hint)
        {
            // Convert the note value to a number between 0-11
            int noteVal = noteNumber%12;

            // Get list of possible chords
            Vector3D[] candidates = getHarmonizationCandidatesForNote(noteVal);

            // Loop through list and find the one that results in the
            // least amount of movement
            // 

            if (!(hint.X == 0 && hint.Y == 0 && hint.Z == 0))
            {
                candidates[0] = hint;
                candidates[1] = hint;
                candidates[2] = hint;
            }

            for (int i = 0; i < 3; ++i)
            {
                candidates[i] = getCandidateChordDisplacementVector(mostRecentChord, candidates[i]);
            }

            Vector3D disp =  minCandidateSum(minCandidateSum(
                                candidates[0], candidates[1]), candidates[2]);


            // Check for non-movement
            

            // We now have the minimum displacement vector. We add this to the
            // current chord, and that is the harmonization result.

            return mostRecentChord + disp;

        }

        private int getNumberOfNotes()
        {

            int noteCount = 0;

            // For every MidiEvent in that track...
            foreach (MidiEvent e in melody[0])
            {
                if (e.CommandCode == MidiCommandCode.NoteOn)
                {
                    if (e is NoteOnEvent)
                    {
                        NoteOnEvent non = (NoteOnEvent)e;


                        if (non.OffEvent != null)
                        {
                            ++noteCount;
                        }
                    }

                }
            }
            return noteCount;
        }

        private int getCadenceForNote(int note)
        {
            switch (note)
            {
                case 0: 
                case 5: 
                case 9:   // Subdominant 
                    return 3;   
                case 2:
                case 7:
                case 11:
                case 4: // Dominant
                    return 4;
            }
            return 4;
        }

        public MidiEventCollection process(int timeSigNum, int timeSigDen, int octaveEst, int avgVel, int bars)
        {
            MidiEventCollection m = melody;


            int noteCount = getNumberOfNotes();
            int noteIndex = 0;

            int initialTrackCount = m.Tracks;
            m.AddTrack();
            int newTrack = m.Tracks - 1;

            bool bFirst = true;

            Vector3D noHint = new Vector3D(0,0,0);

            m[newTrack].Add(new PatchChangeEvent(0, 2, 1));

            // Loop through each track in the MidiEventCollection
            for (int track = 0; track < initialTrackCount; track++)
            {
                // For every MidiEvent in that track...
                foreach (MidiEvent e in m[track])
                {
                    
                    // This is where we can do some work. 
                    
                    // Check the CommandCode.
                    // Here, we are interested in NoteOn messages
                    if (e.CommandCode == MidiCommandCode.NoteOn)
                    {
                        if (e is NoteOnEvent)
                        {
                            NoteOnEvent non = (NoteOnEvent) e;
                            NoteEvent n = (NoteEvent) e;

                            if (non.OffEvent != null)
                            {
                                ++noteIndex;
                                // We want to harmonize this note!
                                Vector3D harmonization = new Vector3D(0, 0, 0);

                                if (!bFirst && noteIndex < noteCount - 1)
                                    harmonization = harmonizeNote(n.NoteNumber, mostRecentChord, noHint);
                                else
                                {
                                    if (noteIndex == noteCount - 1)
                                    {
                                        harmonization = harmonizeNote(n.NoteNumber, mostRecentChord, 
                                                          chordVectors[getCadenceForNote(n.NoteNumber% 12)]);
                                    }
                                    else if (noteIndex == noteCount)
                                    {
                                        harmonization = harmonizeNote(n.NoteNumber, mostRecentChord,
                                                          chordVectors[0]);
                                    }
                                    else
                                    {
                                        bFirst = false;
                                        harmonization = mostRecentChord;
                                    }

                                   
                                }

                        //        NoteEvent n1 = new NoteEvent(n.AbsoluteTime, 2, MidiCommandCode.NoteOn,
                                    //                       (int) harmonization.X + 60, n.Velocity);
                                 NoteOnEvent n1 = new NoteOnEvent(n.AbsoluteTime, 2,
                                                             (int) harmonization.X + 60, n.Velocity, non.NoteLength);
                            //    NoteEvent n1off = new NoteEvent(non.NoteLength, 2, MidiCommandCode.NoteOff,
                             //                                   (int) harmonization.X + 60, n.Velocity);

                             //   NoteEvent n2 = new NoteEvent(n.AbsoluteTime, 2, MidiCommandCode.NoteOn,
                                //                             (int) harmonization.Y + 60, n.Velocity);
                             
                                  NoteOnEvent n2 = new NoteOnEvent(n.AbsoluteTime, 2,
                                                             (int) harmonization.Y + 60, n.Velocity, non.NoteLength);
                                
                                //   NoteEvent n2off = new NoteEvent(non.NoteLength, 2, MidiCommandCode.NoteOff,
                               //                                 (int) harmonization.Y + 60, n.Velocity);

                           //     NoteEvent n3 = new NoteEvent(n.AbsoluteTime, 2, MidiCommandCode.NoteOn,
                          //                                   (int) harmonization.Z + 60, n.Velocity);
                             
                                  NoteOnEvent n3 = new NoteOnEvent(n.AbsoluteTime, 2,
                                                             (int) harmonization.Z + 60, n.Velocity, non.NoteLength);
                                
                                //   NoteEvent n3off = new NoteEvent(non.NoteLength, 2, MidiCommandCode.NoteOff,
                                 //                               (int) harmonization.Z + 60, n.Velocity);

                                

                                m[newTrack].Add(n1); m[newTrack].Add(n1.OffEvent);
                         //       m[newTrack].Add(n1off);
                                m[newTrack].Add(n2); m[newTrack].Add(n2.OffEvent);
                         //       m[newTrack].Add(n2off);
                                m[newTrack].Add(n3); m[newTrack].Add(n3.OffEvent);
                           //     m[newTrack].Add(n3off);
                                
                                mostRecentChord = harmonization;

                            }
                        }

                    }
         
                }
            }
            AppendEndMarker(m[0]);
            AppendEndMarker(m[1]);
            return m;
        }

        private void AppendEndMarker(IList<MidiEvent> eventList)
        {
            long absoluteTime = 0;
            
            if (eventList.Count > 0)
                absoluteTime = eventList[eventList.Count - 1].AbsoluteTime;

            eventList.Add(new MetaEvent(MetaEventType.EndTrack, 0, absoluteTime));
        }

        public double testAngle()
        {
            // junk code. Just here for test.
          //  getCandidateChordDisplacementVector(v1, v2);
         
            return 0;
        }
        

    }
}
