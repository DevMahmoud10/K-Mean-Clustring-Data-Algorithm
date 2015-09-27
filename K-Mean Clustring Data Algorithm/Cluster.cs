using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K_Mean_Clustring_Data_Algorithm
{
    public class Cluster
    {
        public point p = new point();
        public int[] color = new int[3];    //rgb color
        public List<point> clusterPoints = new List<point>();
        public Cluster() { }
        public Cluster(point CentroidCoordinates,int []color) 
        {
            this.p.x = CentroidCoordinates.x;
            this.p.y = CentroidCoordinates.y;
            this.color[0] = color[0];
            this.color[1] = color[1];
            this.color[2] = color[2];
        }
    }
}