using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DistanceCalcSoapService
{
  
    [ServiceContract]
    public interface IDistCalc
    {

        [OperationContract]
        double distance(Point startPoint,Point endPoint);

        
    }


    
    [DataContract]
    public class Point
    {
       
        [DataMember]
       public int X { get; set; }
         [DataMember]
       public int Y { get; set; }
        
    }
}
