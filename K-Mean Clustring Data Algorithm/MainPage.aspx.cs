using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace K_Mean_Clustring_Data_Algorithm
{
    public partial class MainPage : System.Web.UI.Page
    {
        KMean Panel;
    
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack) // If page loads for first time
            {
                // Assign the Session["update"] with unique value
                Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["myObj"] = new KMean();
                //page load code
                
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel = Session["myObj"] as KMean;
            if (Session["update"].ToString() == ViewState["update"].ToString())
            {
                List<point> p = new List<point>();
                List<point> c = new List<point>();
                List<int[]> colors = new List<int[]>();

                Random r = new Random();
                point tmpPoint;    //to set points
                string rgb;     //to set colors

                for (int i = 0; i < int.Parse(TextBox1.Text); i++)
                {
                    //set N points 
                    tmpPoint.x = r.Next(1, 600);
                    tmpPoint.y = r.Next(1, 600);

                    //change on .aspx file
                    points.InnerHtml += "<circle cx=" + tmpPoint.x.ToString() + " cy=" + tmpPoint.y.ToString() + " r='5'></circle>";

                    //add to tmp list --> List<point> p = new List<point>();
                    p.Add(tmpPoint);

                    // generate Centroid point
                    if (i < int.Parse(TextBox2.Text))
                    {
                        //set M centroids
                        tmpPoint.x = r.Next(1, 600);
                        tmpPoint.y = r.Next(1, 600);

                        int[] tmpcolor = new int[3];
                        tmpcolor[0] = r.Next(1, 255);
                        tmpcolor[1] = r.Next(1, 255);
                        tmpcolor[2] = r.Next(1, 255);

                        rgb = "fill:rgb(" + tmpcolor[0] + "," + tmpcolor[1] + "," + tmpcolor[2] + ");";  // choose randomly color for centroids 

                        colors.Add(tmpcolor);
                        // change div on aspx file
                        centroids.InnerHtml += "<circle cx=" + tmpPoint.x.ToString() + " cy=" + tmpPoint.y.ToString() + " r='10.0' style=" + rgb + "></circle>";

                        //add to tmp list -->   List<point> c = new List<point>();
                        c.Add(tmpPoint);
                    }
                   


                }
                Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());

                Panel.fillClusters(p, c, colors);
                Session["myObj"] = Panel;
              
            }
            
           
            else
            {
                points.InnerHtml = "";
                centroids.InnerHtml = "";
            }



        }

        protected void Button1_PreRender(object sender, EventArgs e)
        {
            ViewState["update"] = Session["update"];
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel = Session["myObj"] as KMean;
            if (Session["update"].ToString() == ViewState["update"].ToString())
            {

                
                Panel.reCalculateCluster();

                centroids.InnerHtml = "";
                points.InnerHtml = "";
                //redraw new centroids 
                for (int i = 0; i < Panel.Clusters.Count; i++)
                {
                    string rgb = "fill:rgb(" + Panel.Clusters[i].color[0] + "," + Panel.Clusters[i].color[1] + "," + Panel.Clusters[i].color[2] + ");";  // choose randomly color for centroids 
                    centroids.InnerHtml += "<circle cx=" + Panel.Clusters[i].p.x.ToString() + " cy=" + Panel.Clusters[i].p.y.ToString() + " r='10.0' style=" + rgb + "></circle>";

                    //color every point depends on its cluster color
                    for (int j = 0; j < Panel.Clusters[i].clusterPoints.Count; j++)
                    {
                        points.InnerHtml += "<circle cx=" + Panel.Clusters[i].clusterPoints[j].x.ToString() + " cy=" + Panel.Clusters[i].clusterPoints[j].y.ToString() + " r='5.0' style=" + rgb + "></circle>";
                    }
                }


               

            }
            else
            {
                Response.Write("<script>alert('Enter Points and Centroids First !!')</script>");
            }
        }

        protected void Button2_PreRender(object sender, EventArgs e)
        {
            ViewState["update"] = Session["update"];
        }

        





    }
}