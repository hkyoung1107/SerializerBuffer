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
    public class LineLiteDecoder
    {
        private readonly SerializationDumper _sd;
        private readonly Dictionary<string, object> _fieldData;

        public LineLiteDecoder(string path)
        {
            _sd = new SerializationDumper(path);
            _fieldData = new Dictionary<string, object>();
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
                    {
                        var value = cf.GetValue();
                        if(value is ClassDataDesc)
                            getClassData((ClassDataDesc)value);
                        else
                            _fieldData[cf.GetName()] = cf.GetValue();
                    }
                }
            }

            return _fieldData;
        }

        private void getClassData(ClassDataDesc cdd)
        {
            var details = cdd.ClassDetails;
            ClassDetails cd = details[0];
            var fields = cd.GetFields();
            ClassField cf = (ClassField)fields[0];
            _fieldData[cf.GetName()] = cf.GetValue();
        }

    }
}
