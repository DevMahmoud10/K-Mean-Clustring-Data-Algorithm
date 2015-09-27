using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K_Mean_Clustring_Data_Algorithm
{
    public struct point
    {
        public int x; public int y;
    }
    public class KMean
    {
        int counter;
        public KMean()
        { }

        public KMean(KMean obj)
        {
            this.Clusters.AddRange(obj.Clusters);
        }
        public List<Cluster> Clusters = new List<Cluster>();

        public void fillClusters(List<point> p, List<point> c, List<int[]> colors)
        {

            for (int i = 0; i < c.Count; i++)
            {
                this.Clusters.Add(new Cluster(c[i], colors[i]));
            }

            sepratePoints(p);

        }

        void sepratePoints(List<point> p)
        {
            int maxIndex = 0;
            int[] tmpArr = new int[this.Clusters.Count];

            for (int i = 0; i < p.Count; i++)
            {
                for (int j = 0; j < this.Clusters.Count; j++)
                {
                    tmpArr[j] = calculateDistance(p[i], this.Clusters[j].p);
                }
                maxIndex = tmpArr.ToList().IndexOf(tmpArr.Min());
                this.Clusters[maxIndex].clusterPoints.Add(p[i]);
            }

        }

        int calculateDistance(point p, point c)
        {
            double d = Math.Sqrt(Math.Pow((p.x - c.x), 2) + Math.Pow((p.y - c.y), 2));
            return Convert.ToInt32(d);
        }

        // calculate mean to generate new centroid
        point calculateMean(List<point> p)
        {
            point tmpPoint = new point();
            int sumX = 0, sumY = 0;
            for (int i = 0; i < p.Count; i++)
            {
                sumX += p[i].x;
                sumY += p[i].y;
            }

            if (p.Count != 0)
            {
                tmpPoint.x = sumX / p.Count;
                tmpPoint.y = sumY / p.Count;

            }
            else
            {
                tmpPoint.x = 0;
                tmpPoint.y = 0;
            }


            return tmpPoint;
        }

        bool isFound(List<Cluster> pool, point val)
        {
            for (int i = 0; i < pool.Count; i++)
            {
                if (pool[i].p.x == val.x && pool[i].p.y == val.y)
                    return true;
            }
            return false;
        }
        public void reCalculateCluster()
        {
            int changes = 0;

            while (0 == 0)
            {
                changes = 0;
                //set new centroids
                for (int i = 0; i < this.Clusters.Count; i++)
                {
                    point mean = calculateMean(this.Clusters[i].clusterPoints);
                    
                    if (!isFound(this.Clusters, mean))
                    {
                        changes++;
                    }

                    this.Clusters[i].p = mean;

                    // check if centroids is changed
                    
                }

                if (changes == 0 || counter==10)
                    break;


                //collect all points to resepareate depends on new centroids
                List<point> AllPointsList = new List<point>();
                for (int i = 0; i < this.Clusters.Count; i++)
                {
                    AllPointsList.AddRange(this.Clusters[i].clusterPoints);
                    this.Clusters[i].clusterPoints = null;
                    this.Clusters[i].clusterPoints = new List<point>();
                }

                //reseprate points on new clusters 
                sepratePoints(AllPointsList);

                counter++;
            }
        }
    }

}