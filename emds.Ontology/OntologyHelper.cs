using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OwlDotNetApi;
using emds.common;

namespace emds.Ontology
{
    public class OntologyHelper
    {
        IOwlGraph _graph;

        public IOwlGraph OwlGraph
        {
            get { return _graph; }
        }

        public void LoadOwlGraph(string path)
        {
            IOwlParser p = new OwlXmlParser();
            _graph = p.ParseOwl(path);
            
        }
    }
}
