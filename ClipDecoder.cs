using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JavaDeserializer;

namespace SerializerBuffer
{
    public class ClipDecoder
    {
        private readonly SerializationDumper _sd;
        private readonly Dictionary<string, object> _fieldData;

        public ClipDecoder(string path)
        {
            _sd = new SerializationDumper(path);
            _fieldData = new Dictionary<string, object>();
        }

        public Boolean Init()
        {
            return _sd.InitOk;
        }

        public Boolean Parse()
        {
            return _sd.ParseStream();
        }

        public Dictionary<string, object> GetData()
        {
            List<ClassDataDesc> allData =  _sd. GetData;

            foreach (ClassDataDesc cdd in allData)
            {
                var details = cdd.ClassDetails;
                foreach (ClassDetails cd in details)
                {
                    var fields = cd.GetFields();
                    foreach (ClassField cf in fields)
                        _fieldData[cf.GetName()] = cf.GetValue();
                }
            }

            return _fieldData;
        }

    }
}
