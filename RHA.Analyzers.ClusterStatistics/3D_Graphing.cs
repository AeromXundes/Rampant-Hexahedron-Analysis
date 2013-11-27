using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClusterStatistics
{
    public partial class _3D_Graphing : Form
    {
        public _3D_Graphing()
        {
            InitializeComponent();
        }

        private void ilPanel1_Load(object sender, EventArgs e)
        {
            var scene = new ILScene();
            var sphere = scene.Camera.Add(
                    new ILSphere
                    {
                        Wireframe = { Color = Color.Black },
                        Fill = { Color = Color.FromArgb(150, Color.Yellow) }
                    });

            // add a triangle shape
            var tri = sphere.Add(Shapes.Triangle);
            // configure its positions (vertices)
            tri.Positions.Update(new float[,] {
              {0,0,0}, // first vertex
              {1,0,0}, // second vertex
              {1,1,0}, // third vertex
            });
            // make the triangle red
            tri.Color = Color.Red;
            // turns lighting off for the triangle
            tri.AutoNormals = false;

            // reuse the triangles shape: 
            // add a new group to the sphere
            var group = sphere.Add(
                // the group gets a transform configured
              new ILGroup(rotateAxis: new Vector3(0, 1, 0),
                          angle: Math.PI));
            // add the old triangle to the group
            var tri2 = group.Add(tri);
            // give the new triangle a green color
            tri2.Color = Color.Green;

            var cube = Shapes.UnitCubeWireframe;
            var x = scene.Camera.Add(cube);
            cube.Positions.Update(new float[,] { { 1, 2, 1 }, {1,2,1} });

            // even more reusing 
            using (ILScope.Enter())
            {
                // make 50 random positions: range ([-10..10],[-10..10],[0..-20])
                ILArray<float> positions = ILMath.tosingle(ILMath.rand(3, 50));
                positions = positions * ILMath.array<float>(20f, 20f, -20f)
                                      + ILMath.array<float>(-10f, -10f, 0f);
                // create 50 clones, each at a random position
                for (int i = 0; i < positions.S[1]; i++)
                {
                    var clone = scene.Camera.Add(sphere);
                    clone.Transform = Matrix4.Translation(
                            positions.GetValue(0, i),
                            positions.GetValue(1, i),
                            positions.GetValue(2, i));
                }
            }
            ilPanel1.Scene = scene; 
        }
    }
}
