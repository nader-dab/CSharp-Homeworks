using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
    public class AudioDocument : Multimedia
    {
        public long? SampleRate { get; protected set; }

        public void ChangeContent(string newContent)
        {
            throw new NotImplementedException();
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "samplerate")
            {
                this.SampleRate = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
            base.SaveAllProperties(output);
        }
    }
}
