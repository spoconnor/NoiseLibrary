using NoiseLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoiseTestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Draw();
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            Draw();
        }

        private void Draw()
        {
            var currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.pictureBox1.Image = this.DrawImage(this.pictureBox1.Width, this.pictureBox1.Height);
            this.Cursor = currentCursor;
        }

        private Bitmap DrawImage(int width, int height)
        {
            var bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            var ground_gradient = new CImplicitGradient(x1: 0, x2: 0, y1: 0, y2: 1);
            var lowland_shape_fractal = new CImplicitFractal(type: EFractalTypes.FBM, basistype: CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves: 2, freq: 1);
            var lowland_autocorrect = new CImplicitAutoCorrect(source: lowland_shape_fractal, low: 0, high: 1);
            var lowland_scale = new CImplicitScaleOffset(source: lowland_autocorrect, scale: 0.2, offset: -0.25);
            var lowland_y_scale = new CImplicitScaleDomain(source: lowland_scale, x: 1, y: 0);
            var lowland_terrain = new CImplicitTranslateDomain(source: ground_gradient, tx: 0, ty: lowland_y_scale, tz: 0);
            var highland_shape_fractal = new CImplicitFractal(type: EFractalTypes.RIDGEDMULTI, basistype: CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves: 2, freq: 2);
            var highland_autocorrect = new CImplicitAutoCorrect(source: highland_shape_fractal, low: 0, high: 1);
            var highland_scale = new CImplicitScaleOffset(source: highland_autocorrect, scale: 0.45, offset: 0);
            var highland_y_scale = new CImplicitScaleDomain(source: highland_scale, x: 1, y: 0);
            var highland_terrain = new CImplicitTranslateDomain(source: ground_gradient, tx: 0, ty: highland_y_scale, tz: 0);

            var mountain_shape_fractal = new CImplicitFractal(type: EFractalTypes.BILLOW, basistype: CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves: 4, freq: 1);
            var mountain_autocorrect = new CImplicitAutoCorrect(source: mountain_shape_fractal, low: 0, high: 1);
            var mountain_scale = new CImplicitScaleOffset(source: mountain_autocorrect, scale: 0.75, offset: 0.25);
            var mountain_y_scale = new CImplicitScaleDomain(source: mountain_scale, x: 1, y: 0.1);
            var mountain_terrain = new CImplicitTranslateDomain(source: ground_gradient, tx: 0, ty: mountain_y_scale, tz: 0);

            var terrain_type_fractal = new CImplicitFractal(type: EFractalTypes.FBM, basistype: CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves: 3, freq: 0.5);
            var terrain_autocorrect = new CImplicitAutoCorrect(source: terrain_type_fractal, low: 0, high: 1);
            var terrain_type_cache = new CImplicitCache(v: terrain_autocorrect);
            var highland_mountain_select = new CImplicitSelect(low: highland_terrain, high: mountain_terrain, control: terrain_type_cache, threshold: 0.55, falloff: 0.15);
            var highland_lowland_select = new CImplicitSelect(low: lowland_terrain, high: highland_mountain_select, control: terrain_type_cache, threshold: 0.25, falloff: 0.15);
            var ground_select = new CImplicitSelect(low: 0, high: 1, threshold: 0.5, control: highland_lowland_select);

            for (int x = 1; x < width; x++)
            {
                for (int y = 1; y < height; y++)
                {
                    var p = (int)(ground_select.get((double)x / width, (double)y / height) * 255);
                    var color = Color.FromArgb(255, 0, p, 0);
                    graphics.FillRectangle(new SolidBrush(color), x, y, 1, 1);
                }
            }

            return bitmap;
        }

    }
}
