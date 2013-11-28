using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;

namespace ClusterStatistics
{
    public class Block3D : ILGroup
    {
        public Block3D()
        {
            Cube = Shapes.UnitCubeFilledLit;
            Wireframe = Shapes.UnitCubeWireframe;
            this.Add(Cube);
            this.Add(Wireframe);
        }

        public Block3D(double x, double y, double z)
            :this()
        {
            this.Translate(x, y, z);
        }

        public Block3D(Vector3 v)
            :this()
        {
            this.Translate(v);
        }

        public Block3D(System.Drawing.Color CubeColor)
            :this()
        {
            Cube.Color = CubeColor;
        }

        public Block3D(Vector3 v, System.Drawing.Color CubeColor)
            :this()
        {
            this.Translate(v);
            Cube.Color = CubeColor;
        }

        public Block3D(double x, double y, double z, System.Drawing.Color CubeColor)
            :this(x,y,z)
        {
            Cube.Color = CubeColor;
        }

        public Block3D(double x, double y, double z, System.Drawing.Color CubeColor, float CubeAlpha)
            :this(x,y,z,CubeColor)
        {
            Cube.Color = System.Drawing.Color.FromArgb((int)(255*CubeAlpha), Cube.Color.Value);
        }
        public ILTriangles Cube { get; set; }
        public ILLines Wireframe { get; set; }
        public float CubeAlpha
        {
            get { return Cube.Color.Value.A / 255.0f; }
            set { Cube.Color = System.Drawing.Color.FromArgb((int)(255 * value), Cube.Color.GetValueOrDefault()); }
        }
        public System.Drawing.Color? CubeColor
        {
            get { return Cube.Color; }
            set { Cube.Color = value; }
        }
    }
}
