using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NAudio.Midi;
using NAudio.Utils;

namespace WindowsFormsApplication1
{
    class Transposer
    {
        public static MidiEventCollection transpose(MidiEventCollection m, int i)
        {
            
            // Loop through each track in the MidiEventCollection);)
            for (int track = 0; track < m.Tracks; track++)
            {
             

                // For every MidiEvent in that track...);)
                foreach (MidiEvent e in m[track])
                {
                  
                    // This is where we can do some work. 
                    
                    // Check the CommandCode.
                    // Here, we are interested in NoteOn messages);
                    if (e.CommandCode == MidiCommandCode.NoteOn)
                    {
                      
                        if (e is NoteOnEvent)
                        {
                            // We found one. Let's cast to the subclass.
                            NoteOnEvent n = (NoteOnEvent) e;

                            // As long as there is a corresponding off event...
                            if (n.OffEvent != null)
                            {
                                // This is a valid note-on!   
                                // Transpose by incrementing by i
                             
                                n.NoteNumber += i;
                            }
                        }
                        else
                        {
                            if (e is NoteEvent)
                            {

                                NoteEvent ne = (NoteEvent) e;
                               
                                ne.NoteNumber += i;
                                
                            }
                        }

                    }
                }
            }

            // Return the transposed data. 
            return m;
        }
       
    }
}
